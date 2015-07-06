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
using Turven_FraGie.Klassen;

namespace Turven_FraGie.Forms
{
    public partial class TeamBeheer : Form
    {
        // Fields / Properties
        Administratie administratie;

        // Constructor(s)
        public TeamBeheer()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            administratie = new Administratie();
            VulCompetities();
        }

        #region Event Handlers
        private void btnMaakComp_Click(object sender, EventArgs e)
        {
            string error = "";
            if(tbCompCode.Text != "" && tbCompNiveau.Text != "" && tbCompPoule.Text != "" && tbCompRegio.Text != "")
            {
                if (!administratie.MaakCompetitie(tbCompCode.Text, tbCompNiveau.Text, tbCompPoule.Text, tbCompRegio.Text, out error))
                {
                    MessageBox.Show(error);
                    return;
                }
                else
                {
                    MessageBox.Show("Competitie Toegevoegd");
                    tbCompCode.Text = "";
                    tbCompNiveau.Text = "";
                    tbCompPoule.Text = "";
                    tbCompRegio.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vul alle tekstvelden in");
                return;
            }
            VulCompetities();
        }

        private void btnWijzigComp_Click(object sender, EventArgs e)
        {
            string error = "";
            if(tbWcode.Text != "" && tbWNiveau.Text != "" && tbWPoule.Text != "" && tbWRegio.Text != "")
            {
                if(!administratie.WijzigCompetitie(tbWcode.Text,tbWNiveau.Text,tbWPoule.Text,tbWRegio.Text, out error))
                {
                    MessageBox.Show(error);
                    return;
                }
                else
                {
                    MessageBox.Show("Competitie gewijzigd");
                }
            }
            else
            {
                MessageBox.Show("Vul alle tekstvelden in");
                return;
            }
            VulCompetities();
        }

        private void lbWZoekComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbWZoekComp.SelectedItem != null)
            {
                Competitie competitie = (Competitie)lbWZoekComp.SelectedItem;
                tbWcode.Text = competitie.Code;
                tbWNiveau.Text = competitie.Niveau;
                tbWPoule.Text = competitie.Poule;
                tbWRegio.Text = competitie.Regio;
            }
        }


        private void btnVerwijderComp_Click(object sender, EventArgs e)
        {
            string error = "";
            if(tbWcode.Text != "")
            {
                if(!administratie.VerwijderCompetitie(tbWcode.Text, out error))
                {
                    MessageBox.Show(error);
                    return;
                }
                else
                {
                    MessageBox.Show("Competitie Verwijderd");
                    tbWcode.Text = "";
                    tbWNiveau.Text = "";
                    tbWPoule.Text = "";
                    tbWRegio.Text = "";
                    tbWZoekComp.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vul wel een competitiecode in");
                return;
            }
            VulCompetities();          
        }

        private void tbWZoekComp_TextChanged(object sender, EventArgs e)
        {

            lbWZoekComp.Items.Clear();
            if (tbWZoekComp.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbWZoekComp.Text.ToUpper();
                foreach (Competitie c in administratie.Competities)
                {
                    vNaam = c.Poule.ToUpper();
                    if (vNaam.Contains(vZoekNaam))
                    {
                        lbWZoekComp.Items.Add(c);
                        lbWZoekComp.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                VulCompetities();
            }
        }

        #endregion
        #region Methods
        private void VulCompetities()
        {
            lbWZoekComp.Items.Clear();
            foreach (Competitie c in administratie.Competities)
            {
                lbWZoekComp.Items.Add(c);
                lbWZoekComp.SelectedIndex = 0;
            }
        }

        #endregion

    }
}
