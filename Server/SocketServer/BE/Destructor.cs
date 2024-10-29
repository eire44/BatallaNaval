using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Destructor : BEBarcos
    {
        public int coordenadaX1 { get; set; }
        public int coordenadaX2 { get; set; }

        public int coordenadaY1 { get; set; }
        public int coordenadaY2 { get; set; }

        public Destructor(bool direccion, int coordenadaX, int coordenadaY)
        {
            Nombre = "Destructor";
            Slots = 2;
            Id = 2;
            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
            Horizontal = direccion;
            Vidas = Slots;
        }
    }
}
