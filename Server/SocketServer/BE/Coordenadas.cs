using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    internal class Coordenadas
    {
        internal int[] coordenadaX { private get; set; }

        internal int[] coordenadaY { private get; set; }

        internal Coordenadas(int i)
        {
            coordenadaX = new int[i];
            coordenadaY = new int[i];
        }

        internal void cargarCoordenadas(int indice, int x, int y)
        {
            coordenadaX[indice] = x;
            coordenadaY[indice] = y;
        }

        internal int devolverX(int indice)
        {
            return coordenadaX[indice];
        }

        internal int devolverY(int indice)
        {
            return coordenadaY[indice];
        }
    }
}
