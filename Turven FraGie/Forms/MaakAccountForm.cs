using System;
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
        Administratie administratie;
        string error;

        public MaakAccountForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            administratie = new Administratie();

           // vul alle mogelijke verenigingen
            VulVerenigingen(); 
          
        }

       public void VulVerenigingen()
       {
           lbVerenigingen.Items.Clear();
           foreach(Vereniging v in administratie.Verenigingen)
           {
               lbVerenigingen.Items.Add(v);
               lbVerenigingen.SelectedIndex = 0;
           }           
        }

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

       private void btnAnnuleer_Click(object sender, EventArgs e)
       {
           Annuleer();
       }

       private void btnMaakPersoon_Click(object sender, EventArgs e)
       {
           // check of de wachtwoorden overeen komen
           // check of de inlognaam al bestaat
           // als beide checks slagen maak dan een nieuw account aan
           if (tbInlogNaam.Text != "")
           {
               if (tbWachtwoord.Text != "" ||  tbVerifieerWachtwoord.Text != "")
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

        private void Annuleer()
       {
           gbKiesVereniging.Enabled = true;
           gbMaakPersoon.Visible = false;
       }

        private void btnInloggen_Click(object sender, EventArgs e)
        {
            InlogForm inlogForm = new InlogForm();
            inlogForm.Show();
            this.Close();
        }


    }
}
