using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Portaviones : BEBarcos
    {
        public int coordenadaX1 { get; set; }
        public int coordenadaX2 { get; set; }
        public int coordenadaX3 { get; set; }
        public int coordenadaX4 { get; set; }

        public int coordenadaY1 { get; set; }
        public int coordenadaY2 { get; set; }
        public int coordenadaY3 { get; set; }
        public int coordenadaY4 { get; set; }

        public Portaviones(bool direccion, int coordenadaX, int coordenadaY) 
        {
            Nombre = "Portaviones";
            Slots = 4;
            Id = 0;
            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
            Horizontal = direccion;
            Vidas = Slots;
        }
        

    }
}
