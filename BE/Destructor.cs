using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Destructor : BEBarcos
    {

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
