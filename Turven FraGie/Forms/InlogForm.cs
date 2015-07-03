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
using Turven_FraGie.Database_en_Administratie;
using Turven_FraGie.Klassen;

namespace Turven_FraGie
{
    public partial class InlogForm : Form
    {

        // Fields / Properties
        Administratie administratie;

        // Constructor(s)
        public InlogForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            administratie = new Administratie();
        }

        /// <summary>
        /// Gaat naar het formulier voor het maken van een account.
        /// </summary>
        private void btnMaakAccount_Click(object sender, EventArgs e)
        {
            MaakAccountForm accountForm = new MaakAccountForm();
            accountForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Zoekt in alle accounts naar het account met dezelfde inlognaam en geeft daarbij 
        /// </summary>
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        /// <summary>
        /// Als er op enter wordt gedrukt dan moet er worden ingelogd.
        /// </summary>
        private void tbWachtwoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        // Methods

        /// <summary>
        /// als er op de button geklikt wordt of als er op enter getikt wordt moet er
        /// worden ingelogd.
        /// </summary>
        private void LogIn()
        {
            foreach (Account a in administratie.Accounts)
            {
                if (a.InlogNaam == tbInlognaam.Text)
                {
                    if (a.LogIn(tbWachtwoord.Text))
                    {
                        administratie.NuIngelogd = administratie.GeefAccount(tbInlognaam.Text);
                        if (administratie.NuIngelogd.AccountType == "TURVER")
                        {
                            MessageBox.Show("Er kan nog niet geturfd worden");
                        }
                        else
                        {
                            SysteemKiezerForm sysKiezerForm = new SysteemKiezerForm();
                            sysKiezerForm.Show();
                            this.Hide();
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Foute inlognaam- wachtwoordcombinatie");
                        return;
                    }
                }
            }
            MessageBox.Show("Inlognaam niet gevonden");
        }


    }
}
