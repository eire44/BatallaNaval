using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BLMetodos
    {
        Persistencia persistencia = new Persistencia();

        public delegate void retornarInfoAUI(string s);
        public event retornarInfoAUI RetornarAUI;

        public void pasarAInsertar(List<Datos> datos, int jugador)
        {
            foreach (Datos dato in datos)
            {
                BEBarcos barco;
                if (dato.idBarco == 0)
                {
                    barco = new Portaviones(dato.horizontal, dato.x, dato.y);

                }
                else if (dato.idBarco == 1)
                {
                    barco = new Acorazado(dato.horizontal, dato.x, dato.y);
                }
                else if (dato.idBarco == 2)
                {
                    barco = new Destructor(dato.horizontal, dato.x, dato.y);
                }
                else if (dato.idBarco == 3)
                {
                    barco = new Lancha(dato.horizontal, dato.x, dato.y);
                }
                else
                {
                    barco = null;
                }
                barco.Jugador = jugador;
                persistencia.insertarDatos(barco);
            }
        }

        public void eliminarDatosTabla()
        {
            persistencia.eliminarDatos("Coordenadas");
            persistencia.eliminarDatos("Barcos");
        }

        public Datos comprobarCoordenadas(Datos datos)
        {
            return persistencia.compararCoordenadas(datos);
        }
    }
}
