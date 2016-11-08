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
            call.DoCall();
            this.Enabled = true;
        }
    }
}
