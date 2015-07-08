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
            VulVerenigingen(lbVerenigingen);
            VulVerenigingen(lbTeamVerenigingen);
            VulTeams();
        }

        #region Event Handlers
        #region Competitie
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
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u de competitie wilt verwijderen?", "Let Op!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string error = "";
                if (tbWcode.Text != "")
                {
                    if (!administratie.VerwijderCompetitie(tbWcode.Text, out error))
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
            else if (dialogResult == DialogResult.No)
            {
                
            }                  
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
        #region Vereniging

        private void btnMaakVereniging_Click(object sender, EventArgs e)
        {
            string error = "";
            if (!administratie.MaakVereniging(tbVerenigingNaam.Text, tbSporthalNaam.Text, tbVerenigingPlaats.Text,
                tbVerenigingPostcode.Text, tbVerenigingHuisnummer.Text, out error))
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Vereniging aangemaakt");
                tbVerenigingNaam.Text = "";
                tbSporthalNaam.Text = "";
                tbVerenigingPlaats.Text = "";
                tbVerenigingPostcode.Text = "";
                tbVerenigingHuisnummer.Text = "";
            }
            VulVerenigingen(lbVerenigingen);
        }

        private void tbZoekVNaam_TextChanged(object sender, EventArgs e)
        {
            lbVerenigingen.Items.Clear();
            if (tbZoekVNaam.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbZoekVNaam.Text.ToUpper();
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
                VulVerenigingen(lbVerenigingen);
            }
        }

        private void btnWijzigVereniging_Click(object sender, EventArgs e)
        {
            string error = "";
            Vereniging vereniging = (Vereniging)lbVerenigingen.SelectedItem;
            if (!administratie.WijzigVereniging(tbWVNaam.Text, vereniging.Naam, tbWVSporthalNaam.Text, tbWVPlaats.Text, tbWVPostcode.Text, tbWVHuisNummer.Text, vereniging.Locatie.ID, out error))
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Vereniging Gewijzigd");
            }
            VulVerenigingen(lbVerenigingen);
        }

        private void lbVerenigingen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbVerenigingen.SelectedItem != null)
            {
                Vereniging vereniging = (Vereniging)lbVerenigingen.SelectedItem;
                tbWVNaam.Text = vereniging.Naam;
                tbWVSporthalNaam.Text = vereniging.Locatie.SporthalNaam;
                tbWVPlaats.Text = vereniging.Locatie.Plaats;
                tbWVPostcode.Text = vereniging.Locatie.Postcode;
                tbWVHuisNummer.Text = vereniging.Locatie.Huisnummer;
            }
        }

        private void btnVerwijderVereniging_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u de vereniging wilt verwijderen?\nHierbij verwijdert u ook alle teams, accounts en locatie van de vereniging!", "Let Op!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Vereniging vereniging = (Vereniging)lbVerenigingen.SelectedItem;
                if (!administratie.VerwijderVereniging(vereniging.Naam))
                {
                    MessageBox.Show("Vereniging kon niet verwijderd worden");
                }
                else
                {
                    MessageBox.Show("Vereniging verwijderd");
                }
                VulVerenigingen(lbVerenigingen);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        #endregion
        #region Teams

        #endregion

        private void btnTerug_Click(object sender, EventArgs e)
        {
            SysteemKiezerForm sysKiezerForm = new SysteemKiezerForm();
            sysKiezerForm.Show();
            this.Close();
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

        private void VulVerenigingen(ListBox lb)
        {
            lb.Items.Clear();
            foreach(Vereniging v in administratie.Verenigingen)
            {
                lb.Items.Add(v);
                lb.SelectedIndex = 0;
            }
        }

        private void VulTeams()
        {
            if(lbTeamVerenigingen.SelectedItem != null)
            {
                lbTeams.Items.Clear();
                Vereniging vereniging = (Vereniging)lbTeamVerenigingen.SelectedItem;
                foreach(Vereniging v in administratie.Verenigingen)
                {
                    if(v.Naam == vereniging.Naam)
                    {
                        foreach(Team t in v.Teams)
                        {
                            if(t.VerenigingNaam == vereniging.Naam)
                            {
                                lbTeams.Items.Add(t);
                                lbTeams.SelectedIndex = 0;
                            }
                        }
                    }
                }
                
            }
        }
        #endregion

        private void lbTeamVerenigingen_SelectedIndexChanged(object sender, EventArgs e)
        {
            VulTeams();
        }

        private void btnMaakTeam_Click(object sender, EventArgs e)
        {
            string error = "";
            Vereniging vereniging = (Vereniging)lbTeamVerenigingen.SelectedItem;
            if(!administratie.MaakTeam(vereniging.Naam, tbTeamCode.Text, out error))
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Team aangemaakt");
                tbTeamCode.Text = "";
                VulTeams();
            }
        }

        private void btnWTeamCode_Click(object sender, EventArgs e)
        {
            Team team = (Team)lbTeams.SelectedItem;
            if (!administratie.WijzigTeam(team.ID, tbWTeamCode.Text))
            {
                MessageBox.Show("Fout in de database");
            }
            else
            {
                MessageBox.Show("Team Gewijzigd");
                tbWTeamCode.Text = "";
                VulTeams();
            }
        }

        private void btnVerwijderTeam_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u het team wilt verwijderen\nHierbij worden ook alle spelers uit het team gehaald", "Let Op!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Team team = (Team)lbTeams.SelectedItem;
                if(!administratie.VerwijderTeam(team.ID))
                {
                    MessageBox.Show("Fout in de database");
                }
                else
                {
                    MessageBox.Show("Team verwijderd");
                    VulTeams();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void tbZoekVerenigingTeam_TextChanged(object sender, EventArgs e)
        {
            lbTeamVerenigingen.Items.Clear();
            if (tbZoekVerenigingTeam.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbZoekVerenigingTeam.Text.ToUpper();
                foreach (Vereniging v in administratie.Verenigingen)
                {
                    vNaam = v.Naam.ToUpper();
                    if (vNaam.Contains(vZoekNaam))
                    {
                        lbTeamVerenigingen.Items.Add(v);
                        lbTeamVerenigingen.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                VulVerenigingen(lbTeamVerenigingen);
            }
        }


    }
}
