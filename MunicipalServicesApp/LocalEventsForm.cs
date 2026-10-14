using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{


    public partial class LocalEventsForm : Form
    {
        private EventManager manager = EventManager.GetShared();
        // true while the lists are being filled
        private bool busy = false;    

        public LocalEventsForm()
        {
            InitializeComponent();

            // Settings for the controls
    
            AcceptButton = btnSearch;     

            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

   
            float scale = DeviceDpi / 96f;

            lvEvents.View = View.Details;
            lvEvents.FullRowSelect = true;
            lvEvents.MultiSelect = false;
            lvEvents.HideSelection = false;
            lvEvents.Columns.Add("Date", (int)(90 * scale));
            lvEvents.Columns.Add("Time", (int)(55 * scale));
            lvEvents.Columns.Add("Event", (int)(250 * scale));
            lvEvents.Columns.Add("Category", (int)(95 * scale));
            lvEvents.Columns.Add("Location", (int)(150 * scale));

            lstRecs.IntegralHeight = false;
            lstRecs.DrawMode = DrawMode.OwnerDrawFixed;
            lstRecs.ItemHeight = (int)(44 * scale);
            lstRecs.DrawItem += lstRecs_DrawItem;
            lstRecent.IntegralHeight = false;

            lblAnnouncement.AutoSize = false;
            lblAnnouncement.TextAlign = ContentAlignment.MiddleLeft;
            lblAnnouncement.UseMnemonic = false;

            lblDetails.AutoSize = false;
            lblDetails.BorderStyle = BorderStyle.FixedSingle;
            lblDetails.BackColor = Color.White;
            lblDetails.Padding = new Padding(8);
            lblDetails.Font = new Font("Segoe UI", 10.5F);

            // Lets the page stretch when the window is maximised
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAnnouncement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDismiss.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lvEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            lblCapDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCapRecs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstRecs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCapRecent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstRecent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            LoadData();
        }

        // ---------- LOAD THE FIRST DATA ----------
        private void LoadData()
        {
        
            cboCategory.Items.Add("All categories");
            foreach (string c in manager.GetCategories())
            {
                cboCategory.Items.Add(c);
            }
            cboCategory.SelectedIndex = 0;

            // The date picker only allows dates that have events
            dtpDate.MinDate = manager.FirstDate();
            dtpDate.MaxDate = manager.LastDate();
            chkDate.Checked = false;      

            List<EventItem> all = manager.Search("", "", false, DateTime.Today);
            ShowEvents(all);
            ShowStatus(all, false, DateTime.Today);
            ShowAnnouncement();
            RefreshRecent();
            RefreshRecommendations();
            lblDetails.Text = "Select an event to see its details.";
        }

        // ---------- BUTTON CLICKS ----------
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            // removes the top announcement
            manager.DismissAnnouncement();   
            ShowAnnouncement();              
        }

        // Picking a day automatically ticks "Filter by date"
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            chkDate.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim();

            string category = "";
            if (cboCategory.SelectedIndex > 0)
            {
                category = cboCategory.Text;
            }

            bool useDate = chkDate.Checked;
            DateTime date = dtpDate.Value.Date;

            manager.RecordSearch(text, category);

            List<EventItem> results = manager.Search(text, category, useDate, date);
            ShowEvents(results);
            ShowStatus(results, useDate, date);

            // Suggest earlier searches while typing
            AutoCompleteStringCollection history = new AutoCompleteStringCollection();
            history.AddRange(manager.GetRecentSearches());
            txtSearch.AutoCompleteCustomSource = history;

            RefreshRecommendations();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboCategory.SelectedIndex = 0;
            dtpDate.Value = manager.FirstDate();
            // untick AFTER the date is reset
            chkDate.Checked = false;      

            List<EventItem> all = manager.Search("", "", false, DateTime.Today);
            ShowEvents(all);
            ShowStatus(all, false, DateTime.Today);
        }

        // ---------- SELECTING AN EVENT ----------
        private void lvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busy) return;
            if (lvEvents.SelectedItems.Count == 0) return;

            EventItem ev = (EventItem)lvEvents.SelectedItems[0].Tag;
            OpenEvent(ev);
        }

        private void lstRecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFromList(lstRecs);
        }

        private void lstRecent_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFromList(lstRecent);
        }

        private void OpenFromList(ListBox box)
        {
            if (busy) return;

            EventItem ev = box.SelectedItem as EventItem;
            if (ev == null)
            {
                Recommendation rec = box.SelectedItem as Recommendation;
                if (rec != null) ev = rec.Event;
            }

            if (ev != null)
            {
                OpenEvent(ev, box != lstRecs);   // don't reshuffle the list the user just clicked
            }
        }

        private void OpenEvent(EventItem ev, bool refreshRecs = true)
        {
            manager.RecordView(ev);

            lblDetails.Text = ev.Title + "\n\n"
                + "When: " + ev.Date.ToString("dddd, d MMMM yyyy 'at' HH:mm") + "\n"
                + "Where: " + ev.Location + "\n"
                + "Category: " + ev.Category + "\n\n"
                + ev.Description;

            RefreshRecent();
            if (refreshRecs) RefreshRecommendations();
        }

        private void OpenEvent(EventItem ev)
        {
            manager.RecordView(ev);

            lblDetails.Text = ev.Title + "\n\n"
                + "When: " + ev.Date.ToString("dddd, d MMMM yyyy 'at' HH:mm") + "\n"
                + "Where: " + ev.Location + "\n"
                + "Category: " + ev.Category + "\n\n"
                + ev.Description;

            RefreshRecent();
            RefreshRecommendations();
        }

        // ---------- SHOW THINGS ON SCREEN ----------
        private void ShowEvents(List<EventItem> events)
        {
            busy = true;
            lvEvents.Items.Clear();

            foreach (EventItem ev in events)
            {
                ListViewItem item = new ListViewItem(ev.Date.ToString("ddd d MMM"));
                item.SubItems.Add(ev.Date.ToString("HH:mm"));
                item.SubItems.Add(ev.Title);
                item.SubItems.Add(ev.Category);
                item.SubItems.Add(ev.Location);
                item.Tag = ev;
                lvEvents.Items.Add(item);
            }
            busy = false;
        }

        private void ShowStatus(List<EventItem> results, bool useDate, DateTime date)
        {
            if (results.Count > 0)
            {
                lblStatus.Text = results.Count + " event(s) found";
                return;
            }

            string message = "No events match your search.";
            if (useDate)
            {
                DateTime next = manager.NextDateAfter(date);
                if (next != DateTime.MinValue)
                {
                    message += " Next event date: " + next.ToString("dddd, d MMMM") + ".";
                }
            }
            lblStatus.Text = message;
        }

        private void ShowAnnouncement()
        {
            Announcement a = manager.GetTopAnnouncement();

            if (a == null)
            {
                lblAnnouncement.Visible = false;
                btnDismiss.Visible = false;
                return;
            }

            lblAnnouncement.Visible = true;
            btnDismiss.Visible = true;

            string tag = "NOTICE";
            lblAnnouncement.BackColor = Color.FromArgb(219, 234, 254);   

            if (a.Priority == 1)
            {
                tag = "URGENT";
                lblAnnouncement.BackColor = Color.FromArgb(254, 226, 226);   
            }
            else if (a.Priority == 2)
            {
                tag = "IMPORTANT";
                lblAnnouncement.BackColor = Color.FromArgb(254, 243, 199);   
            }

            lblAnnouncement.Text = tag + ":  " + a.Title + " - " + a.Message;

            int more = manager.AnnouncementCount() - 1;
            if (more > 0)
            {
                btnDismiss.Text = "Next (" + more + " more)";
            }
            else
            {
                btnDismiss.Text = "Dismiss";
            }
        }

        private void RefreshRecommendations()
        {
            busy = true;
            lstRecs.Items.Clear();

            List<Recommendation> recs = manager.GetRecommendations(5);
            if (recs.Count == 0)
            {
                lstRecs.Items.Add("Search or open events to get suggestions.");
            }
            else
            {
                foreach (Recommendation rec in recs)
                {
                    lstRecs.Items.Add(rec);
                }
            }
            busy = false;
        }

        private void RefreshRecent()
        {
            busy = true;
            lstRecent.Items.Clear();

            List<EventItem> recent = manager.GetRecentlyViewed(5);
            if (recent.Count == 0)
            {
                lstRecent.Items.Add("Events you open will appear here.");
            }
            else
            {
                foreach (EventItem ev in recent)
                {
                    lstRecent.Items.Add(ev);
                }
            }
            busy = false;
        }

        private void lstRecs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();

            bool selected = (e.State & DrawItemState.Selected) != 0;
            Color mainColor = selected ? SystemColors.HighlightText : Color.FromArgb(30, 41, 59);
            Color subColor = selected ? SystemColors.HighlightText : Color.FromArgb(100, 116, 139);

            Rectangle r = Rectangle.Inflate(e.Bounds, -6, -2);
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;

            Recommendation rec = lstRecs.Items[e.Index] as Recommendation;
            if (rec == null)
            {
                // the "Search or open events..." hint message
                TextRenderer.DrawText(e.Graphics, lstRecs.Items[e.Index].ToString(), e.Font, r, subColor, flags);
                return;
            }

            Rectangle top = new Rectangle(r.X, r.Y, r.Width, r.Height / 2);
            Rectangle bottom = new Rectangle(r.X, r.Y + r.Height / 2, r.Width, r.Height / 2);

            using (Font bold = new Font(e.Font, FontStyle.Bold))
            {
                TextRenderer.DrawText(e.Graphics, rec.Event.Title, bold, top, mainColor, flags);
            }
            string line2 = rec.Event.Date.ToString("ddd d MMM") + "  |  " + rec.Reason;
            TextRenderer.DrawText(e.Graphics, line2, e.Font, bottom, subColor, flags);

            e.DrawFocusRectangle();
        }
    }
}


