using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFirewallAutomation
{
    internal class AeroListView : ListView
    {
        private const uint WM_CHANGEUISTATE = 0x127;

        private const int UIS_SET = 1;
        private const int UISF_HIDEFOCUS = 0x1;

        private ListViewColumnSorter LvwColumnSorter { get; set; }

        public AeroListView()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            LvwColumnSorter = new ListViewColumnSorter();
            ListViewItemSorter = LvwColumnSorter;
            View = View.Details;
            FullRowSelect = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (PlatformHelper.RunningOnMono) return;

            if (PlatformHelper.VistaOrHigher)
            {
                NativeMethods.SetWindowTheme(Handle, "explorer", null);
            }

            if (PlatformHelper.XpOrHigher)
            {
                NativeMethods.SendMessage(Handle, WM_CHANGEUISTATE,
                    NativeMethodsHelper.MakeLong(UIS_SET, UISF_HIDEFOCUS), 0);
            }
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            if (e.Column == LvwColumnSorter.SortColumn)
            {
                LvwColumnSorter.Order = (LvwColumnSorter.Order == SortOrder.Ascending)
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                LvwColumnSorter.SortColumn = e.Column;
                LvwColumnSorter.Order = SortOrder.Ascending;
            }

            Sort();
        }
    }
    public class ListViewColumnSorter : IComparer
    {
        private int _columnToSort;

        private SortOrder _orderOfSort;

        private readonly CaseInsensitiveComparer _objectCompare;

        public ListViewColumnSorter()
        {
            _columnToSort = 0;

            _orderOfSort = SortOrder.None;

            _objectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            var listviewX = (ListViewItem)x;
            var listviewY = (ListViewItem)y;

            if (listviewX.SubItems[0].Text == ".." || listviewY.SubItems[0].Text == "..")
                return 0;

            var compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text,
                listviewY.SubItems[_columnToSort].Text);

            if (_orderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (_orderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        public int SortColumn
        {
            set { _columnToSort = value; }
            get { return _columnToSort; }
        }

        public SortOrder Order
        {
            set { _orderOfSort = value; }
            get { return _orderOfSort; }
        }
    }

    public static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns;
            public IntPtr puColumns;
        };
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageLVItem(IntPtr hWnd, int msg, int wParam, ref LVITEM lvi);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    }

    public static class NativeMethodsHelper
    {
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETITEMSTATE = LVM_FIRST + 43;

        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        public static int MakeLong(int wLow, int wHigh)
        {
            int low = (int)IntLoWord(wLow);
            short high = IntLoWord(wHigh);
            int product = 0x10000 * (int)high;
            int mkLong = (int)(low | product);
            return mkLong;
        }

        private static short IntLoWord(int word)
        {
            return (short)(word & short.MaxValue);
        }

        public static void SetItemState(IntPtr handle, int itemIndex, int mask, int value)
        {
            NativeMethods.LVITEM lvItem = new NativeMethods.LVITEM
            {
                stateMask = mask,
                state = value
            };
            NativeMethods.SendMessageLVItem(handle, LVM_SETITEMSTATE, itemIndex, ref lvItem);
        }

        public static void ScrollToBottom(IntPtr handle)
        {
            NativeMethods.SendMessage(handle, WM_VSCROLL, SB_PAGEBOTTOM, 0);
        }
    }

    public static class PlatformHelper
    {
        static PlatformHelper()
        {
            Win32NT = Environment.OSVersion.Platform == PlatformID.Win32NT;
            XpOrHigher = Win32NT && Environment.OSVersion.Version.Major >= 5;
            VistaOrHigher = Win32NT && Environment.OSVersion.Version.Major >= 6;
            SevenOrHigher = Win32NT && (Environment.OSVersion.Version >= new Version(6, 1));
            EightOrHigher = Win32NT && (Environment.OSVersion.Version >= new Version(6, 2, 9200));
            EightPointOneOrHigher = Win32NT && (Environment.OSVersion.Version >= new Version(6, 3));
            TenOrHigher = Win32NT && (Environment.OSVersion.Version >= new Version(10, 0));
            RunningOnMono = Type.GetType("Mono.Runtime") != null;
        }

        public static bool RunningOnMono { get; private set; }

        public static bool Win32NT { get; private set; }

        public static bool XpOrHigher { get; private set; }

        public static bool VistaOrHigher { get; private set; }

        public static bool SevenOrHigher { get; private set; }

        public static bool EightOrHigher { get; private set; }

        public static bool EightPointOneOrHigher { get; private set; }

        public static bool TenOrHigher { get; private set; }
    }
}
