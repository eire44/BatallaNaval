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
            Nombre = "Lancha";
            Id = 3;
            Horizontal = direccion;
            Vidas = 1;
            coordenadas = new Coordenadas(Vidas);
            //CoordenadaX = new int[Vidas];
            //CoordenadaY = new int[Vidas];
            CalcularCoordenadas(coordenadaX, coordenadaY);
        }
    }
}
