using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class credits : Form
    {
        public credits()
        {
            InitializeComponent();
            version.Text = "1.3";
            date.Text = "20.10.2018";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://clock.logilutions.de");
        }

        private void version_Click(object sender, EventArgs e)
        {

        }
    }
}
