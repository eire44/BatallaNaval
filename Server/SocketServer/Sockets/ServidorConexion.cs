using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace Sockets
{
    public class ServidorConexion
    {

        public int PuertoEscucha;
        private TcpListener Escuchador;
        private static TcpClient TcpClient;
        private static NetworkStream networkStream;
        private System.Threading.Thread thread;

        public delegate void SeConectoClienteEventHandler(string pIP);

        public event SeConectoClienteEventHandler SeConectoCliente;

        public event SeRecibieronDatosEventHandler SeRecibieronDatos;

        public delegate void SeRecibieronDatosEventHandler(string pDatos);

        public event SeDesconectoClienteEventHandler SeDesconectoCliente;

        public delegate void SeDesconectoClienteEventHandler();

        public string[] ObtenerDireccionesLocales()
        {
            var mDireccionesIP = Dns.GetHostAddresses(Dns.GetHostName());
            string[] mDireccionesStr;
            mDireccionesStr = new string[mDireccionesIP.Length];
            for (int x = 0, loopTo = mDireccionesIP.Length - 1; x <= loopTo; x++)
                mDireccionesStr[x] = mDireccionesIP[x].ToString();
            return mDireccionesStr;
        }

        public void EscucharPuerto()
        {
            if (PuertoEscucha != 0)
            {
                try
                {

                    Escuchador = new TcpListener(PuertoEscucha);
                    Escuchador.Start();
                    
                }
                catch
                {
                    throw;
                }

                thread = new Thread(EsperarDatos);
                thread.Start();
            }
        }

        public void EsperarDatos()
        {
            try
            {
                while (true)
                {
                    TcpClient = Escuchador.AcceptTcpClient();
                    if (SeConectoCliente != null)
                        SeConectoCliente.Invoke(TcpClient.Client.RemoteEndPoint.ToString());
                    while (true)
                    {

                        networkStream = TcpClient.GetStream();
                        if (networkStream == null | TcpClient.Connected == false | !networkStream.CanRead)
                        {
                            break;
                        }
                        if (TcpClient.Available > 0)
                        {
                            var mBytes = new byte[TcpClient.ReceiveBufferSize + 1];
                            if (networkStream.Read(mBytes, 0, TcpClient.ReceiveBufferSize) <= 0)
                            {
                                break;
                            }

                            string mDatosRecibidos = Encoding.ASCII.GetString(mBytes);

                            if (SeRecibieronDatos != null)
                                SeRecibieronDatos.Invoke(mDatosRecibidos);
                        }
                    }

                    LiberarCliente();
                    if (SeDesconectoCliente != null)
                        SeDesconectoCliente.Invoke();
                }
            }
            catch
            {
                if (thread != null && thread.ThreadState == ThreadState.Running)
                {
                    LiberarCliente();
                    if (SeDesconectoCliente != null)
                        SeDesconectoCliente.Invoke();
                    throw;
                }
            }
        }

        private void LiberarCliente()
        {
            if (TcpClient != null)
            {
                if (networkStream != null)
                {
                    networkStream.Close();
                    networkStream.Dispose();
                    networkStream = null;
                }

                if (TcpClient.Connected)
                {
                    TcpClient.Client.Shutdown(SocketShutdown.Both);
                    TcpClient.Close();
                }

                TcpClient = null;
            }
        }
    }
}
