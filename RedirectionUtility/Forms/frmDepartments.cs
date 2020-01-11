using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedirectionUtility.Lists;

namespace RedirectionUtility.Forms
{
    public partial class frmDepartments : Form
    {
        public frmDepartments()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            if (StaticDepartments.Departments.Count != 0)
            {
                foreach (var dept in StaticDepartments.Departments)
                {
                    lstDepartments.Items.Add(dept);
                }
            }
        }
    }
}
