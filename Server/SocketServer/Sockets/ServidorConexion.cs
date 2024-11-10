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

        private static TcpClient TcpClient1;
        private static TcpClient TcpClient2;
        public List<TcpClient> ListaTcpClients = new List<TcpClient>();

        private static NetworkStream networkStreamClient1;
        private static NetworkStream networkStreamClient2;
        private Thread threadJugadores;

        private bool inicializacion;

        public event SeRecibieronDatosEventHandler SeRecibieronDatos;

        public delegate void SeRecibieronDatosEventHandler(string pDatos);

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

                threadJugadores = new Thread(EsperarDatos);
                threadJugadores.Start();
            }

        }

        public void EsperarDatos()
        {
            try
            {
                while (true)
                {
                    if (TcpClient1 == null)
                    {
                        TcpClient1 = Escuchador.AcceptTcpClient();
                        ListaTcpClients.Add(TcpClient1);
                    }
                    else if (TcpClient2 == null)
                    {
                        TcpClient2 = Escuchador.AcceptTcpClient();
                        ListaTcpClients.Add(TcpClient2);
                        break;
                    }
                }

                while (true)
                {
                    if (TcpClient1 != null)
                    {
                        networkStreamClient1 = TcpClient1.GetStream();
                    }
                    if (TcpClient2 != null)
                    {
                        networkStreamClient2 = TcpClient2.GetStream();
                    }

                    //if (networkStream == null | TcpClient1.Connected == false | !networkStream.CanRead)
                    //{
                    //    SeConectoCliente.Invoke("AAAA algo salió mal :((((");
                    //    break;
                    //}

                    //SeConectoCliente.Invoke(TcpClient.Available.ToString());
                    foreach (TcpClient cliente in ListaTcpClients)
                    {
                        if (cliente.Available > 0 && inicializacion)
                        {
                            var mBytes = new byte[cliente.ReceiveBufferSize + 1];
                            int bytesRead;
                            if (cliente == ListaTcpClients[0])
                            {

                                bytesRead = networkStreamClient1.Read(mBytes, 0, cliente.ReceiveBufferSize);
                            }
                            else
                            {
                                bytesRead = networkStreamClient2.Read(mBytes, 0, cliente.ReceiveBufferSize);
                            }


                            SeRecibieronDatos.Invoke(bytesRead.ToString());
                            if (bytesRead <= 0)
                            {
                                SeRecibieronDatos.Invoke("no tiene bytes para leer");
                                break;
                            }

                            string mDatosRecibidos = Encoding.UTF8.GetString(mBytes, 0, bytesRead);

                            List<Datos> objetoRecibido = JsonConvert.DeserializeObject<List<Datos>>(mDatosRecibidos);

                            SeRecibieronDatos.Invoke(objetoRecibido[0].x.ToString());
                        }

                        EnviarMensaje(cliente, "");
                    }

                    inicializacion = false;
                }

                //LiberarCliente();
                //if (SeDesconectoCliente != null)
                //    SeDesconectoCliente.Invoke();

            }
            catch
            {
                if (threadJugadores != null && threadJugadores.ThreadState == ThreadState.Running)
                {
                    LiberarCliente(TcpClient1, networkStreamClient1);
                    LiberarCliente(TcpClient2, networkStreamClient2);
                    if (SeRecibieronDatos != null)
                        SeRecibieronDatos.Invoke("Error");
                    throw;
                }
            }
        }

        public void EnviarMensaje(TcpClient cliente, string mensaje)
        {
            if (cliente != null && cliente.Connected)
            {
                NetworkStream stream = cliente.GetStream();
                if (stream.CanWrite)
                {
                    byte[] datos = Encoding.ASCII.GetBytes(mensaje);
                    stream.Write(datos, 0, datos.Length);
                }
            }
        }

        private void LiberarCliente(TcpClient cliente, NetworkStream networkStream)
        {
            if (cliente != null)
            {
                SeRecibieronDatos.Invoke("Se libero el cliente");
                if (networkStream != null)
                {
                    networkStream.Close();
                    networkStream.Dispose();
                    networkStream = null;
                }

                if (cliente.Connected)
                {
                    cliente.Client.Shutdown(SocketShutdown.Both);
                    cliente.Close();
                }

                cliente = null;
            }
        }
    }
}
