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
            VulCompetities(lbWZoekComp);
            VulCompetities(lbCTCompetities);
            VulVerenigingen(lbVerenigingen);
            VulVerenigingen(lbTeamVerenigingen);
            VulVerenigingen(lbSBVereniging);
            VulTeams(lbTeams);
            VulTeamsComp(lbCTTeams);
            VulTeamsVer(cbSBMaakTeam, lbSBVereniging);
            VulTeamsVer(cbSBWSpeler, lbSBVereniging);
            VulAlleTeamsVer(lbCTVTeams);
            VulAlleSpelers(lbSBSpelers, lbSBVereniging);
            StandaardCombobox(cbSBMaakTeam);
            StandaardCombobox(cbSBFavPos);
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
            VulCompetities(lbWZoekComp);
            VulCompetities(lbCTCompetities);
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
            VulCompetities(lbWZoekComp);
            VulCompetities(lbCTCompetities);
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
                VulCompetities(lbWZoekComp);
                VulCompetities(lbCTCompetities);   
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
                VulCompetities(lbWZoekComp);
                VulCompetities(lbCTCompetities);
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
            VulVerenigingen(lbTeamVerenigingen);
            VulVerenigingen(lbSBVereniging);
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
            if(lbVerenigingen.SelectedItem != null)
            {
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
                VulVerenigingen(lbTeamVerenigingen);
                VulVerenigingen(lbSBVereniging);
            }
            else
            {
                MessageBox.Show("Selecteer een vereniging");
            }
            
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
                VulVerenigingen(lbTeamVerenigingen);
                VulVerenigingen(lbSBVereniging);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        #endregion
        #region Teams
        private void lbTeamVerenigingen_SelectedIndexChanged(object sender, EventArgs e)
        {
            VulTeams(lbTeams);
            if(lbTeams.Items.Count == 0)
            {
                tbWTeamCode.Text = "";
            }
        }

        private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTeams.SelectedItem != null)
            {
                Team team = (Team)lbTeams.SelectedItem;
                tbWTeamCode.Text = team.TeamCode;
            }
            else
            {
                tbWTeamCode.Text = "";
            }
        }

        private void btnMaakTeam_Click(object sender, EventArgs e)
        {
            string error = "";
            Vereniging vereniging = (Vereniging)lbTeamVerenigingen.SelectedItem;
            if (!administratie.MaakTeam(vereniging.Naam, tbTeamCode.Text, out error))
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Team aangemaakt");
                tbTeamCode.Text = "";
                VulTeams(lbTeams);
                VulAlleTeamsVer(lbCTVTeams);
            }
        }

        private void btnWTeamCode_Click(object sender, EventArgs e)
        {
            Team team = (Team)lbTeams.SelectedItem;
            string error = "";
            if (!administratie.WijzigTeam(team.VerenigingNaam, team.ID, tbWTeamCode.Text, out error))
            {
                MessageBox.Show(error);
            }
            else
            {
                MessageBox.Show("Team Gewijzigd");
                tbWTeamCode.Text = "";
                VulTeams(lbTeams);
                VulAlleTeamsVer(lbCTVTeams);
            }
        }

        private void btnVerwijderTeam_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u het team wilt verwijderen\nHierbij worden ook alle spelers uit het team gehaald", "Let Op!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Team team = (Team)lbTeams.SelectedItem;
                if (!administratie.VerwijderTeam(team.ID))
                {
                    MessageBox.Show("Fout in de database");
                }
                else
                {
                    MessageBox.Show("Team verwijderd");
                    VulTeams(lbTeams);
                    VulAlleTeamsVer(lbCTVTeams);
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
        #endregion
        #region CompetitieTeam
        private void tbCTZoekComp_TextChanged(object sender, EventArgs e)
        {
            lbCTCompetities.Items.Clear();
            if (tbCTZoekComp.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbCTZoekComp.Text.ToUpper();
                foreach (Competitie c in administratie.Competities)
                {
                    vNaam = c.Poule.ToUpper();
                    if (vNaam.Contains(vZoekNaam))
                    {
                        lbCTCompetities.Items.Add(c);
                        lbCTCompetities.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                VulCompetities(lbCTCompetities);
            }
        }

        private void lbCTCompetities_SelectedIndexChanged(object sender, EventArgs e)
        {
            VulTeamsComp(lbCTTeams);
        }

        private void tbCTZoekTeamVer_TextChanged(object sender, EventArgs e)
        {
            lbCTVTeams.Items.Clear();
            if (tbCTZoekTeamVer.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbCTZoekTeamVer.Text.ToUpper();
                foreach (Vereniging v in administratie.Verenigingen)
                {
                    foreach (Team t in v.Teams)
                    {
                        vNaam = t.VerenigingNaam.ToUpper();
                        if (vNaam.Contains(vZoekNaam))
                        {
                            lbCTVTeams.Items.Add(t);
                            lbCTVTeams.SelectedIndex = 0;
                        }
                    }
                }
            }
            else
            {
                VulAlleTeamsVer(lbCTVTeams);
            }
        }

        private void btnVoegTeamToe_Click(object sender, EventArgs e)
        {
            if (lbCTVTeams.SelectedItem != null && lbCTCompetities.SelectedItem != null)
            {
                string error = "";
                Team team = (Team)lbCTVTeams.SelectedItem;
                Competitie competitie = (Competitie)lbCTCompetities.SelectedItem;
                if (!administratie.WijsTeamAanCompetitie(team.ID, competitie.Code, out error))
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show("Team Toegevoegd");
                    VulTeamsComp(lbCTTeams);
                }
            }
            else
            {
                MessageBox.Show("Selecteer een competitie en een team");
            }

        }

        private void btnCTVerwijderTeam_Click(object sender, EventArgs e)
        {
            if (lbCTTeams.SelectedItem != null && lbCTCompetities.SelectedItem != null)
            {
                Team team = (Team)lbCTTeams.SelectedItem;
                Competitie competitie = (Competitie)lbCTCompetities.SelectedItem;
                if (!administratie.VerwijderTeamUitCompetitie(team.ID, competitie.Code))
                {
                    MessageBox.Show("Geen connectie met de database");
                }
                else
                {
                    MessageBox.Show("Team Verwijderd");
                    VulTeamsComp(lbCTTeams);
                }
            }
            else
            {
                MessageBox.Show("Selecteer een competitie en een team");
            }
        }


        #endregion
        #region Speler
        private void btnMaakSpeler_Click(object sender, EventArgs e)
        {
            if (tbVoornaam.Text != "" && tbAchternaam.Text != "" && tbRugnummer.Text != "" && cbSBFavPos.SelectedItem.ToString() != "" && lbSBVereniging.SelectedItem != null &&
                cbSBFavPos.SelectedItem.ToString() != "Maak uw keuze" && cbSBMaakTeam.SelectedItem != null && cbSBMaakTeam.SelectedItem.ToString() != "Maak uw keuze")
            {
                string error = "";
                Vereniging vereniging = (Vereniging)lbSBVereniging.SelectedItem;
                Team team = administratie.GeefTeamVer(vereniging.Naam, cbSBMaakTeam.SelectedItem.ToString());
                if (!administratie.MaakSpeler(tbVoornaam.Text, tbAchternaam.Text, Convert.ToInt32(tbRugnummer.Text), cbSBFavPos.SelectedItem.ToString(), vereniging.Naam, team.ID, out error))
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show("Speler Aangemaakt");
                    tbVoornaam.Text = "";
                    tbAchternaam.Text = "";
                    tbRugnummer.Text = "";
                    cbSBFavPos.Items.Clear();
                    cbSBFavPos.Items.Add("Maak uw keuze");
                    cbSBFavPos.SelectedIndex = 0;
                    
                    VulAlleSpelers(lbSBSpelers, lbSBVereniging);
                }
            }
            else
            {
                MessageBox.Show("Vul alle velden in");
            }
        }

        private void tbSBZoekSpeler_TextChanged(object sender, EventArgs e)
        {
            StandaardCombobox(cbSBFavPos);
            StandaardCombobox(cbSBMaakTeam);
            lbSBSpelers.Items.Clear();
            if (tbSBZoekSpeler.Text != "")
            {
                string vVoornaam;
                string vAchternaam;
                string vZoekNaam = tbSBZoekSpeler.Text.ToUpper();
                foreach(Vereniging v in administratie.Verenigingen)
                {
                    Vereniging vereniging = (Vereniging)lbSBVereniging.SelectedItem;
                    if(v.Naam == vereniging.Naam)
                    {
                        foreach (Speler s in v.Spelers)
                        {
                            vVoornaam = s.Voornaam.ToUpper();
                            vAchternaam = s.Achternaam.ToUpper();
                            if (vVoornaam.Contains(vZoekNaam) || vAchternaam.Contains(vZoekNaam))
                            {
                                lbSBSpelers.Items.Add(s);
                                lbSBSpelers.SelectedIndex = 0;
                            }
                        }
                    }
                }
                
            }
            else
            {
                VulAlleSpelers(lbSBSpelers, lbSBVereniging);
            }
        }

        private void lbSBSpelers_SelectedIndexChanged(object sender, EventArgs e)
        {
            StandaardCombobox(cbSBMaakTeam);
            StandaardCombobox(cbSBFavPos);
            if (lbSBSpelers.SelectedItem != null)
            {
                VulPosities(cbSBWFavPos);
                Speler speler = (Speler)lbSBSpelers.SelectedItem;
                tbWSpelerVoornaam.Text = speler.Voornaam;
                tbWSpelerAchternaam.Text = speler.Achternaam;
                tbWSpelerRugnummer.Text = Convert.ToString(speler.Rugnummer);
                cbSBWFavPos.SelectedItem = speler.EerstePositie();
                if (lbSBSpelers.SelectedItem != null)
                {
                    Speler gekozenSpeler = (Speler)lbSBSpelers.SelectedItem;
                    Team team = gekozenSpeler.EersteTeam();
                    cbSBWSpeler.SelectedItem = team.TeamCode;
                }
                else
                {
                    tbWSpelerVoornaam.Text = "";
                    tbWSpelerAchternaam.Text = "";
                    tbWSpelerRugnummer.Text = "";
                    cbSBWFavPos.Items.Clear();
                    cbSBWSpeler.Items.Clear();
                }
            }
            else
            {
                tbWSpelerVoornaam.Text = "";
                tbWSpelerAchternaam.Text = "";
                tbWSpelerRugnummer.Text = "";
                cbSBWFavPos.SelectedIndex = 0;
                cbSBWSpeler.Items.Clear();
            }
        }

        private void btnWijzigSpeler_Click(object sender, EventArgs e)
        {
            string error = "";
            if (lbSBSpelers.SelectedItem != null)
            {
                Speler speler = (Speler)lbSBSpelers.SelectedItem;
                Vereniging vereniging = (Vereniging)lbSBVereniging.SelectedItem;
                Team team = administratie.GeefTeamVer(vereniging.Naam, cbSBWSpeler.SelectedItem.ToString());
                if (!administratie.WijzigSpeler(speler.ID, tbWSpelerVoornaam.Text, tbWSpelerAchternaam.Text, Convert.ToInt32(tbWSpelerRugnummer.Text), cbSBWFavPos.SelectedItem.ToString(), vereniging.Naam, team.ID, speler.Rugnummer,
                    speler.EersteTeam().ID, out error))
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show("Speler Gewijzigd");
                    VulAlleSpelers(lbSBSpelers, lbSBVereniging);
                }
            }

        }

        private void btnVerwijderSpeler_Click(object sender, EventArgs e)
        {
            if (lbSBSpelers.SelectedItem != null)
            {
                Speler speler = (Speler)lbSBSpelers.SelectedItem;
                if (!administratie.VerwijderSpeler(speler.ID))
                {
                    MessageBox.Show("Fout in de database");
                }
                else
                {
                    tbWSpelerVoornaam.Text = "";
                    tbWSpelerAchternaam.Text = "";
                    tbWSpelerRugnummer.Text = "";
                    cbSBWFavPos.SelectedIndex = 0;
                    MessageBox.Show("Speler verwijderd");
                    VulAlleSpelers(lbSBSpelers, lbSBVereniging);
                }
            }
        }

        private void tbSBZoekVereniging_TextChanged(object sender, EventArgs e)
        {
            StandaardCombobox(cbSBFavPos);
            StandaardCombobox(cbSBMaakTeam);
            lbSBVereniging.Items.Clear();
            if (tbSBZoekVereniging.Text != "")
            {
                string vNaam;
                string vZoekNaam = tbSBZoekVereniging.Text.ToUpper();
                foreach (Vereniging v in administratie.Verenigingen)
                {
                    vNaam = v.Naam.ToUpper();
                    if (vNaam.Contains(vZoekNaam))
                    {
                        lbSBVereniging.Items.Add(v);
                        lbSBVereniging.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                VulVerenigingen(lbSBVereniging);
            }
        }

        private void lbSBVereniging_SelectedIndexChanged(object sender, EventArgs e)
        {
            StandaardCombobox(cbSBFavPos);
            StandaardCombobox(cbSBMaakTeam);
            if (lbSBVereniging.SelectedItem != null)
            {
                Vereniging vereniging = (Vereniging)lbSBVereniging.SelectedItem;
                gbMaakSpeler.Text = "Maak Speler voor\n" + vereniging.Naam;
                VulTeamsVer(cbSBWSpeler, lbSBVereniging);
                VulAlleSpelers(lbSBSpelers, lbSBVereniging);
                // selecteer het juiste team uit alle teams van die vereniging
                if (lbSBSpelers.SelectedItem != null)
                {
                    Speler speler = (Speler)lbSBSpelers.SelectedItem;
                    Team team = speler.EersteTeam();
                    cbSBWSpeler.SelectedItem = team;

                }
                else
                {
                    tbWSpelerVoornaam.Text = "";
                    tbWSpelerAchternaam.Text = "";
                    tbWSpelerRugnummer.Text = "";
                    cbSBWSpeler.Items.Clear();
                    cbSBWFavPos.Items.Clear();
                }
            }
        }

        private void cbSBFavPos_MouseClick(object sender, MouseEventArgs e)
        {
            VulPosities(cbSBFavPos);
        }

        private void cbSBMaakTeam_MouseClick(object sender, MouseEventArgs e)
        {
            VulTeamsVer(cbSBMaakTeam, lbSBVereniging);
        }
        #endregion

        private void btnTerug_Click(object sender, EventArgs e)
        {
            SysteemKiezerForm sysKiezerForm = new SysteemKiezerForm();
            sysKiezerForm.Show();
            this.Close();
        }

        #endregion
        #region Methods
        private void VulCompetities(ListBox lb)
        {
            lb.Items.Clear();
            foreach (Competitie c in administratie.Competities)
            {
                lb.Items.Add(c);
                lb.SelectedIndex = 0;
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

        private void VulTeams(ListBox lb)
        {
            if(lbTeamVerenigingen.SelectedItem != null)
            {
                lb.Items.Clear();
                Vereniging vereniging = (Vereniging)lbTeamVerenigingen.SelectedItem;
                foreach(Vereniging v in administratie.Verenigingen)
                {
                    if(v.Naam == vereniging.Naam)
                    {
                        foreach(Team t in v.Teams)
                        {
                            if(t.VerenigingNaam == vereniging.Naam)
                            {
                                lb.Items.Add(t);
                                lb.SelectedIndex = 0;
                            }
                        }
                    }
                }
                
            }
        }

        private void VulTeamsComp(ListBox lb)
        {
            if(lbCTCompetities.SelectedItem != null)
            {
                lb.Items.Clear();
                Competitie competitie = (Competitie)lbCTCompetities.SelectedItem;
                foreach(Competitie c in administratie.Competities)
                {
                    if(c.Code == competitie.Code)
                    {
                        foreach(Team t in c.Teams)
                        {
                            lb.Items.Add(t);
                            lb.SelectedIndex = 0;
                            if(c.Teams.Count == 1)
                            {
                                lblCompetitieTeams.Text = c.Teams.Count + " team in deze competitie";
                            }
                            else
                            {
                                lblCompetitieTeams.Text = c.Teams.Count + " teams in deze competitie";
                            }                          
                        }
                    }
                }
                
            }
        }

        private void VulAlleTeamsVer(ListBox lb)
        {
            lb.Items.Clear();
            foreach (Vereniging v in administratie.Verenigingen)
            {
                foreach (Team t in v.Teams)
                {
                    lb.Items.Add(t);
                    lb.SelectedIndex = 0;
                }
            }           
        }

        private void VulAlleSpelers(ListBox lbS, ListBox lbV)
        {
            lbS.Items.Clear();
            Vereniging vereniging = (Vereniging)lbV.SelectedItem;
            foreach(Vereniging v in administratie.Verenigingen)
            {
                if(vereniging.Naam == v.Naam)
                {
                    foreach (Speler s in v.Spelers)
                    {
                        lbS.Items.Add(s);
                        lbS.SelectedIndex = 0;
                    }
                }
            }

        }

        private void VulTeamsVer(ComboBox cb, ListBox lb)
        {            
            foreach(Vereniging v in administratie.Verenigingen)
            {
                Vereniging vereniging = (Vereniging)lb.SelectedItem;
                if (v.Naam == vereniging.Naam)
                {
                    cb.Items.Clear();
                    foreach(Team t in vereniging.Teams)
                    {
                        cb.Items.Add(t.TeamCode);
                        cb.SelectedIndex = 0;
                    }
                }
            }
        }

        private void VulPosities(ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add("Buiten");
            cb.Items.Add("Midden");
            cb.Items.Add("Diagonaal");
            cb.Items.Add("Spelverdeler");
            cb.Items.Add("Libero");
            cb.SelectedIndex = 0;
        }

        private void StandaardCombobox(ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add("Maak uw keuze");
            cb.SelectedIndex = 0;
        }

        #endregion  

        



    }
}
