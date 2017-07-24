namespace WindowsFirewallAutomation
{
    partial class MainFrame
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.fwTab = new WindowsFirewallAutomation.FlatTabControl();
            this.tabHOME = new System.Windows.Forms.TabPage();
            this.btnExclude = new System.Windows.Forms.Button();
            this.btnRuleViewer = new System.Windows.Forms.Button();
            this.btnWatcher = new System.Windows.Forms.Button();
            this.btnScanner = new System.Windows.Forms.Button();
            this.tabScanner = new System.Windows.Forms.TabPage();
            this.scannerToolStrip = new System.Windows.Forms.ToolStrip();
            this.lvScanRefresh = new System.Windows.Forms.ToolStripButton();
            this.lvScan = new WindowsFirewallAutomation.AeroListView();
            this.lvMenuStrip = new WindowsFirewallAutomation.FlatContextMenuStrip();
            this.addExcludeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virustotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabWatcher = new System.Windows.Forms.TabPage();
            this.lvWatcher = new WindowsFirewallAutomation.AeroListView();
            this.tabRuleViewer = new System.Windows.Forms.TabPage();
            this.ruleToolStrip = new System.Windows.Forms.ToolStrip();
            this.lvRuleViewerRefresh = new System.Windows.Forms.ToolStripButton();
            this.lvRuleViewerRemove = new System.Windows.Forms.ToolStripButton();
            this.lvRule = new WindowsFirewallAutomation.AeroListView();
            this.tabExclude = new System.Windows.Forms.TabPage();
            this.exToolStrip = new System.Windows.Forms.ToolStrip();
            this.lvExcludeRefresh = new System.Windows.Forms.ToolStripButton();
            this.lvExcludeAddFolder = new System.Windows.Forms.ToolStripButton();
            this.lvExcludeAdd = new System.Windows.Forms.ToolStripButton();
            this.lvExcludeRemove = new System.Windows.Forms.ToolStripButton();
            this.lvExcludeRemoveAll = new System.Windows.Forms.ToolStripButton();
            this.lvExclude = new WindowsFirewallAutomation.AeroListView();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fwTab.SuspendLayout();
            this.tabHOME.SuspendLayout();
            this.tabScanner.SuspendLayout();
            this.scannerToolStrip.SuspendLayout();
            this.lvMenuStrip.SuspendLayout();
            this.tabWatcher.SuspendLayout();
            this.tabRuleViewer.SuspendLayout();
            this.ruleToolStrip.SuspendLayout();
            this.tabExclude.SuspendLayout();
            this.exToolStrip.SuspendLayout();
            this.trayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fwTab
            // 
            this.fwTab.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.fwTab.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.fwTab.Controls.Add(this.tabHOME);
            this.fwTab.Controls.Add(this.tabScanner);
            this.fwTab.Controls.Add(this.tabWatcher);
            this.fwTab.Controls.Add(this.tabRuleViewer);
            this.fwTab.Controls.Add(this.tabExclude);
            this.fwTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fwTab.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fwTab.ItemSize = new System.Drawing.Size(130, 40);
            this.fwTab.Location = new System.Drawing.Point(0, 0);
            this.fwTab.Name = "fwTab";
            this.fwTab.SelectedIndex = 0;
            this.fwTab.Size = new System.Drawing.Size(661, 459);
            this.fwTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.fwTab.TabIndex = 0;
            // 
            // tabHOME
            // 
            this.tabHOME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabHOME.Controls.Add(this.btnExclude);
            this.tabHOME.Controls.Add(this.btnRuleViewer);
            this.tabHOME.Controls.Add(this.btnWatcher);
            this.tabHOME.Controls.Add(this.btnScanner);
            this.tabHOME.Location = new System.Drawing.Point(4, 44);
            this.tabHOME.Name = "tabHOME";
            this.tabHOME.Padding = new System.Windows.Forms.Padding(3);
            this.tabHOME.Size = new System.Drawing.Size(653, 411);
            this.tabHOME.TabIndex = 0;
            this.tabHOME.Text = "HOME";
            // 
            // btnExclude
            // 
            this.btnExclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnExclude.BackgroundImage = global::WindowsFirewallAutomation.Properties.Resources.trust;
            this.btnExclude.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExclude.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExclude.Location = new System.Drawing.Point(328, 208);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(317, 196);
            this.btnExclude.TabIndex = 3;
            this.btnExclude.UseVisualStyleBackColor = false;
            this.btnExclude.Click += new System.EventHandler(this.btnExcludeClick);
            // 
            // btnRuleViewer
            // 
            this.btnRuleViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnRuleViewer.BackgroundImage = global::WindowsFirewallAutomation.Properties.Resources.list;
            this.btnRuleViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRuleViewer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRuleViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuleViewer.Location = new System.Drawing.Point(8, 208);
            this.btnRuleViewer.Name = "btnRuleViewer";
            this.btnRuleViewer.Size = new System.Drawing.Size(317, 196);
            this.btnRuleViewer.TabIndex = 2;
            this.btnRuleViewer.UseVisualStyleBackColor = false;
            this.btnRuleViewer.Click += new System.EventHandler(this.btnRuleViewerClick);
            // 
            // btnWatcher
            // 
            this.btnWatcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnWatcher.BackgroundImage = global::WindowsFirewallAutomation.Properties.Resources.eye;
            this.btnWatcher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnWatcher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWatcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWatcher.Location = new System.Drawing.Point(328, 6);
            this.btnWatcher.Name = "btnWatcher";
            this.btnWatcher.Size = new System.Drawing.Size(317, 196);
            this.btnWatcher.TabIndex = 1;
            this.btnWatcher.UseVisualStyleBackColor = false;
            this.btnWatcher.Click += new System.EventHandler(this.btnWatcherClick);
            // 
            // btnScanner
            // 
            this.btnScanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnScanner.BackgroundImage = global::WindowsFirewallAutomation.Properties.Resources.search;
            this.btnScanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnScanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanner.Location = new System.Drawing.Point(6, 6);
            this.btnScanner.Name = "btnScanner";
            this.btnScanner.Size = new System.Drawing.Size(319, 196);
            this.btnScanner.TabIndex = 0;
            this.btnScanner.UseVisualStyleBackColor = false;
            this.btnScanner.Click += new System.EventHandler(this.btnScannerClick);
            // 
            // tabScanner
            // 
            this.tabScanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabScanner.Controls.Add(this.scannerToolStrip);
            this.tabScanner.Controls.Add(this.lvScan);
            this.tabScanner.Location = new System.Drawing.Point(4, 44);
            this.tabScanner.Name = "tabScanner";
            this.tabScanner.Padding = new System.Windows.Forms.Padding(3);
            this.tabScanner.Size = new System.Drawing.Size(653, 411);
            this.tabScanner.TabIndex = 1;
            this.tabScanner.Text = "Scanner";
            // 
            // scannerToolStrip
            // 
            this.scannerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvScanRefresh});
            this.scannerToolStrip.Location = new System.Drawing.Point(3, 3);
            this.scannerToolStrip.Name = "scannerToolStrip";
            this.scannerToolStrip.Size = new System.Drawing.Size(647, 25);
            this.scannerToolStrip.TabIndex = 4;
            // 
            // lvScanRefresh
            // 
            this.lvScanRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvScanRefresh.Image = global::WindowsFirewallAutomation.Properties.Resources.refresh;
            this.lvScanRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvScanRefresh.Name = "lvScanRefresh";
            this.lvScanRefresh.Size = new System.Drawing.Size(23, 22);
            this.lvScanRefresh.Text = "Refresh";
            this.lvScanRefresh.Click += new System.EventHandler(this.lvScanRefreshClick);
            // 
            // lvScan
            // 
            this.lvScan.BackColor = System.Drawing.Color.White;
            this.lvScan.ContextMenuStrip = this.lvMenuStrip;
            this.lvScan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvScan.FullRowSelect = true;
            this.lvScan.Location = new System.Drawing.Point(3, 24);
            this.lvScan.Name = "lvScan";
            this.lvScan.Size = new System.Drawing.Size(647, 384);
            this.lvScan.TabIndex = 0;
            this.lvScan.UseCompatibleStateImageBehavior = false;
            this.lvScan.View = System.Windows.Forms.View.Details;
            this.lvScan.SelectedIndexChanged += new System.EventHandler(this.lvScan_SelectedIndexChanged);
            // 
            // lvMenuStrip
            // 
            this.lvMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lvMenuStrip.ForeColor = System.Drawing.Color.White;
            this.lvMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExcludeToolStripMenuItem,
            this.openInExplorerToolStripMenuItem,
            this.virustotalToolStripMenuItem});
            this.lvMenuStrip.Name = "lvMenuStrip";
            this.lvMenuStrip.ShowImageMargin = false;
            this.lvMenuStrip.Size = new System.Drawing.Size(137, 70);
            // 
            // addExcludeToolStripMenuItem
            // 
            this.addExcludeToolStripMenuItem.Name = "addExcludeToolStripMenuItem";
            this.addExcludeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addExcludeToolStripMenuItem.Text = "&Add Exclude";
            this.addExcludeToolStripMenuItem.Click += new System.EventHandler(this.addExcludeToolStripMenuItem_Click);
            // 
            // openInExplorerToolStripMenuItem
            // 
            this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openInExplorerToolStripMenuItem.Text = "&Open in Explorer";
            this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem_Click);
            // 
            // virustotalToolStripMenuItem
            // 
            this.virustotalToolStripMenuItem.Name = "virustotalToolStripMenuItem";
            this.virustotalToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.virustotalToolStripMenuItem.Text = "&Virustotal";
            this.virustotalToolStripMenuItem.Click += new System.EventHandler(this.virustotalToolStripMenuItem_Click);
            // 
            // tabWatcher
            // 
            this.tabWatcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabWatcher.Controls.Add(this.lvWatcher);
            this.tabWatcher.Location = new System.Drawing.Point(4, 44);
            this.tabWatcher.Name = "tabWatcher";
            this.tabWatcher.Padding = new System.Windows.Forms.Padding(3);
            this.tabWatcher.Size = new System.Drawing.Size(653, 411);
            this.tabWatcher.TabIndex = 2;
            this.tabWatcher.Text = "Watcher";
            // 
            // lvWatcher
            // 
            this.lvWatcher.BackColor = System.Drawing.Color.White;
            this.lvWatcher.ContextMenuStrip = this.lvMenuStrip;
            this.lvWatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWatcher.FullRowSelect = true;
            this.lvWatcher.Location = new System.Drawing.Point(3, 3);
            this.lvWatcher.Name = "lvWatcher";
            this.lvWatcher.Size = new System.Drawing.Size(647, 405);
            this.lvWatcher.TabIndex = 1;
            this.lvWatcher.UseCompatibleStateImageBehavior = false;
            this.lvWatcher.View = System.Windows.Forms.View.Details;
            this.lvWatcher.SelectedIndexChanged += new System.EventHandler(this.lvWatcher_SelectedIndexChanged);
            // 
            // tabRuleViewer
            // 
            this.tabRuleViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabRuleViewer.Controls.Add(this.ruleToolStrip);
            this.tabRuleViewer.Controls.Add(this.lvRule);
            this.tabRuleViewer.Location = new System.Drawing.Point(4, 44);
            this.tabRuleViewer.Name = "tabRuleViewer";
            this.tabRuleViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabRuleViewer.Size = new System.Drawing.Size(653, 411);
            this.tabRuleViewer.TabIndex = 3;
            this.tabRuleViewer.Text = "Rule Viewer";
            // 
            // ruleToolStrip
            // 
            this.ruleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvRuleViewerRefresh,
            this.lvRuleViewerRemove});
            this.ruleToolStrip.Location = new System.Drawing.Point(3, 3);
            this.ruleToolStrip.Name = "ruleToolStrip";
            this.ruleToolStrip.Size = new System.Drawing.Size(647, 25);
            this.ruleToolStrip.TabIndex = 4;
            this.ruleToolStrip.Text = "toolStrip2";
            // 
            // lvRuleViewerRefresh
            // 
            this.lvRuleViewerRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvRuleViewerRefresh.Image = global::WindowsFirewallAutomation.Properties.Resources.refresh;
            this.lvRuleViewerRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvRuleViewerRefresh.Name = "lvRuleViewerRefresh";
            this.lvRuleViewerRefresh.Size = new System.Drawing.Size(23, 22);
            this.lvRuleViewerRefresh.Text = "Refresh";
            this.lvRuleViewerRefresh.Click += new System.EventHandler(this.lvRuleRefreshClick);
            // 
            // lvRuleViewerRemove
            // 
            this.lvRuleViewerRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvRuleViewerRemove.Image = global::WindowsFirewallAutomation.Properties.Resources.delete;
            this.lvRuleViewerRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvRuleViewerRemove.Name = "lvRuleViewerRemove";
            this.lvRuleViewerRemove.Size = new System.Drawing.Size(23, 22);
            this.lvRuleViewerRemove.Text = "Remove";
            this.lvRuleViewerRemove.Click += new System.EventHandler(this.lvRuleViewerRemove_Click);
            // 
            // lvRule
            // 
            this.lvRule.BackColor = System.Drawing.Color.White;
            this.lvRule.ContextMenuStrip = this.lvMenuStrip;
            this.lvRule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvRule.FullRowSelect = true;
            this.lvRule.Location = new System.Drawing.Point(3, 24);
            this.lvRule.Name = "lvRule";
            this.lvRule.Size = new System.Drawing.Size(647, 384);
            this.lvRule.TabIndex = 2;
            this.lvRule.UseCompatibleStateImageBehavior = false;
            this.lvRule.View = System.Windows.Forms.View.Details;
            this.lvRule.SelectedIndexChanged += new System.EventHandler(this.lvRule_SelectedIndexChanged);
            // 
            // tabExclude
            // 
            this.tabExclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabExclude.Controls.Add(this.exToolStrip);
            this.tabExclude.Controls.Add(this.lvExclude);
            this.tabExclude.Location = new System.Drawing.Point(4, 44);
            this.tabExclude.Name = "tabExclude";
            this.tabExclude.Padding = new System.Windows.Forms.Padding(3);
            this.tabExclude.Size = new System.Drawing.Size(653, 411);
            this.tabExclude.TabIndex = 4;
            this.tabExclude.Text = "Exclude";
            // 
            // exToolStrip
            // 
            this.exToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvExcludeRefresh,
            this.lvExcludeAddFolder,
            this.lvExcludeAdd,
            this.lvExcludeRemove,
            this.lvExcludeRemoveAll});
            this.exToolStrip.Location = new System.Drawing.Point(3, 3);
            this.exToolStrip.Name = "exToolStrip";
            this.exToolStrip.Size = new System.Drawing.Size(647, 25);
            this.exToolStrip.TabIndex = 3;
            this.exToolStrip.Text = "toolStrip1";
            // 
            // lvExcludeRefresh
            // 
            this.lvExcludeRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvExcludeRefresh.Image = global::WindowsFirewallAutomation.Properties.Resources.refresh;
            this.lvExcludeRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvExcludeRefresh.Name = "lvExcludeRefresh";
            this.lvExcludeRefresh.Size = new System.Drawing.Size(23, 22);
            this.lvExcludeRefresh.Text = "Refresh";
            this.lvExcludeRefresh.Click += new System.EventHandler(this.lvExcludeRefresh_Click);
            // 
            // lvExcludeAddFolder
            // 
            this.lvExcludeAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvExcludeAddFolder.Image = global::WindowsFirewallAutomation.Properties.Resources.addFolder;
            this.lvExcludeAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvExcludeAddFolder.Name = "lvExcludeAddFolder";
            this.lvExcludeAddFolder.Size = new System.Drawing.Size(23, 22);
            this.lvExcludeAddFolder.Text = "Add Folder";
            this.lvExcludeAddFolder.Click += new System.EventHandler(this.lvExcludeAddFolder_Click);
            // 
            // lvExcludeAdd
            // 
            this.lvExcludeAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvExcludeAdd.Image = global::WindowsFirewallAutomation.Properties.Resources.add;
            this.lvExcludeAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvExcludeAdd.Name = "lvExcludeAdd";
            this.lvExcludeAdd.Size = new System.Drawing.Size(23, 22);
            this.lvExcludeAdd.Text = "Add";
            this.lvExcludeAdd.Click += new System.EventHandler(this.lvExcludeAdd_Click);
            // 
            // lvExcludeRemove
            // 
            this.lvExcludeRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvExcludeRemove.Image = global::WindowsFirewallAutomation.Properties.Resources.delete;
            this.lvExcludeRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvExcludeRemove.Name = "lvExcludeRemove";
            this.lvExcludeRemove.Size = new System.Drawing.Size(23, 22);
            this.lvExcludeRemove.Text = "Remove";
            this.lvExcludeRemove.Click += new System.EventHandler(this.lvExcludeRemove_Click);
            // 
            // lvExcludeRemoveAll
            // 
            this.lvExcludeRemoveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lvExcludeRemoveAll.Image = global::WindowsFirewallAutomation.Properties.Resources.reset;
            this.lvExcludeRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lvExcludeRemoveAll.Name = "lvExcludeRemoveAll";
            this.lvExcludeRemoveAll.Size = new System.Drawing.Size(23, 22);
            this.lvExcludeRemoveAll.Text = "Reset";
            this.lvExcludeRemoveAll.Click += new System.EventHandler(this.lvExcludeRemoveAll_Click);
            // 
            // lvExclude
            // 
            this.lvExclude.BackColor = System.Drawing.Color.White;
            this.lvExclude.ContextMenuStrip = this.lvMenuStrip;
            this.lvExclude.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvExclude.FullRowSelect = true;
            this.lvExclude.Location = new System.Drawing.Point(3, 24);
            this.lvExclude.Name = "lvExclude";
            this.lvExclude.Size = new System.Drawing.Size(647, 384);
            this.lvExclude.TabIndex = 2;
            this.lvExclude.UseCompatibleStateImageBehavior = false;
            this.lvExclude.View = System.Windows.Forms.View.Details;
            this.lvExclude.SelectedIndexChanged += new System.EventHandler(this.lvExclude_SelectedIndexChanged);
            // 
            // tray
            // 
            this.tray.ContextMenuStrip = this.trayMenuStrip;
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "notifyIcon1";
            this.tray.Visible = true;
            this.tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tray_MouseDoubleClick);
            // 
            // trayMenuStrip
            // 
            this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startupToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayMenuStrip.Name = "trayMenuStrip";
            this.trayMenuStrip.Size = new System.Drawing.Size(114, 48);
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.startupToolStripMenuItem.Text = "&Startup";
            this.startupToolStripMenuItem.Click += new System.EventHandler(this.startupToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 459);
            this.Controls.Add(this.fwTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrame";
            this.Text = "Windows Firewall Automation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrameClosing);
            this.Load += new System.EventHandler(this.MainFrameLoad);
            this.Move += new System.EventHandler(this.MainFrameMove);
            this.fwTab.ResumeLayout(false);
            this.tabHOME.ResumeLayout(false);
            this.tabScanner.ResumeLayout(false);
            this.tabScanner.PerformLayout();
            this.scannerToolStrip.ResumeLayout(false);
            this.scannerToolStrip.PerformLayout();
            this.lvMenuStrip.ResumeLayout(false);
            this.tabWatcher.ResumeLayout(false);
            this.tabRuleViewer.ResumeLayout(false);
            this.tabRuleViewer.PerformLayout();
            this.ruleToolStrip.ResumeLayout(false);
            this.ruleToolStrip.PerformLayout();
            this.tabExclude.ResumeLayout(false);
            this.tabExclude.PerformLayout();
            this.exToolStrip.ResumeLayout(false);
            this.exToolStrip.PerformLayout();
            this.trayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatTabControl fwTab;
        private System.Windows.Forms.TabPage tabHOME;
        private System.Windows.Forms.TabPage tabScanner;
        private AeroListView lvScan;
        private System.Windows.Forms.TabPage tabWatcher;
        private AeroListView lvWatcher;
        private System.Windows.Forms.TabPage tabRuleViewer;
        private System.Windows.Forms.TabPage tabExclude;
        private AeroListView lvRule;
        private AeroListView lvExclude;
        private System.Windows.Forms.Button btnScanner;
        private System.Windows.Forms.Button btnExclude;
        private System.Windows.Forms.Button btnRuleViewer;
        private System.Windows.Forms.Button btnWatcher;
        private FlatContextMenuStrip lvMenuStrip;
        private System.Windows.Forms.ToolStrip scannerToolStrip;
        private System.Windows.Forms.ToolStripButton lvScanRefresh;
        private System.Windows.Forms.ToolStrip ruleToolStrip;
        private System.Windows.Forms.ToolStripButton lvRuleViewerRefresh;
        private System.Windows.Forms.ToolStripButton lvRuleViewerRemove;
        private System.Windows.Forms.ToolStrip exToolStrip;
        private System.Windows.Forms.ToolStripButton lvExcludeRefresh;
        private System.Windows.Forms.ToolStripButton lvExcludeAdd;
        private System.Windows.Forms.ToolStripButton lvExcludeRemove;
        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip trayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addExcludeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem virustotalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton lvExcludeAddFolder;
        private System.Windows.Forms.ToolStripButton lvExcludeRemoveAll;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
    }
}

