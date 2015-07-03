﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turven_FraGie.Klassen;
using Turven_FraGie.Database_en_Administratie;

namespace Turven_FraGie.Forms
{
    public partial class MaakAccountForm : Form
    {
        // Fields / Properties
        Administratie administratie;
        string error;

        // Constructor(s)
        public MaakAccountForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            administratie = new Administratie();

           // vul alle mogelijke verenigingen
            VulVerenigingen();          
        }

        #region Event Handlers

        /// <summary>
        /// gbMaakPersoon wordt zichtbaar met de juist ingestelde text
        /// </summary>
        private void btnMaakBeheerder_Click_1(object sender, EventArgs e)
        {
            Vereniging v = (Vereniging)lbVerenigingen.SelectedItem;
            MaakPersoon("Beheerder", v.Naam);
        }

        /// <summary>
        /// gbMaakPersoon wordt zichtbaar met de juist ingestelde text
        /// </summary>
        private void btnMaakTurver_Click_1(object sender, EventArgs e)
        {
            Vereniging v = (Vereniging)lbVerenigingen.SelectedItem;
            MaakPersoon("Turver", v.Naam);
        }

        /// <summary>
        /// Aan de hand van de geselecteerde vereniging moet er gecheckt worden of de vereniging al een beheerder heeft
        /// als dat zo is dan kan er niet nog een beheerder aangemaakt worden dit om te voorkomen dat er gekke dingen gaan gebeuren,
        /// het is makkelijker als er altijd één iemand verantwoordelijk is.
        /// </summary>
        private void lbVerenigingen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Vereniging vereniging = (Vereniging)lbVerenigingen.SelectedItem;
            if (administratie.HeeftBeheerder(vereniging.Naam, out error))
            {
                btnMaakBeheerder.Enabled = false;
            }
            else
            {
                btnMaakBeheerder.Enabled = true;
            }
        }

        /// <summary>
        /// Bij het zoeken naar een vereniging moet er case insensitive gekeken worden dit is gebruiksvriendelijker
        /// </summary>
        private void tbZoeken_TextChanged_1(object sender, EventArgs e)
        {
            lbVerenigingen.Items.Clear();
            if (tbZoeken.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbZoeken.Text.ToUpper();
                foreach (Vereniging v in administratie.Verenigingen)
                {
                    vNaam = v.Naam.ToUpper();
                    if (vNaam.Contains(vZoekNaam))
                    {
                        lbVerenigingen.Items.Add(v);
                        lbVerenigingen.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                VulVerenigingen();
            }
        }

        /// <summary>
        /// Hierbij wordt de group box van een te maken persoon invisible gemaakt en de andere groupbox wordt weer enabled
        /// </summary>
        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            Annuleer();
        }

        /// <summary>
        ///  check of de wachtwoorden overeen komen
        ///  check of de inlognaam al bestaat
        ///  als beide checks slagen maak dan een nieuw account aan
        /// </summary>
        private void btnMaakPersoon_Click(object sender, EventArgs e)
        {
            
            if (tbInlogNaam.Text != "")
            {
                if (tbWachtwoord.Text != "" || tbVerifieerWachtwoord.Text != "")
                {
                    if (tbWachtwoord.Text == tbVerifieerWachtwoord.Text)
                    {
                        foreach (Account a in administratie.Accounts)
                        {
                            if (a.InlogNaam == tbInlogNaam.Text)
                            {
                                MessageBox.Show("Inlognaam bestaat al");
                                return;
                            }
                        }
                        if (!administratie.MaakAccount(tbInlogNaam.Text, tbVerenigingNaam.Text, tbWachtwoord.Text, tbAccountType.Text.ToUpper()))
                        {
                            MessageBox.Show("Er ging iets mis met de database, raadpleeg de beheerder van de applicatie");
                        }
                        else
                        {
                            MessageBox.Show("Account aangemaakt");
                            Annuleer();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoorden komen niet overeen");
                    }
                }
                else
                {
                    MessageBox.Show("Voer een wachtwoord in");
                }
            }
            else
            {
                MessageBox.Show("Vul een inlognaam in");
            }
        }

        /// <summary>
        /// Ga terug naar het inlogscherm
        /// </summary>
        private void btnInloggen_Click(object sender, EventArgs e)
        {
            InlogForm inlogForm = new InlogForm();
            inlogForm.Show();
            this.Close();
        }

        #endregion
        #region Methods
        /// <summary>
        /// Vult de lijst van verenigingen
        /// </summary>
       public void VulVerenigingen()
       {
           lbVerenigingen.Items.Clear();
           foreach(Vereniging v in administratie.Verenigingen)
           {
               lbVerenigingen.Items.Add(v);
               lbVerenigingen.SelectedIndex = 0;
           }           
        }

        /// <summary>
        /// Toont de andere group box met de juite informatie in die groupbox
        /// </summary>
       private void MaakPersoon(string accountType, string vereniging)
       {
           gbKiesVereniging.Enabled = false;
           gbMaakPersoon.Text = "Maak " + accountType;
           tbVerenigingNaam.Text = vereniging;
           tbAccountType.Text = accountType;
           btnMaakPersoon.Text = "Maak " + accountType;
           gbMaakPersoon.Visible = true;
       }          

        /// <summary>
        /// Maakt de ene groupbox enabled en de andere invisible
        /// </summary>
        private void Annuleer()
       {
           gbKiesVereniging.Enabled = true;
           gbMaakPersoon.Visible = false;
       }
        #endregion



    }
}
