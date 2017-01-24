using dregg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dregg_gui
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            txt.Rtf = @"{\rtf1\ansi \b SimulationX Release Note Generator\b0 \par\par
Use this tool to read all comments and commits from Trac that contain the string \i ""#RN""\i0  and indicate a release note entry.\par
""Get Milestones""\i0 reads all possible milestones from Trac and populates the list.Select the milestone(s) you want the release notes to be created for and click \i ""Generate CSV""\i0.It might take a while to collect your entries.When the program is ready, it will open a csv file with your default csv app(mostly excel).\par
}";
        }

        private void btnCheckServer_Click(object sender, EventArgs e)
        {
            Api api = new Api(txtServer.Text, txtUser.Text, txtPassword.Text);
            try
            {
                //MessageBox.Show("Connection OK." + Environment.NewLine + "Version: " + api.GetApiVersion(), 
                //    "Trac JSON-RPC Api Version");
                //Properties.Settings.Default.Save();

                var s = (string[])api.GetMilestones();
                Array.Sort(s, (a, b) => b.CompareTo(a));

                lbMilestones.Items.Clear();
                lbMilestones.Items.AddRange(s);
                //txtMilestones.Text = String.Join("|", s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            switch (tabsOptions.SelectedTab.Name)
            {
                case "tabHotfix":
                    break;
                case "tabRelease":
                    this.Enabled = false;
                    RpcCall call = new RpcCall();
                    call.closedOnly = true;
                    call.host = txtServer.Text;
                    call.user = txtUser.Text;
                    call.password = txtPassword.Text;

                    if (lbMilestones.Items.Count > 0)
                    {
                        foreach (var item in lbMilestones.SelectedItems)
                            call.milestone += item + "|";
                        call.milestone.Substring(0, call.milestone.Length - 1);
                    }
                    this.Enabled = true;
                    switch (cbOutput.Text.ToUpperInvariant())
                    {
                        case "CSV":
                            call.DoCall(true, false);
                            break;
                        case "HTML":
                            call.DoCall(false, true);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnQueryTickets_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            RpcCall call = new RpcCall();
            call.closedOnly = true;
            call.host = txtServer.Text;
            call.user = txtUser.Text;
            call.password = txtPassword.Text;
            call.tag = string.Format("HF{0}", numRevision.Value);

            var l = call.GetTickets();
            this.Enabled = true;
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
        }
    }
}
