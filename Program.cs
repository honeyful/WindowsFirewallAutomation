#region namespace
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

#endregion
namespace WindowsFirewallAutomation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string appGuid =
                ((GuidAttribute)Assembly.GetExecutingAssembly().
                    GetCustomAttributes(typeof(GuidAttribute), false).
                        GetValue(0)).Value.ToString();

            string mutexId = string.Format("Global\\{{{0}}}", appGuid);

            bool createdNew;

            var allowEveryoneRule =
                new MutexAccessRule(
                    new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                    MutexRights.FullControl, AccessControlType.Allow);
            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);

            using (var mutex = new Mutex(false, mutexId, out createdNew, securitySettings))
            {
                var hasHandle = false;
                try
                {
                    try
                    {
                        hasHandle = mutex.WaitOne(5000, false);
                        if (!hasHandle)
                            return;
                       
                    }
                    catch (AbandonedMutexException)
                    {
                        hasHandle = true;
                    }
                   Application.Run(new MainFrame());
                }
                finally
                {
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }
    }
}
