namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTrack = new System.Windows.Forms.Label();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.btnTrack = new System.Windows.Forms.Button();
            this.lblTrackResult = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.lvRequests = new System.Windows.Forms.ListView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.cboNewStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.tabUrgent = new System.Windows.Forms.TabPage();
            this.lvUrgent = new System.Windows.Forms.ListView();
            this.lblUrgentInfo = new System.Windows.Forms.Label();
            this.tabRelated = new System.Windows.Forms.TabPage();
            this.txtRelated = new System.Windows.Forms.TextBox();
            this.pnlRelatedTop = new System.Windows.Forms.Panel();
            this.lblPick = new System.Windows.Forms.Label();
            this.cboRelated = new System.Windows.Forms.ComboBox();
            this.btnBfs = new System.Windows.Forms.Button();
            this.btnDfs = new System.Windows.Forms.Button();
            this.tabRoute = new System.Windows.Forms.TabPage();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.pnlRouteTop = new System.Windows.Forms.Panel();
            this.lblRouteInfo = new System.Windows.Forms.Label();
            this.btnKruskal = new System.Windows.Forms.Button();
            this.btnPrim = new System.Windows.Forms.Button();
            this.tabInsights = new System.Windows.Forms.TabPage();
            this.txtInsights = new System.Windows.Forms.TextBox();
            this.pnlInsightsTop = new System.Windows.Forms.Panel();
            this.btnRefreshInsights = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlUpdate.SuspendLayout();
            this.tabUrgent.SuspendLayout();
            this.tabRelated.SuspendLayout();
            this.pnlRelatedTop.SuspendLayout();
            this.tabRoute.SuspendLayout();
            this.pnlRouteTop.SuspendLayout();
            this.tabInsights.SuspendLayout();
            this.pnlInsightsTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1180, 78);
            this.pnlHeader.TabIndex = 2;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 37);
            this.lblTitle.Text = "Service Request Status";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(226, 239, 255);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 46);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 19);
            this.lblSubtitle.Text = "Track your requests, see what is most urgent and how requests relate";

            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            this.btnBack.Location = new System.Drawing.Point(1016, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 36);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblTrack);
            this.pnlToolbar.Controls.Add(this.txtTrack);
            this.pnlToolbar.Controls.Add(this.btnTrack);
            this.pnlToolbar.Controls.Add(this.lblTrackResult);
            this.pnlToolbar.Controls.Add(this.lblCategory);
            this.pnlToolbar.Controls.Add(this.cboCategory);
            this.pnlToolbar.Controls.Add(this.lblStatusFilter);
            this.pnlToolbar.Controls.Add(this.cboStatus);
            this.pnlToolbar.Controls.Add(this.lblSort);
            this.pnlToolbar.Controls.Add(this.cboSort);
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 78);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1180, 112);
            this.pnlToolbar.TabIndex = 1;

            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTrack.Location = new System.Drawing.Point(20, 12);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(340, 19);
            this.lblTrack.Text = "Track a request by its unique ID (for example SR-1003):";

            // 
            // txtTrack
            // 
            this.txtTrack.Location = new System.Drawing.Point(20, 38);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.Size = new System.Drawing.Size(220, 25);
            this.txtTrack.TabIndex = 0;
            this.txtTrack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrack_KeyDown);

            // 
            // btnTrack
            // 
            this.btnTrack.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            this.btnTrack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrack.FlatAppearance.BorderSize = 0;
            this.btnTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrack.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnTrack.ForeColor = System.Drawing.Color.White;
            this.btnTrack.Location = new System.Drawing.Point(252, 35);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(130, 30);
            this.btnTrack.TabIndex = 1;
            this.btnTrack.Text = "Track Request";
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);

            // 
            // lblTrackResult
            // 
            this.lblTrackResult.AutoSize = true;
            this.lblTrackResult.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTrackResult.Location = new System.Drawing.Point(396, 41);
            this.lblTrackResult.Name = "lblTrackResult";
            this.lblTrackResult.Size = new System.Drawing.Size(0, 19);

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblCategory.Location = new System.Drawing.Point(20, 79);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 19);
            this.lblCategory.Text = "Category";

            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(92, 75);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 25);
            this.cboCategory.TabIndex = 2;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblStatusFilter.Location = new System.Drawing.Point(312, 79);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(44, 19);
            this.lblStatusFilter.Text = "Status";

            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(366, 75);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(160, 25);
            this.cboStatus.TabIndex = 3;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSort.Location = new System.Drawing.Point(546, 79);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(50, 19);
            this.lblSort.Text = "Sort by";

            // 
            // cboSort
            // 
            this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSort.Location = new System.Drawing.Point(606, 75);
            this.cboSort.Name = "cboSort";
            this.cboSort.Size = new System.Drawing.Size(250, 25);
            this.cboSort.TabIndex = 4;
            this.cboSort.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Location = new System.Drawing.Point(876, 79);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 19);

            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabAll);
            this.tabs.Controls.Add(this.tabUrgent);
            this.tabs.Controls.Add(this.tabRelated);
            this.tabs.Controls.Add(this.tabRoute);
            this.tabs.Controls.Add(this.tabInsights);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 190);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1180, 550);
            this.tabs.TabIndex = 0;

            // 
            // tabAll
            // 
            this.tabAll.BackColor = System.Drawing.Color.White;
            this.tabAll.Controls.Add(this.lvRequests);
            this.tabAll.Controls.Add(this.pnlDetails);
            this.tabAll.Location = new System.Drawing.Point(4, 26);
            this.tabAll.Name = "tabAll";
            this.tabAll.Size = new System.Drawing.Size(1172, 520);
            this.tabAll.Text = "All Requests";

            // 
            // lvRequests
            // 
            this.lvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRequests.FullRowSelect = true;
            this.lvRequests.GridLines = true;
            this.lvRequests.HideSelection = false;
            this.lvRequests.MultiSelect = false;
            this.lvRequests.Name = "lvRequests";
            this.lvRequests.TabIndex = 0;
            this.lvRequests.UseCompatibleStateImageBehavior = false;
            this.lvRequests.View = System.Windows.Forms.View.Details;
            this.lvRequests.SelectedIndexChanged += new System.EventHandler(this.lvRequests_SelectedIndexChanged);

            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlDetails.Controls.Add(this.txtDetails);
            this.pnlDetails.Controls.Add(this.pbStatus);
            this.pnlDetails.Controls.Add(this.pnlUpdate);
            this.pnlDetails.Controls.Add(this.lblDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDetails.Size = new System.Drawing.Size(400, 520);
            this.pnlDetails.TabIndex = 1;

            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.TabIndex = 0;

            // 
            // pbStatus
            // 
            this.pbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(380, 22);
            this.pbStatus.TabIndex = 1;

            // 
            // pnlUpdate
            // 
            this.pnlUpdate.Controls.Add(this.lblNewStatus);
            this.pnlUpdate.Controls.Add(this.cboNewStatus);
            this.pnlUpdate.Controls.Add(this.btnUpdateStatus);
            this.pnlUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(380, 56);
            this.pnlUpdate.TabIndex = 2;

            // 
            // lblNewStatus
            // 
            this.lblNewStatus.AutoSize = true;
            this.lblNewStatus.Location = new System.Drawing.Point(0, 19);
            this.lblNewStatus.Name = "lblNewStatus";
            this.lblNewStatus.Size = new System.Drawing.Size(72, 19);
            this.lblNewStatus.Text = "New status";

            // 
            // cboNewStatus
            // 
            this.cboNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewStatus.Items.AddRange(new object[] {
            "Submitted",
            "Under Review",
            "In Progress",
            "Resolved",
            "Closed"});
            this.cboNewStatus.Location = new System.Drawing.Point(84, 15);
            this.cboNewStatus.Name = "cboNewStatus";
            this.cboNewStatus.Size = new System.Drawing.Size(150, 25);
            this.cboNewStatus.TabIndex = 0;

            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.Enabled = false;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(246, 11);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(130, 34);
            this.btnUpdateStatus.TabIndex = 1;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // 
            // lblDetails
            // 
            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblDetails.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(380, 28);
            this.lblDetails.TabIndex = 3;
            this.lblDetails.Text = "Request details and progress";

            // 
            // tabUrgent
            // 
            this.tabUrgent.BackColor = System.Drawing.Color.White;
            this.tabUrgent.Controls.Add(this.lvUrgent);
            this.tabUrgent.Controls.Add(this.lblUrgentInfo);
            this.tabUrgent.Location = new System.Drawing.Point(4, 26);
            this.tabUrgent.Name = "tabUrgent";
            this.tabUrgent.Size = new System.Drawing.Size(1172, 520);
            this.tabUrgent.Text = "Urgent Queue (Heap)";

            // 
            // lvUrgent
            // 
            this.lvUrgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUrgent.FullRowSelect = true;
            this.lvUrgent.GridLines = true;
            this.lvUrgent.HideSelection = false;
            this.lvUrgent.MultiSelect = false;
            this.lvUrgent.Name = "lvUrgent";
            this.lvUrgent.TabIndex = 0;
            this.lvUrgent.UseCompatibleStateImageBehavior = false;
            this.lvUrgent.View = System.Windows.Forms.View.Details;

            // 
            // lblUrgentInfo
            // 
            this.lblUrgentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUrgentInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUrgentInfo.Name = "lblUrgentInfo";
            this.lblUrgentInfo.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblUrgentInfo.Size = new System.Drawing.Size(1172, 52);
            this.lblUrgentInfo.TabIndex = 1;
            this.lblUrgentInfo.Text = "The 10 most urgent open requests. A min-heap keeps the most urgent request at the top, so the next job to handle is found instantly. Ties are broken by oldest first.";

            // 
            // tabRelated
            // 
            this.tabRelated.BackColor = System.Drawing.Color.White;
            this.tabRelated.Controls.Add(this.txtRelated);
            this.tabRelated.Controls.Add(this.pnlRelatedTop);
            this.tabRelated.Location = new System.Drawing.Point(4, 26);
            this.tabRelated.Name = "tabRelated";
            this.tabRelated.Size = new System.Drawing.Size(1172, 520);
            this.tabRelated.Text = "Related Requests (Graph)";

            // 
            // txtRelated
            // 
            this.txtRelated.BackColor = System.Drawing.Color.White;
            this.txtRelated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRelated.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtRelated.Multiline = true;
            this.txtRelated.Name = "txtRelated";
            this.txtRelated.ReadOnly = true;
            this.txtRelated.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRelated.TabIndex = 0;
            this.txtRelated.WordWrap = false;

            // 
            // pnlRelatedTop
            // 
            this.pnlRelatedTop.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlRelatedTop.Controls.Add(this.lblPick);
            this.pnlRelatedTop.Controls.Add(this.cboRelated);
            this.pnlRelatedTop.Controls.Add(this.btnBfs);
            this.pnlRelatedTop.Controls.Add(this.btnDfs);
            this.pnlRelatedTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRelatedTop.Name = "pnlRelatedTop";
            this.pnlRelatedTop.Size = new System.Drawing.Size(1172, 60);
            this.pnlRelatedTop.TabIndex = 1;

            // 
            // lblPick
            // 
            this.lblPick.AutoSize = true;
            this.lblPick.Location = new System.Drawing.Point(12, 20);
            this.lblPick.Name = "lblPick";
            this.lblPick.Size = new System.Drawing.Size(70, 19);
            this.lblPick.Text = "Start from:";

            // 
            // cboRelated
            // 
            this.cboRelated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelated.Location = new System.Drawing.Point(90, 16);
            this.cboRelated.Name = "cboRelated";
            this.cboRelated.Size = new System.Drawing.Size(460, 25);
            this.cboRelated.TabIndex = 0;

            // 
            // btnBfs
            // 
            this.btnBfs.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            this.btnBfs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBfs.FlatAppearance.BorderSize = 0;
            this.btnBfs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBfs.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnBfs.ForeColor = System.Drawing.Color.White;
            this.btnBfs.Location = new System.Drawing.Point(566, 13);
            this.btnBfs.Name = "btnBfs";
            this.btnBfs.Size = new System.Drawing.Size(170, 34);
            this.btnBfs.TabIndex = 1;
            this.btnBfs.Text = "Breadth-First Search";
            this.btnBfs.UseVisualStyleBackColor = false;
            this.btnBfs.Click += new System.EventHandler(this.btnBfs_Click);

            // 
            // btnDfs
            // 
            this.btnDfs.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.btnDfs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDfs.FlatAppearance.BorderSize = 0;
            this.btnDfs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDfs.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnDfs.ForeColor = System.Drawing.Color.White;
            this.btnDfs.Location = new System.Drawing.Point(746, 13);
            this.btnDfs.Name = "btnDfs";
            this.btnDfs.Size = new System.Drawing.Size(170, 34);
            this.btnDfs.TabIndex = 2;
            this.btnDfs.Text = "Depth-First Search";
            this.btnDfs.UseVisualStyleBackColor = false;
            this.btnDfs.Click += new System.EventHandler(this.btnDfs_Click);

            // 
            // tabRoute
            // 
            this.tabRoute.BackColor = System.Drawing.Color.White;
            this.tabRoute.Controls.Add(this.txtRoute);
            this.tabRoute.Controls.Add(this.pnlRouteTop);
            this.tabRoute.Location = new System.Drawing.Point(4, 26);
            this.tabRoute.Name = "tabRoute";
            this.tabRoute.Size = new System.Drawing.Size(1172, 520);
            this.tabRoute.Text = "Route Planner (Spanning Tree)";

            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.White;
            this.txtRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRoute.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtRoute.Multiline = true;
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRoute.TabIndex = 0;
            this.txtRoute.WordWrap = false;

            // 
            // pnlRouteTop
            // 
            this.pnlRouteTop.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlRouteTop.Controls.Add(this.lblRouteInfo);
            this.pnlRouteTop.Controls.Add(this.btnKruskal);
            this.pnlRouteTop.Controls.Add(this.btnPrim);
            this.pnlRouteTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRouteTop.Name = "pnlRouteTop";
            this.pnlRouteTop.Size = new System.Drawing.Size(1172, 90);
            this.pnlRouteTop.TabIndex = 1;

            // 
            // lblRouteInfo
            // 
            this.lblRouteInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRouteInfo.Location = new System.Drawing.Point(12, 8);
            this.lblRouteInfo.Name = "lblRouteInfo";
            this.lblRouteInfo.Size = new System.Drawing.Size(1100, 24);
            this.lblRouteInfo.Text = "A minimum spanning tree links all related requests with the least total distance, which is the shortest network a work crew needs to cover them.";

            // 
            // btnKruskal
            // 
            this.btnKruskal.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            this.btnKruskal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKruskal.FlatAppearance.BorderSize = 0;
            this.btnKruskal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKruskal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnKruskal.ForeColor = System.Drawing.Color.White;
            this.btnKruskal.Location = new System.Drawing.Point(12, 42);
            this.btnKruskal.Name = "btnKruskal";
            this.btnKruskal.Size = new System.Drawing.Size(170, 34);
            this.btnKruskal.TabIndex = 0;
            this.btnKruskal.Text = "Build with Kruskal";
            this.btnKruskal.UseVisualStyleBackColor = false;
            this.btnKruskal.Click += new System.EventHandler(this.btnKruskal_Click);

            // 
            // btnPrim
            // 
            this.btnPrim.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.btnPrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrim.FlatAppearance.BorderSize = 0;
            this.btnPrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrim.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnPrim.ForeColor = System.Drawing.Color.White;
            this.btnPrim.Location = new System.Drawing.Point(192, 42);
            this.btnPrim.Name = "btnPrim";
            this.btnPrim.Size = new System.Drawing.Size(170, 34);
            this.btnPrim.TabIndex = 1;
            this.btnPrim.Text = "Build with Prim";
            this.btnPrim.UseVisualStyleBackColor = false;
            this.btnPrim.Click += new System.EventHandler(this.btnPrim_Click);

            // 
            // tabInsights
            // 
            this.tabInsights.BackColor = System.Drawing.Color.White;
            this.tabInsights.Controls.Add(this.txtInsights);
            this.tabInsights.Controls.Add(this.pnlInsightsTop);
            this.tabInsights.Location = new System.Drawing.Point(4, 26);
            this.tabInsights.Name = "tabInsights";
            this.tabInsights.Size = new System.Drawing.Size(1172, 520);
            this.tabInsights.Text = "Data Structure Insights";

            // 
            // txtInsights
            // 
            this.txtInsights.BackColor = System.Drawing.Color.White;
            this.txtInsights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInsights.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtInsights.Multiline = true;
            this.txtInsights.Name = "txtInsights";
            this.txtInsights.ReadOnly = true;
            this.txtInsights.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInsights.TabIndex = 0;
            this.txtInsights.WordWrap = false;

            // 
            // pnlInsightsTop
            // 
            this.pnlInsightsTop.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlInsightsTop.Controls.Add(this.btnRefreshInsights);
            this.pnlInsightsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInsightsTop.Name = "pnlInsightsTop";
            this.pnlInsightsTop.Size = new System.Drawing.Size(1172, 56);
            this.pnlInsightsTop.TabIndex = 1;

            // 
            // btnRefreshInsights
            // 
            this.btnRefreshInsights.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            this.btnRefreshInsights.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshInsights.FlatAppearance.BorderSize = 0;
            this.btnRefreshInsights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshInsights.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnRefreshInsights.ForeColor = System.Drawing.Color.White;
            this.btnRefreshInsights.Location = new System.Drawing.Point(12, 11);
            this.btnRefreshInsights.Name = "btnRefreshInsights";
            this.btnRefreshInsights.Size = new System.Drawing.Size(160, 34);
            this.btnRefreshInsights.TabIndex = 0;
            this.btnRefreshInsights.Text = "Refresh Insights";
            this.btnRefreshInsights.UseVisualStyleBackColor = false;
            this.btnRefreshInsights.Click += new System.EventHandler(this.btnRefreshInsights_Click);

            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1180, 740);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Request Status";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlUpdate.ResumeLayout(false);
            this.pnlUpdate.PerformLayout();
            this.tabUrgent.ResumeLayout(false);
            this.tabRelated.ResumeLayout(false);
            this.pnlRelatedTop.ResumeLayout(false);
            this.pnlRelatedTop.PerformLayout();
            this.tabRoute.ResumeLayout(false);
            this.pnlRouteTop.ResumeLayout(false);
            this.tabInsights.ResumeLayout(false);
            this.tabInsights.PerformLayout();
            this.pnlInsightsTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.TextBox txtTrack;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.Label lblTrackResult;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.Panel pnlUpdate;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.ComboBox cboNewStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TabPage tabUrgent;
        private System.Windows.Forms.ListView lvUrgent;
        private System.Windows.Forms.Label lblUrgentInfo;
        private System.Windows.Forms.TabPage tabRelated;
        private System.Windows.Forms.TextBox txtRelated;
        private System.Windows.Forms.Panel pnlRelatedTop;
        private System.Windows.Forms.Label lblPick;
        private System.Windows.Forms.ComboBox cboRelated;
        private System.Windows.Forms.Button btnBfs;
        private System.Windows.Forms.Button btnDfs;
        private System.Windows.Forms.TabPage tabRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Panel pnlRouteTop;
        private System.Windows.Forms.Label lblRouteInfo;
        private System.Windows.Forms.Button btnKruskal;
        private System.Windows.Forms.Button btnPrim;
        private System.Windows.Forms.TabPage tabInsights;
        private System.Windows.Forms.TextBox txtInsights;
        private System.Windows.Forms.Panel pnlInsightsTop;
        private System.Windows.Forms.Button btnRefreshInsights;
    }
}