using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SemilabDevOps.Models;

namespace SemilabDevOps
{
    public partial class _Default : Page
    {

        private int _leveln;
        private const string Project = "SEMILAB_Sandbox";
        private VSTShandler _vsts;
        public ListItem OtherItem { get; set; }
        public bool Bug { get; set; }
        public Models.Lists Lists { get; set; }
        public bool Authenticated { get; set; }
        public int Leveln 
        {
            get 
            {
                Int32.TryParse(Level.Value, out _leveln);
                return _leveln;
            }
            set
            {
                Level.Value = value.ToString();
                _leveln = value;
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Lists = new Models.Lists();
            if(BugOrBacklog.SelectedValue == "bug")
            {
                Bug = true; 
            }
            else
            {
                Bug = false;
            }
            if (UserName.Text == "")
            {
                if (Request.Cookies["DOTn"] != null)
                {
                    UserName.Text = Tools.Decrypt(Request.Cookies["DOTn"].Value);
                }
            }
            if(Password.Text == "")
            {
                if (Request.Cookies["DOTp"] != null)
                {
                    Password.Text = Tools.Decrypt(Request.Cookies["DOTp"].Value);
                }
            }
            
            try
            {
                _vsts = new VSTShandler(Project);
                Authenticated = true;
                Label1.Visible = true;
                UserName.Visible = false;
                Password.Visible = false;
                SubmitButton.Visible = false;
                Label1.Text = _vsts.User;
                BugOrBacklog.Visible = true;
                if (Leveln == 0)
                {
                    Leveln = 1;
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "VSTS bejelentkezés szükséges";
                Label1.Visible = true;
                UserName.Visible = true;
                Password.Visible = true;
                SubmitButton.Visible = true;
                Leveln = 0;
            }
            if (!Authenticated && UserName.Text != "" && Password.Text != "")
            {
                try
                {
                    string username = Tools.ValidateEmailAddress(UserName.Text);
                    string password = Password.Text.Trim();
                    _vsts = new VSTShandler(Project, username, password);
                    Authenticated = true;
                    Response.Cookies["DOTn"].Value = Tools.Encrypt(username);
                    Response.Cookies["DOTn"].Expires = DateTime.Now.AddDays(90);
                    Response.Cookies["DOTp"].Value = Tools.Encrypt(password);
                    Response.Cookies["DOTp"].Expires = DateTime.Now.AddDays(90);
                    Label1.Text = _vsts.User;
                    UserName.Visible = false;
                    Password.Visible = false;
                    SubmitButton.Visible = false;
                    BugOrBacklog.Visible = true;
                    if (Leveln == 0)
                    {
                        Leveln = 1;
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = "Bejelentkezés nem sikerült: " + ex.Message;
                    Label1.Visible = true;
                    UserName.Visible = true;
                    Password.Visible = true;
                    SubmitButton.Visible = true;
                    Leveln = 0;
                }  
            }
            if (Authenticated)
            {
                if (Leveln == 3 && Subject.Text != "")
                {
                    Leveln = 4;
                }
                if (Leveln == 2 && SubList.Items.Count < 2)
                {
                    Leveln = 3;
                }

                SetVisualElements();
            }
        }


        protected void RefreshThreadList()
        {

            ThreadList.Items.Clear();
            OtherItem = new ListItem("Egyéb", "99");
            foreach (Threads t in Lists.Threads)
            {
                if ((t.Root == Case.Bug && Bug) || (t.Root == Case.Backlog && !Bug) || t.Root == Case.Both)
                {
                    ListItem li = new ListItem();
                    li.Value = t.Id.ToString();
                    li.Text = t.Name;
                    if (li.Value == ThreadList.SelectedValue)
                    {
                        li.Selected = true;
                    }
                    ThreadList.Items.Add(li);
                }
            }
            ThreadList.Items.Add(OtherItem);
        }

        protected void RefreshSublist()
        {
            SubList.Items.Clear();
            ListItem ii = new ListItem();
            ii.Value = "0";
            if (BugOrBacklog.SelectedValue == "bug")
            {
                ii.Text = "Gyakori hiba kiválasztása";
                Bug = true;
            }
            else
            {
                ii.Text = "Gyakori kérés kiválasztása";
            }
            SubList.Items.Add(ii);
            int i = 0;
            foreach (Categories c in Lists.Categories)
            {
                int sv = 0;
                Int32.TryParse(ThreadList.SelectedValue, out sv);
                if (c.Bug == Bug && c.Thread == sv)
                {
                    i++;
                    ListItem li = new ListItem();
                    //li.Value = ThreadList.SelectedIndex.ToString();
                    li.Value = i.ToString();
                    li.Text = c.Name;
                    SubList.Items.Add(li);
                }
            }
            if (SubList.Items.Count > 1)
            {
                SubList.Visible = true;
            }
            else
            {
                SubList.Visible = false;
            }

        }

        protected void SetVisualElements()
        {
            switch (Leveln)
            {
                case 1:
                    BugOrBacklog.Visible = true;
                    Label2.Visible = false;
                    Severity.Visible = false;
                    ThreadList.Visible = false;
                    SubList.Visible = false;
                    Subject.Visible = false;
                    Details.Visible = false;
                    Feedback.Visible = false;
                    SubmitTicket.Visible = false;
                    break;
                case 2:
                    BugOrBacklog.Visible = true;
                    if (Bug)
                    {
                        Label2.Visible = true;
                        Severity.Visible = true;
                    }
                    else
                    {
                        Label2.Visible = false;
                        Severity.Visible = false;
                    }
                    ThreadList.Visible = true;
                    SubList.Visible = false;
                    Subject.Visible = false;
                    Details.Visible = false;
                    Feedback.Visible = false;
                    SubmitTicket.Visible = false;
                    break;
                case 3:
                    BugOrBacklog.Visible = true;
                    if (Bug)
                    {
                        Label2.Visible = true;
                        Severity.Visible = true;
                    }
                    else
                    {
                        Label2.Visible = false;
                        Severity.Visible = false;
                    }
                    ThreadList.Visible = true;
                    SubList.Visible = true;
                    Subject.Visible = true;
                    Details.Visible = true;
                    Feedback.Visible = false;
                    SubmitTicket.Visible = false;
                    break;
                case 4:
                    BugOrBacklog.Visible = true;
                    if (Bug)
                    {
                        Label2.Visible = true;
                        Severity.Visible = true;
                    }
                    else
                    {
                        Label2.Visible = false;
                        Severity.Visible = false;
                    }
                    ThreadList.Visible = true;
                    SubList.Visible = true;
                    Subject.Visible = true;
                    Details.Visible = true;
                    Feedback.Visible = true;
                    SubmitTicket.Visible = true;
                    break;
            }
        }

        protected void SubmitTicket_Click(object sender, EventArgs e)
        {
            //_vsts.DownloadData();
            Feedback.Visible = true;
            if (BugOrBacklog.SelectedValue == "bug")
            {
                Feedback.Text = _vsts.SaveBug(Subject.Text, Details.Text, Severity.SelectedIndex);
            }
            else
            {
                Feedback.Text = _vsts.SaveBacklog(Subject.Text, Details.Text);
            }
        }

        protected void BugOrBacklog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BugOrBacklog.SelectedValue == "bug")
            {
                Bug = true;
                Label2.Text = "Súlyosság: ";
                Severity.Items.Clear();
                Severity.Items.Add(new ListItem("Alacsony", "4"));
                Severity.Items.Add(new ListItem("Közepes", "3"));
                Severity.Items.Add(new ListItem("Magas", "2"));
                Severity.Items.Add(new ListItem("Kritikus", "1"));
            }
            else
            {
                Bug = false;
            }
            if(Leveln == 1)
            {
                Leveln = 2;
            }
            SetVisualElements();
           //ThreadList.Items.Clear();
            RefreshThreadList();
            BugOrBacklog.Items.Remove(BugOrBacklog.Items.FindByValue("-"));
            if(Leveln > 2)
            {
                RefreshSublist();
                Subject.Text = "";
            }
        }

        protected void ThreadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThreadList.Items.Remove(ThreadList.Items.FindByValue(""));
            RefreshSublist();
            if (SubList.SelectedValue != "0")
            {
                Subject.Text = SubList.SelectedItem.Text;
            }
            if(Leveln == 2)
            {
                Leveln = 3;
            }
        }

        protected void SubList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubList.SelectedValue != "0")
            {
                Subject.Text = SubList.SelectedItem.Text;
            }
            else
            {
                Subject.Text = "";
            }
            int i = 1;
            List<TextBox> ctb = new List<TextBox>();
            ctb.Add(CustomTextBox1);
            ctb.Add(CustomTextBox2);
            ctb.Add(CustomTextBox3);
            foreach( TextBox t in ctb)
            {
                t.Text = i.ToString();
                t.Visible = true;
                t.Width = Unit.Pixel(50);
                i++;
            }
        }

    }
}