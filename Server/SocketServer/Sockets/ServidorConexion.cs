using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.IO;
using BE;

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
                            int bytesRead = networkStream.Read(mBytes, 0, TcpClient.ReceiveBufferSize);
                            if (bytesRead <= 0)
                            {
                                break;
                            }

                            // Convertir los datos a string
                            string mDatosRecibidos = Encoding.UTF8.GetString(mBytes, 0, bytesRead);

                            // Deserializar los datos JSON recibidos
                            Datos objetoRecibido = JsonConvert.DeserializeObject<Datos>(mDatosRecibidos);

                            // Procesar o mostrar los datos recibidos
                            //MessageBox.Show($"Datos recibidos: {mDatosRecibidos}");

                            if (SeRecibieronDatos != null)
                            {
                                SeRecibieronDatos.Invoke("objetoRecibido.estado");
                            }

                            //string mDatosRecibidos = Encoding.ASCII.GetString(mBytes);

                            //if (SeRecibieronDatos != null)
                            //    SeRecibieronDatos.Invoke(mDatosRecibidos);
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
