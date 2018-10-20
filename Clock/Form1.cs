using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            display = display2 = display3 = "00";
            count = count2 = count3 = 0;
        }

        public bool run { get; private set; }
        public int count { get; private set; }
        public string display { get; private set; }
        public int count2 { get; private set; }
        public string display2 { get; private set; }
        public string output { get; private set; }
        public int count3 { get; private set; }
        public string display3 { get; private set; }

        private void btn_start_Click(object sender, EventArgs e)
        {
            run = true;
        }

        private void time_Tick(object sender, EventArgs e)
        {
            if (run == true)
            {
                count++;
                if (count >= 60)
                {
                    count = 0;
                    count2++;
                }

                if (count2 >= 60)
                {
                    count2 = 0;
                    count3++;
                }
            
                if (count < 10)
                {
                    display = "0" + count.ToString();
                } else
                {
                    display = count.ToString();
                }

                if (count2 < 10)
                {
                    display2 = "0" + count2.ToString();
                }
                else
                {
                    display2 = count2.ToString();
                }

                if (count3 < 10)
                {
                    display3 = "0" + count3.ToString();
                }
                else
                {
                    display3 = count3.ToString();
                }
            }
            output = display3 + ":" + display2 + ":" + display;
            clock.Text = output;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            run = false;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            run = false;
            count = count2 = count3 = 0;
            display = display2 = display3 = "00";
            output = display3 + ":" + display2 + ":" + display;
            clock.Text = output;
        }

        private void btn_runde_Click(object sender, EventArgs e)
        {
            box_runde.Items.Insert(0,output);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            box_runde.Items.Clear();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://clock.logilutions.de/help");
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run = false;
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run = false;
            count = count2 = count3 = 0;
            display = display2 = display3 = "00";
            output = display3 + ":" + display2 + ":" + display;
            clock.Text = output;
        }

        private void rundeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            box_runde.Items.Insert(0, output);
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            box_runde.Items.Clear();
        }

        private void rundeExportierenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new settings();
            settings.Show();
        }

        private void kreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var credits = new credits();
            credits.Show();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName.ToString();
            Console.WriteLine(name);
            Console.WriteLine(output);
            using (StreamWriter outputFile = new StreamWriter(name))
            {
                outputFile.WriteLine(output);
            }
        }
    }
}
