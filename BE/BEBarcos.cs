using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBarcos
    {
        public string Nombre {  get; set; }

        public int Id { get; set; }

        public int Slots { get; set; }

        public bool Horizontal { get; set; }

        public int CoordenadaX { get; set; }

        public int CoordenadaY { get; set; }
    }
}
