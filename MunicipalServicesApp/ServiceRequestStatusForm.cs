using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        // Stops the filter drop-downs from refreshing the list while they are being filled
        private bool suppressEvents = false;

        public ServiceRequestStatusForm()
        {
            InitializeComponent();

            tabs.SelectedIndexChanged += tabs_SelectedIndexChanged;

            tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabs.SizeMode = TabSizeMode.Fixed;
            tabs.DrawItem += tabs_DrawItem;
            tabs.Resize += (s, e) => SizeTabs();
            SizeTabs();

            AddColumns();
            LoadFilters();
            RefreshAll();

            txtRelated.Text = "Choose a request above, then press Breadth-First Search or Depth-First Search.";
            txtRoute.Text = "Press Kruskal or Prim to build the minimum spanning tree.";
        }

        // ---------------------------------------------------------------
        // LOADING DATA
        // ---------------------------------------------------------------

        private void AddColumns()
        {
            lvRequests.Columns.Add("ID", 80);
            lvRequests.Columns.Add("Title", 230);
            lvRequests.Columns.Add("Category", 160);
            lvRequests.Columns.Add("Location", 210);
            lvRequests.Columns.Add("Priority", 110);
            lvRequests.Columns.Add("Status", 120);
            lvRequests.Columns.Add("Submitted", 110);

            lvUrgent.Columns.Add("Rank", 60);
            lvUrgent.Columns.Add("ID", 80);
            lvUrgent.Columns.Add("Title", 260);
            lvUrgent.Columns.Add("Category", 170);
            lvUrgent.Columns.Add("Location", 230);
            lvUrgent.Columns.Add("Priority", 110);
            lvUrgent.Columns.Add("Status", 120);
            lvUrgent.Columns.Add("Days open", 100);
        }

        private void LoadFilters()
        {
            suppressEvents = true;

            cboCategory.Items.Clear();
            cboCategory.Items.Add("All categories");
            foreach (string name in ServiceRequestManager.GetCategoryNames())
            {
                cboCategory.Items.Add(name);
            }
            cboCategory.SelectedIndex = 0;

            cboStatus.Items.Clear();
            cboStatus.Items.Add("All statuses");
            cboStatus.Items.Add(ServiceRequest.GetStatusText(RequestStatus.Submitted));
            cboStatus.Items.Add(ServiceRequest.GetStatusText(RequestStatus.UnderReview));
            cboStatus.Items.Add(ServiceRequest.GetStatusText(RequestStatus.InProgress));
            cboStatus.Items.Add(ServiceRequest.GetStatusText(RequestStatus.Resolved));
            cboStatus.Items.Add(ServiceRequest.GetStatusText(RequestStatus.Closed));
            cboStatus.SelectedIndex = 0;

            cboSort.Items.Clear();
            cboSort.Items.Add("Request number (AVL tree)");
            cboSort.Items.Add("Most urgent first (heap sort)");
            cboSort.Items.Add("Newest first (red-black tree)");
            cboSort.SelectedIndex = 0;

            cboNewStatus.SelectedIndex = 0;

            suppressEvents = false;
        }

        private void RefreshAll()
        {
            RefreshList();
            RefreshUrgent();
            RefreshRelatedCombo();
            txtInsights.Text = ServiceRequestManager.GetInsights();
        }

        private Color StatusBackColor(RequestStatus status)
        {
            if (status == RequestStatus.UnderReview)
            {
                return Color.FromArgb(254, 249, 195);
            }
            if (status == RequestStatus.InProgress)
            {
                return AppTheme.PrimaryBlueLight;
            }
            if (status == RequestStatus.Resolved)
            {
                return AppTheme.AccentTealLight;
            }
            if (status == RequestStatus.Closed)
            {
                return AppTheme.BackgroundGray;
            }
            return Color.White;
        }

        private void RefreshList()
        {
            List<ServiceRequest> source;
            if (cboCategory.SelectedIndex > 0)
            {
                source = ServiceRequestManager.GetByCategory(cboCategory.SelectedItem.ToString());
            }
            else
            {
                source = ServiceRequestManager.GetAll();
            }

            List<ServiceRequest> filtered = new List<ServiceRequest>();
            foreach (ServiceRequest request in source)
            {
                if (cboStatus.SelectedIndex > 0 && (int)request.Status != cboStatus.SelectedIndex - 1)
                {
                    continue;
                }
                filtered.Add(request);
            }

            List<ServiceRequest> ordered;
            if (cboSort.SelectedIndex == 1)
            {
                ordered = ServiceRequestManager.OrderByUrgency(filtered);
            }
            else if (cboSort.SelectedIndex == 2)
            {
                ordered = ServiceRequestManager.OrderNewestFirst(filtered);
            }
            else
            {
                ordered = ServiceRequestManager.OrderByNumber(filtered);
            }

            lvRequests.BeginUpdate();
            lvRequests.Items.Clear();
            foreach (ServiceRequest request in ordered)
            {
                ListViewItem item = new ListViewItem(request.Id);
                item.SubItems.Add(request.Title);
                item.SubItems.Add(request.Category);
                item.SubItems.Add(request.Location);
                item.SubItems.Add(request.PriorityText);
                item.SubItems.Add(request.StatusText);
                item.SubItems.Add(request.DateSubmitted.ToString("yyyy-MM-dd"));
                item.Tag = request;
                item.BackColor = StatusBackColor(request.Status);
                lvRequests.Items.Add(item);
            }
            lvRequests.EndUpdate();

            lblCount.Text = ordered.Count + " of " + ServiceRequestManager.Count + " requests shown";
            ShowDetails(GetSelectedRequest());
        }

        private void RefreshUrgent()
        {
            lvUrgent.Items.Clear();
            int rank = 1;

            foreach (ServiceRequest request in ServiceRequestManager.GetMostUrgent(10))
            {
                ListViewItem item = new ListViewItem(rank.ToString());
                item.SubItems.Add(request.Id);
                item.SubItems.Add(request.Title);
                item.SubItems.Add(request.Category);
                item.SubItems.Add(request.Location);
                item.SubItems.Add(request.PriorityText);
                item.SubItems.Add(request.StatusText);
                item.SubItems.Add(((int)(DateTime.Now - request.DateSubmitted).TotalDays).ToString());
                item.BackColor = StatusBackColor(request.Status);
                lvUrgent.Items.Add(item);
                rank++;
            }
        }

        private void RefreshRelatedCombo()
        {
            int selectedNumber = -1;
            ServiceRequest current = cboRelated.SelectedItem as ServiceRequest;
            if (current != null)
            {
                selectedNumber = current.Number;
            }

            cboRelated.Items.Clear();
            int indexToSelect = 0;

            foreach (ServiceRequest request in ServiceRequestManager.GetAll())
            {
                int index = cboRelated.Items.Add(request);
                if (request.Number == selectedNumber)
                {
                    indexToSelect = index;
                }
            }

            if (cboRelated.Items.Count > 0)
            {
                cboRelated.SelectedIndex = indexToSelect;
            }
        }

        private ServiceRequest GetSelectedRequest()
        {
            if (lvRequests.SelectedItems.Count == 0)
            {
                return null;
            }
            return lvRequests.SelectedItems[0].Tag as ServiceRequest;
        }

        private void SelectRequestInList(ServiceRequest request)
        {
            foreach (ListViewItem item in lvRequests.Items)
            {
                ServiceRequest candidate = item.Tag as ServiceRequest;
                if (candidate != null && candidate.Number == request.Number)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    return;
                }
            }
        }

        private void ShowDetails(ServiceRequest request)
        {
            if (request == null)
            {
                txtDetails.Text = "Select a request in the list to see its full details and progress history.";
                pbStatus.Value = 0;
                btnUpdateStatus.Enabled = false;
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(request.Id + "  -  " + request.Title);
            sb.AppendLine();
            sb.AppendLine("Status     : " + request.StatusText);
            sb.AppendLine("Progress   : " + request.ProgressPercent + "%");
            sb.AppendLine("Priority   : " + request.PriorityText);
            sb.AppendLine("Category   : " + request.Category);
            sb.AppendLine("Location   : " + request.Location);
            sb.AppendLine("Submitted  : " + request.DateSubmitted.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("Updated    : " + request.LastUpdated.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine();
            sb.AppendLine("Description");
            sb.AppendLine(request.Description);
            sb.AppendLine();
            sb.AppendLine("Progress history");
            foreach (string line in request.History)
            {
                sb.AppendLine("  " + line);
            }

            txtDetails.Text = sb.ToString();
            txtDetails.SelectionStart = 0;
            pbStatus.Value = request.ProgressPercent;
            cboNewStatus.SelectedIndex = (int)request.Status;
            btnUpdateStatus.Enabled = true;
        }

        // ---------------------------------------------------------------
        // EVENTS
        // ---------------------------------------------------------------

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            if (suppressEvents)
            {
                return;
            }
            RefreshList();
        }

        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDetails(GetSelectedRequest());
        }

        private void txtTrack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TrackRequest();
            }
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            TrackRequest();
        }

        private void TrackRequest()
        {
            string text = txtTrack.Text.Trim();

            if (text.Length == 0)
            {
                lblTrackResult.ForeColor = Color.Firebrick;
                lblTrackResult.Text = "Please type a request ID such as SR-1003.";
                return;
            }

            int steps;
            ServiceRequest found = ServiceRequestManager.FindById(text, out steps);

            if (found == null)
            {
                lblTrackResult.ForeColor = Color.Firebrick;
                lblTrackResult.Text = "No request found for \"" + text + "\".";
                return;
            }

            suppressEvents = true;
            cboCategory.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            suppressEvents = false;

            tabs.SelectedTab = tabAll;
            RefreshList();
            SelectRequestInList(found);


            lblTrackResult.ForeColor = AppTheme.AccentTeal;
            lblTrackResult.Text = "Found " + found.Id + " (" + found.StatusText + ") using the AVL tree in " + steps + " comparison(s).";
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            ServiceRequest request = GetSelectedRequest();
            if (request == null)
            {
                return;
            }

            RequestStatus newStatus = (RequestStatus)cboNewStatus.SelectedIndex;
            if (newStatus == request.Status)
            {
                MessageBox.Show("This request already has that status.", "Update Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ServiceRequestManager.UpdateStatus(request, newStatus);

            RefreshList();
            SelectRequestInList(request);
            RefreshUrgent();
            RefreshRelatedCombo();
            txtInsights.Text = ServiceRequestManager.GetInsights();
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabUrgent)
            {
                RefreshUrgent();
            }
            else if (tabs.SelectedTab == tabInsights)
            {
                txtInsights.Text = ServiceRequestManager.GetInsights();
            }
        }

        private void btnBfs_Click(object sender, EventArgs e)
        {
            ShowTraversal(true);
        }

        private void btnDfs_Click(object sender, EventArgs e)
        {
            ShowTraversal(false);
        }

        private void ShowTraversal(bool breadthFirst)
        {
            ServiceRequest start = cboRelated.SelectedItem as ServiceRequest;
            if (start == null)
            {
                MessageBox.Show("Please choose a request first.", "Related Requests",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<TraversalStep> steps;
            string method;
            string explanation;

            if (breadthFirst)
            {
                steps = ServiceRequestManager.Graph.BreadthFirst(start.Number);
                method = "Breadth-first search";
                explanation = "Closest related requests first. The number is how many links away each request is.";
            }
            else
            {
                steps = ServiceRequestManager.Graph.DepthFirst(start.Number);
                method = "Depth-first search";
                explanation = "Follows one chain of related requests as deep as possible before backtracking.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(method + " starting at " + start.Id + " - " + start.Title);
            sb.AppendLine(explanation);
            sb.AppendLine("Two requests are related when they share a category or are within " +
                          RequestGraph.RelatedDistanceKm.ToString("0.0") + " km of each other.");
            sb.AppendLine("Requests reached: " + steps.Count);
            sb.AppendLine(new string('-', 90));

            foreach (TraversalStep step in steps)
            {
                sb.AppendLine(new string(' ', step.Depth * 3) +
                              step.Request.Id + "  " + step.Request.Title +
                              "  (" + step.Request.Category + ", " + step.Request.StatusText + ")" +
                              "   [" + step.Depth + "]");
            }

            txtRelated.Text = sb.ToString();
        }

        private void btnKruskal_Click(object sender, EventArgs e)
        {
            ShowMst("Kruskal's algorithm", ServiceRequestManager.Graph.KruskalMst());
        }

        private void btnPrim_Click(object sender, EventArgs e)
        {
            ShowMst("Prim's algorithm", ServiceRequestManager.Graph.PrimMst());
        }

        private void ShowMst(string name, MstResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Minimum spanning tree using " + name);
            sb.AppendLine("Links in the tree : " + result.Edges.Count);
            sb.AppendLine("Separate groups   : " + result.Components);
            sb.AppendLine("Total distance    : " + result.TotalWeight.ToString("0.0") + " km");
            sb.AppendLine(new string('-', 90));

            foreach (GraphEdge edge in result.Edges)
            {
                sb.AppendLine(edge.Source.Id + "  <->  " + edge.Target.Id + "   " +
                              edge.Weight.ToString("0.0").PadLeft(5) + " km   " +
                              edge.Source.Location + "  to  " + edge.Target.Location);
            }

            txtRoute.Text = sb.ToString();
        }

        private void btnRefreshInsights_Click(object sender, EventArgs e)
        {
            txtInsights.Text = ServiceRequestManager.GetInsights();
        }

        // Makes the five tabs share the width of the control equally
        // Makes the five tabs share the width of the control equally
        private void SizeTabs()
        {
            if (tabs.TabCount == 0)
            {
                return;
            }

            Size wanted = new Size((tabs.Width - 4) / tabs.TabCount, 34);

            // Only change it when different, otherwise the Resize event calls this method forever
            if (tabs.ItemSize != wanted)
            {
                tabs.ItemSize = wanted;
            }
        }

        // Selected tab = dark blue with white text, other tabs = light grey
        private void tabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = (e.Index == tabs.SelectedIndex);

            Color back = selected ? Color.FromArgb(16, 78, 130) : Color.FromArgb(225, 230, 236);
            Color fore = selected ? Color.White : Color.FromArgb(40, 40, 40);
            Font font = selected ? new Font(tabs.Font, FontStyle.Bold) : tabs.Font;

            using (SolidBrush brush = new SolidBrush(back))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            TextRenderer.DrawText(e.Graphics, tabs.TabPages[e.Index].Text, font, e.Bounds, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            if (selected)
            {
                font.Dispose();
            }
        }
    }
}