using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turven_FraGie.Forms;

namespace Turven_FraGie
{
    public partial class InlogForm : Form
    {
        public InlogForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void btnMaakAccount_Click(object sender, EventArgs e)
        {
            MaakAccountForm accountForm = new MaakAccountForm();
            accountForm.Show();
            this.Hide();
        }
    }
}
