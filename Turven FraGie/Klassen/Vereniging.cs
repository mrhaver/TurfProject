using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Vereniging
    {
        // Fields / Properties
        private string naam;
        private Locatie locatie;
        private List<Team> teams;
        private List<Speler> spelers;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public Locatie Locatie
        {
            get { return locatie; }
        }

        public List<Team> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        public List<Speler> Spelers
        {
            get { return spelers; }
            set { spelers = value; }
        }

        // Constructor(s)
        public Vereniging(string naam)
        {
            this.naam = naam;
            this.locatie = new Locatie();
            this.teams = new List<Team>();
            this.spelers = new List<Speler>();
        }

        public Vereniging(string naam, Locatie locatie)
        {
            this.naam = naam;
            this.locatie = locatie;
        }

        // Methods

        public override string ToString()
        {
            return this.naam;
        }
    }
}
