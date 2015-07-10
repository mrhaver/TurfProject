using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Speler
    {
        // Fields / Properties
        private int id;
        private string voornaam;
        private string achternaam;
        private int rugnummer;
        private List<Positie> posities;
        private List<Team> teams;

        public int ID
        {
            get { return id; }
        }

        public string Voornaam
        {
            get { return voornaam; }
        }

        public string Achternaam
        {
            get { return achternaam; }
        }

        public int Rugnummer
        {
            get { return rugnummer; }
        }

        public List<Positie> Posities
        {
            get { return posities; }
            set { posities = value; }
        }

        public List<Team> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        // Constructors
        public Speler(int id, string voornaam, string achternaam, int rugnummer)
        {
            this.id = id;
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.rugnummer = rugnummer;
            posities = new List<Positie>();
            teams = new List<Team>();
        }

        // Methods

        public string EerstePositie()
        {
            foreach(Positie p in posities)
            {
                return p.PositieType;
            }
            return "";
        }

        public Team EersteTeam()
        {
            foreach(Team t in teams)
            {
                return t;
            }
            return null;
        }

        public override string ToString()
        {
            return voornaam + " " + achternaam + " " + EersteTeam().TeamCode + " " + EerstePositie() + " Nr: " + rugnummer;
        }
    }
}
