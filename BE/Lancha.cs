using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Lancha : BEBarcos
    {
        public Lancha(bool direccion, int coordenadaX, int coordenadaY)
        {
            Nombre = "Acorazado";
            Slots = 3;
            Id = 1;
            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
            Horizontal = direccion;
        }
    }
}
