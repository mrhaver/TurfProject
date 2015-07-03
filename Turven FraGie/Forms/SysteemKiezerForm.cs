using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turven_FraGie.Database_en_Administratie;

namespace Turven_FraGie.Forms
{
    public partial class SysteemKiezerForm : Form
    {
        // Fields / Properties
        Administratie administratie;

        // Constructor(s)

        /// <summary>
        /// als het account dat nu ingelogd turver is wordt deze meteen doorverwezen naar het turven
        /// </summary>
        public SysteemKiezerForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            administratie = new Administratie();
            VerwijsDoor();
        }

       
        // Event Handlers
        /// <summary>
        /// Verwijs door voor het turven van een wedstrijd.
        /// </summary>
        private void btnTurfWedstrijd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dit wordt later pas geïmplementeerd");
        }

        /// <summary>
        /// Ga terug naar het inlogform
        /// </summary>
        private void btnTerug_Click(object sender, EventArgs e)
        {
            InlogForm inlogForm = new InlogForm();
            inlogForm.Show();
            this.Close();
        }

        // Methods

        /// <summary>
        /// als het nuingelogde account een turver is wordt deze meteen doorverwezen
        /// </summary>
        private void VerwijsDoor()
        {
            // op dit moment kan de turver nog niets
            if(administratie.NuIngelogd.AccountType == "TURVER")
            {

            }
        }


    }
}
