using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLMetodos
    {
        //SocketCliente sc = new SocketCliente();

        public void crearSocket(string ip, int puerto)
        {

        }

        public void asociarEventos()
        {
            sc.DatosRecibidos += pasarDatos;
            //sc.SocketDesconectado += DesconectadoHandlerHandler;
        }

        public int[] pasarDatos(int n) //convertir el int en int[]
        {
            return null;
        }
    }
}
