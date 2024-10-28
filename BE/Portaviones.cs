using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Portaviones : BEBarcos
    {
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
