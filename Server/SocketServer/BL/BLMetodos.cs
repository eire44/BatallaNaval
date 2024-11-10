using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Sockets;
using static Sockets.ServidorConexion;

namespace BL
{
    public class BLMetodos
    {
        Persistencia persistencia = new Persistencia();
        ServidorConexion servidorConexion = new ServidorConexion();

        public delegate void retornarInfoAUI(string s);
        public event retornarInfoAUI RetornarAUI;

        public BLMetodos()
        {
            servidorConexion.SeRecibieronDatos += devolverEvento;
        }
        public void pasarAInsertar(List<Datos> datos)
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


                persistencia.insertarDatos(dato, barco);
            }
        }

        public void escucharPuerto(int puerto)
        {
            servidorConexion.PuertoEscucha = puerto;
            servidorConexion.EscucharPuerto();
        }

        public string[] obtenerDirecciones()
        {
            return servidorConexion.ObtenerDireccionesLocales();
        }

        public void devolverEvento(string s)
        {
            RetornarAUI.Invoke(s);
        }
        //public void generarCoordenadas()
        //{
        //    for (int i = 0; i < indice; i++)
        //    {
        //        if (!chkHorizontal.Checked && valido)
        //        {
        //            dgvJugador.Rows[x + i].Cells[y].Style.BackColor = Color.Gray;
        //        }
        //        else if (valido)
        //        {
        //            dgvJugador.Rows[x].Cells[y + i].Style.BackColor = Color.Gray;
        //        }
        //    }
        //}
    }
}
