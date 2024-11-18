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
            coordenadas = new Coordenadas(Vidas);
            //CoordenadaX = new int[Vidas];
            //CoordenadaY = new int[Vidas];
            CalcularCoordenadas(coordenadaX, coordenadaY);
        }

        public override void CalcularCoordenadas(int x, int y)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Horizontal)
                {
                    coordenadas.cargarCoordenadas(i, x + i, y);

                    //CoordenadaX[i] = x + i;
                    //CoordenadaY[i] = y;
                }
                else
                {
                    coordenadas.cargarCoordenadas(i, x, y + i);
                    //CoordenadaX[i] = x;
                    //CoordenadaY[i] = y + i;
                }
            }
        }
    }
}
