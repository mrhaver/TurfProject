using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turven_FraGie
{
    public partial class InlogForm : Form
    {
        DatabaseKoppeling databaseKoppeling;
        public InlogForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            databaseKoppeling = new DatabaseKoppeling();
        }

        private void btnMaakAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
