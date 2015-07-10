using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Team
    {
        // Fields / Properties
        private int id;
        private string verenigingNaam;
        private string teamCode;
        private List<Speler> spelers;

        public int ID
        {
            get { return id; }
        }
        public string VerenigingNaam
        {
            get { return verenigingNaam; }
        }

        public string TeamCode
        {
            get { return teamCode; }
        }

        public List<Speler> Spelers
        {
            get { return spelers; }
            set { spelers = value; }
        }

        // Constructor(s)
        public Team(string verenigingNaam, string teamCode, int id)
        {
            this.id = id;
            this.verenigingNaam = verenigingNaam;
            this.teamCode = teamCode;
            spelers = new List<Speler>();
        }

        // Methods
        public override string ToString()
        {
            return this.verenigingNaam + " " + teamCode;
        }
    }
}
