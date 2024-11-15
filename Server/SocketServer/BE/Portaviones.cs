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
            Id = 0;
            Horizontal = direccion;
            Vidas = 4;
            CoordenadaX = new int[Vidas];
            CoordenadaY = new int[Vidas];
            CalcularCoordenadas(coordenadaX, coordenadaY);
        }

        public override void CalcularCoordenadas(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Horizontal)
                {
                    CoordenadaX[i] = x + i;
                    CoordenadaY[i] = y;
                }
                else
                {
                    CoordenadaX[i] = x;
                    CoordenadaY[i] = y + i;
                }
            }
        }
    }
}
