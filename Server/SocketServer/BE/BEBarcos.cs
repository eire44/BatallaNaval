using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBarcos
    {
        public string Nombre { get; set; }

        public int Id { get; set; }

        public bool Horizontal { get; set; }
        internal Coordenadas coordenadas;


        public int Vidas { get; set; }

        public int Jugador { get; set; }

        virtual public void CalcularCoordenadas(int x, int y)
        {
            coordenadas.cargarCoordenadas(0, x, y);
        }

        public int devolverX(int indice)
        {
            return coordenadas.devolverX(indice);
        }

        public int devolverY(int indice)
        {
            return coordenadas.devolverY(indice);
        }
    }
}
