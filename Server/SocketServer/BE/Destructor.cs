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
            Id = 2;
            Horizontal = direccion;
            Vidas = 2;
            CoordenadaX = new int[Vidas];
            CoordenadaY = new int[Vidas];
            CalcularCoordenadas(coordenadaX, coordenadaY);
        }

        public override void CalcularCoordenadas(int x, int y)
        {
            for (int i = 0; i < 2; i++)
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
