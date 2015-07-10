using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turven_FraGie.Klassen
{
    public class Positie
    {
        // Fields / Properties
        private int id;
        private int speler_id;
        private string positieType;

        public int ID
        {
            get { return id; }
        }

        public int Speler_ID
        {
            get { return speler_id; }
        }

        public string PositieType
        {
            get { return positieType; }
        }

        // Constructor(s)
        public Positie(int id, int speler_id, string positieType)
        {
            this.id = id;
            this.speler_id = speler_id;
            this.positieType = positieType;
        }

        // Methods
    }
}
