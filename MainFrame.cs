#region namespace
using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Management;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using NetFwTypeLib;
#endregion

namespace WindowsFirewallAutomation
{
    public partial class MainFrame : Form
    {
        #region declare
        private ManagementEventWatcher watch;
        private FileSystemWatcher fsw;
        private string selectedItem = string.Empty;
        #endregion

        #region init
        public MainFrame()
        {
            InitializeComponent();
            //if (args.Contains("tray")) WindowState = FormWindowState.Minimized;
           
        }

        private void MainFrameLoad(object sender, EventArgs e)
        {
            var pr = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            Text = $"Windows Firewall Automation {pr.IsInRole(WindowsBuiltInRole.Administrator)}";
            fwApplicationRule($"ex:{Application.ExecutablePath}", Application.ExecutablePath, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true);
            //uacStartup();
            initListView();
            for (int i = 0; i <= 3; i++)
                threadStart(i);
        }

        private void initListView()
        {
            MaximizeBox = false;
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width, Height);

            lvScan.MultiSelect = false;
            lvScan.Columns.Add("ApplicationPath", Width - 130);
            lvScan.Columns.Add("Action", 120);

            lvWatcher.MultiSelect = false;
            lvWatcher.Columns.Add("ApplicationPath", Width - 130);
            lvWatcher.Columns.Add("Action", 120);

            lvRule.MultiSelect = false;
            lvRule.Columns.Add("ApplicationPath", Width - 130);
            lvRule.Columns.Add("Action", 120);

            lvExclude.MultiSelect = false;
            lvExclude.Columns.Add("ApplicationPath", Width - 130);
            lvExclude.Columns.Add("Action", 120);
        }
        /*
        private void uacStartup()
        {
            
            TaskService ts = new TaskService();
            TaskDefinition td = ts.NewTask();
            if (!ts.RootFolder.Tasks.Exists("WindowsFirewallAutomation"))
            {
                td.Principal.RunLevel = TaskRunLevel.Highest;
                td.Triggers.AddNew(TaskTriggerType.Logon);
                td.Actions.Add(new ExecAction(Application.ExecutablePath + " -tray", null));
                ts.RootFolder.RegisterTaskDefinition("WindowsFirewallAutomation", td);
                startupToolStripMenuItem.Checked = true;
            }
        }
        */

        #endregion

        #region feature
        private void threadStart(int t)
        {
            switch (t)
            {
                case 1:
                    new Thread(() => { scanProcess(); }).Start();
                    return;

                case 2:
                    new Thread(() => { processWatcher(); }).Start();
                    new Thread(() => { directoryWatcher(); }).Start();
                    return;

                case 3:
                    new Thread(() => { refreshRuleList(); }).Start();
                    return;

                default:
                    new Thread(() => { refreshExcludeList(); }).Start();
                    return;
            }
        }

        #region home

        private void btnScannerClick(object sender, EventArgs e)
        {
            fwTab.SelectedIndex = 1;
        }

        private void btnWatcherClick(object sender, EventArgs e)
        {
            fwTab.SelectedIndex = 2;
        }

        private void btnRuleViewerClick(object sender, EventArgs e)
        {
            fwTab.SelectedIndex = 3;
        }

        private void btnExcludeClick(object sender, EventArgs e)
        {
            fwTab.SelectedIndex = 4;
        }
        #endregion 

        #region scanner
        private void lvScanRefreshClick(object sender, EventArgs e)
        {
            threadStart(1);
        }
        private void scanProcess()
        {
            toolStripButtonEnabled(lvScanRefresh, false);
            clearListView(lvScan);           
            Process[] pList = Process.GetProcesses();
            List<string> pListForRemoveDuplicate = new List<string>();
            foreach (var p in pList)
            {
                try
                {
                    if (p.Id == Process.GetCurrentProcess().Id) continue;
                    if (pListForRemoveDuplicate.Contains(processPath(p.Id).ToLower())) continue;
                    pListForRemoveDuplicate.Add(processPath(p.Id).ToLower());

                    addStrToListView(lvScan, processPath(p.Id),
                                fwApplicationRule($"app:{processPath(p.Id)}", processPath(p.Id),
                                checkSignature(processPath(p.Id)) ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true));
                }
                catch
                {
                    continue;
                }
            }
            toolStripButtonEnabled(lvScanRefresh, true);
            GC.Collect();
        }
        #endregion

        #region watcher

        #region process
        private void processWatcher()
        {
            watch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            watch.EventArrived += new EventArrivedEventHandler(watch_EventArrived);
            watch.Start();
        }
        private void watch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                int pid = int.Parse(e.NewEvent.Properties["ProcessID"].Value.ToString());
                addStrToListView(lvWatcher,processPath(pid),
                                fwApplicationRule($"app:{processPath(pid)}", processPath(pid),
                                checkSignature(processPath(pid)) ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true));

                GC.Collect();
            }
            catch (Exception ex)
            {
                addStrToListView(lvWatcher, ex.Message, e.NewEvent.Properties["ProcessID"].Value.ToString().ToString());
                GC.Collect();
            }
        }
        #endregion

        #region directory
        private void directoryWatcher()
        {
            fsw = new FileSystemWatcher();

            fsw.Filter = "*.exe";
            fsw.Path = @"C:\";
            fsw.IncludeSubdirectories = true;

            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                              | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Created += new FileSystemEventHandler(OnChanged);
            fsw.EnableRaisingEvents = true;
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            addStrToListView(lvWatcher, e.FullPath,
                                fwApplicationRule($"app:{e.FullPath}", e.FullPath,
                                checkSignature(e.FullPath) ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true));
            GC.Collect();
        }
        #endregion

        #endregion

        #region rule_viewer
        private void lvRuleRefreshClick(object sender, EventArgs e)
        {
            threadStart(3);
        }
        private void lvRuleViewerRemove_Click(object sender, EventArgs e)
        {
            if (lvExclude.SelectedItems.Count == 0) return;

            if (fwApplicationRule($"ex:{selectedItem}", selectedItem, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false) == "success")
                lvExclude.SelectedItems[0].Remove();
            else ErrorMsgBox(fwApplicationRule($"ex:{selectedItem}", selectedItem, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false));
        }
        private void refreshRuleList()
        {
            toolStripButtonEnabled(lvRuleViewerRefresh, false);
            clearListView(lvRule);

            try
            {
                Type netFwPolicy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(netFwPolicy);

                foreach (INetFwRule rule in fwPolicy.Rules)
                {
                    if (rule.Name.Contains("app:"))
                    {
                        addStrToListView(lvRule, rule.ApplicationName, rule.Action.ToString().Replace("NET_FW_ACTION_", string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {
                addStrToListView(lvRule, ex.Message, ex.Data.ToString());
            }
            toolStripButtonEnabled(lvRuleViewerRefresh, true);
            GC.Collect();
        }
        #endregion

        #region exclude
        private void lvExcludeRefresh_Click(object sender, EventArgs e)
        {
            threadStart(0);
        }
        private void lvExcludeAdd_Click(object sender, EventArgs e)
        {
            addExclude(1);
        }

        private void lvExcludeAddFolder_Click(object sender, EventArgs e)
        {
            addExclude(3);
        }


        private void lvExcludeRemove_Click(object sender, EventArgs e)
        {
            if (lvExclude.SelectedItems.Count == 0) return;
            if (fwApplicationRule($"ex:{selectedItem}", selectedItem, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false) == "success")
                lvExclude.SelectedItems[0].Remove();
            else ErrorMsgBox(fwApplicationRule($"ex:{selectedItem}", selectedItem, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false));
        }
        private void lvExcludeRemoveAll_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            new Thread(() =>
            {
                excludeToolStrip(false);
               
                foreach (ListViewItem lvi in lvExclude.Items)
                {
                    if (fwApplicationRule($"ex:{lvi.SubItems[0].Text}", lvi.SubItems[0].Text, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false) == "success")
                        removeItemToListView(lvExclude, lvi);

                    else ErrorMsgBox(fwApplicationRule($"ex:{lvi.SubItems[0].Text}", lvi.SubItems[0].Text, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false));
                }
                excludeToolStrip(true);
            }).Start(); 
                
        }
        private void refreshExcludeList()
        {
            excludeToolStrip(false);
            clearListView(lvExclude);
            try
            {
                Type netFwPolicy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(netFwPolicy);

                foreach (INetFwRule rule in fwPolicy.Rules)
                {
                    if (rule.Name.Contains("ex:"))
                    {
                        addStrToListView(lvExclude,rule.ApplicationName, rule.Action.ToString().Replace("NET_FW_ACTION_", string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {
                addStrToListView(lvExclude, ex.Message, ex.Data.ToString());
            }

            excludeToolStrip(true);
            GC.Collect();
        }

        private void excludeToolStrip(bool enabled)
        {
            toolStripButtonEnabled(lvExcludeRefresh, enabled);
            toolStripButtonEnabled(lvExcludeAdd, enabled);
            toolStripButtonEnabled(lvExcludeAddFolder, enabled);
            toolStripButtonEnabled(lvExcludeRemove, enabled);
            toolStripButtonEnabled(lvExcludeRemoveAll, enabled);
        }

        private void addExclude(int m = 1)
        {
            if (m == 1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "exe files|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    addStrToListView(lvExclude, ofd.FileName, fwApplicationRule($"ex:{ofd.FileName}", ofd.FileName,
                     ExcludeMsgBox($"app:{ofd.FileName}") == DialogResult.Yes ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                     NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true), true);
                }
            }
            else if (m == 2)
            {
                
                addStrToListView(lvExclude, selectedItem, fwApplicationRule($"ex:{selectedItem}", selectedItem,
                    ExcludeMsgBox($"app:{selectedItem}") == DialogResult.Yes ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                    NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true), true);
            }
            else
            {
                addExcludeFolder();
            }
        }

        private void addExcludeFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (ExcludeMsgBox($"folder:{fbd.SelectedPath}") == DialogResult.Yes)
                {
                    new Thread(() =>
                    {
                        excludeToolStrip(false);
                        foreach (var file in GetFiles(fbd.SelectedPath, "*.exe"))
                        {
                            addStrToListView(lvExclude, file, fwApplicationRule($"ex:{file}", file, NET_FW_ACTION_.NET_FW_ACTION_ALLOW, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true), true);
                        }
                        excludeToolStrip(true);
                    }).Start();
                }
                else if (ExcludeMsgBox($"folder:{fbd.SelectedPath}") == DialogResult.No)
                {
                    new Thread(() =>
                    {
                        excludeToolStrip(false);
                        foreach (var file in GetFiles(fbd.SelectedPath, "*.exe"))
                        {
                            addStrToListView(lvExclude, file, fwApplicationRule($"ex:{file}", file, NET_FW_ACTION_.NET_FW_ACTION_BLOCK, NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, true), true);
                        }
                        excludeToolStrip(true);
                    }).Start();
                }
                else return;
            }
        }
        #endregion

        #endregion

        #region firewall

        public string fwApplicationRule(string ruleName, string filePath, NET_FW_ACTION_ fwAction, NET_FW_RULE_DIRECTION_ fwDirection, bool isAddRule)
        {
            if (isAddRule)
            {
               if (isApplicationRuleExists(filePath, fwAction, true)) return "Exclude";
                if (isApplicationRuleExists(filePath, fwAction)) return fwAction.ToString().Replace("NET_FW_ACTION_", string.Empty);
            }
            try
            {
                INetFwRule fwRule = (INetFwRule)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FWRule"));
                fwRule.Action = fwAction;
                fwRule.Enabled = true;
                fwRule.InterfaceTypes = "All";
                fwRule.Name = ruleName.ToLower();
                fwRule.ApplicationName = filePath.ToLower();
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                fwRule.Direction = fwDirection;


                if (isAddRule)
                {
                    fwPolicy.Rules.Add(fwRule);
                    return fwRule.Action.ToString().Replace("NET_FW_ACTION_", string.Empty);
                }
                else
                {
                    fwPolicy.Rules.Remove(fwRule.Name);
                    return "success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private bool isApplicationRuleExists(string filePath, NET_FW_ACTION_ fwAction, bool isExRule = false)
        {
            try
            {

                Type netFwPolicy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(netFwPolicy);
                if (isExRule)
                {
                    foreach (INetFwRule rule in fwPolicy.Rules)
                    {
                        if (rule.ApplicationName.ToLower() == filePath.ToLower()
                     && rule.Name.Contains("ex:"))
                            return true;
                    }

                }
                else
                {
                    foreach (INetFwRule rule in fwPolicy.Rules)
                    {

                        if (rule.ApplicationName.ToLower() == filePath.ToLower()
                                && rule.Action == fwAction)
                            return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region control

        #region listView
        private void addStrToListView(ListView lv, string n, string s, bool isExclude = false)
        {
            try
            {
                if (isExclude && isApplicationRuleExists(n, (s == "ALLOW") ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK))
                    fwApplicationRule($"app:{n}", n, (s == "ALLOW") ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                     NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT, false);

                string[] rows = { n, s };
                ListViewItem lvi = new ListViewItem(rows);
                addItemToListView(lv, lvi);
            }
            catch (Exception ex)
            {
                string[] rows = { ex.Message, ex.Data.ToString() };
                ListViewItem lvi = new ListViewItem(rows);
                addItemToListView(lv, lvi);
                return;
            }
        }
        private delegate void addToListViewDelegate(ListView lv, ListViewItem lvi);
        private void addItemToListView(ListView lv, ListViewItem lvi)
        {
            if (lv.InvokeRequired)
            {
                Invoke(new addToListViewDelegate(addItemToListView), new object[] { lv, lvi });
                return;
            }
            lv.Items.Add(lvi);
        }
        private void lvScan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvScan.SelectedItems.Count == 0) return;
            selectedItem = lvScan.SelectedItems[0].Text;
        }

        private void lvWatcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWatcher.SelectedItems.Count == 0) return;
            selectedItem = lvWatcher.SelectedItems[0].Text;
        }
        private void lvRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWatcher.SelectedItems.Count == 0) return;
            selectedItem = lvWatcher.SelectedItems[0].Text;
        }
        private void lvExclude_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvExclude.SelectedItems.Count == 0) return;
            selectedItem = lvExclude.SelectedItems[0].Text;
        }

        private void clearListView(ListView lv)
        {
            Invoke(new MethodInvoker(
                () =>
                {
                    lv.Items.Clear();
                }));
        }
        private delegate void removeToListViewDelegate(ListView lv, ListViewItem lvi);
        private void removeItemToListView(ListView lv, ListViewItem lvi)
        {
            if (lv.InvokeRequired)
            {
                Invoke(new removeToListViewDelegate(removeItemToListView), new object[] { lv, lvi });
                return;
            }
            lv.Items.Remove(lvi);
        }
        #endregion

        #region tray
        private void tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            Activate();
            Focus();
        }

        private void MainFrameClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                tray.ShowBalloonTip(3000, "WFA", "WFA moved to the tray.", ToolTipIcon.Info);

            }
        }

        private void MainFrameMove(object sender, EventArgs e)
        {
            if (this == null)
            {
                return;
            }
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                tray.ShowBalloonTip(3000, "WFA", "WFA moved to the tray.", ToolTipIcon.Info);
            }
            else
            {
                Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            watch.Stop();
            watch.Dispose();

            fsw.EnableRaisingEvents = false;
            fsw.Dispose();

            tray.Visible = false;
            tray.Icon = null;
            tray.Dispose();

            Environment.Exit(0);
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*startupToolStripMenuItem.Checked = false;
            TaskService ts = new TaskService();
            ts.RootFolder.DeleteTask("WindowsFirewallAutomation");*/
        }
        #endregion

        #region context
        private void addExcludeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addExclude(2);
        }
        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(getFolderPath(selectedItem));
        }

        private void virustotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchVirustotal(getFileHash(selectedItem));
        }

        #endregion

        private void toolStripButtonEnabled(ToolStripButton t, bool enabled)
        {
            Invoke(new MethodInvoker(
                () =>
                {
                    t.Enabled = enabled;
                }));
        }

        #endregion

        #region etc
        private bool checkSignature(string fileName)
        {
            var certChain = new X509Chain();
            var cert = default(X509Certificate2);
            bool isChainValid = false;
            try
            {
                var signer = X509Certificate.CreateFromSignedFile(fileName);
                cert = new X509Certificate2(signer);
            }
            catch
            {
                return isChainValid;
            }

            certChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            certChain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
            certChain.ChainPolicy.UrlRetrieval‎Timeout = new TimeSpan(0, 1, 0);
            certChain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
            isChainValid = certChain.Build(cert);

            return isChainValid;
        }
        private string processPath(int pid)
        {
            return Process.GetProcessById(pid).MainModule.FileName;
        }

        private void searchVirustotal(string q)
        {
            try
            {
                Process.Start($"https://www.virustotal.com/ko/file/{q}/analysis/");
            }
            catch (Exception ex)
            {
                ErrorMsgBox(ex.Message);
            }
        }
        private string getFolderPath(string fileName)
        {
            try
            {
                return Path.GetDirectoryName(fileName);
            }
            catch (Exception ex)
            {
                ErrorMsgBox(ex.Message);
                return string.Empty;
            }
        }
        private string getFileHash(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.OpenOrCreate,
            FileAccess.Read);
            using (var bufferedStream = new BufferedStream(fileStream, 1024 * 32))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(bufferedStream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }

        }
        private IEnumerable<string> GetFiles(string path, string exts)
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue(path);
            while (q.Count > 0)
            {
                path = q.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        q.Enqueue(subDir);
                    }
                }
                catch
                {

                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path, exts);
                }
                catch
                {

                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
        private void ErrorMsgBox(string msg)
        {
            MessageBox.Show(msg, "WFA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult ExcludeMsgBox(string msg)
        {
            return MessageBox.Show($"{msg}\nYes:Always ALLOW No:Always BLOCK",
                       "WFA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        #endregion
    }
}
