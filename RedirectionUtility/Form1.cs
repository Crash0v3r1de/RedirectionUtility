using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedirectionUtility.Lists;
using RedirectionUtility.Utils;

namespace RedirectionUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Application.UserAppDataPath.Contains("-su"))
            {
                MessageBox.Show("This needs to be ran under your superuser!");
            }
            else
            {
                var depts = ConfigUtil.GetDepartments();
                if (depts != null)
                {
                    StaticDepartments.Departments.AddRange(depts);
                    foreach (var dept in depts)
                    {
                        drpDepartment.Items.Add(dept);
                    }
                }
            }
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void validateIdentikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AD ad = new AD();
            MessageBox.Show(ad.UserPresent(txtUsername.Text).ToString());
        }

        private void allOfTheAboveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Network net = new Network();
            if (net.ProcessAll((string)drpDepartment.SelectedItem, txtUsername.Text))
            {
                MessageBox.Show("Done?");
            }
            else MessageBox.Show("Failed");
        }
    }
}
