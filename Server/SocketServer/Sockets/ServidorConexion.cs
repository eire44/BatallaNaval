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
using BL;

namespace Sockets
{
    public class ServidorConexion
    {
        public int PuertoEscucha;
        private TcpListener Escuchador;

        ClientesConectados clientesInterfaz = new ClientesConectados();

        private Thread threadJugadores;

        Thread threadEscuchador;

        private bool inicializacion = true;

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
                    if (clientesInterfaz.Count() == 0)
                    {

                        Cliente cliente = new Cliente();
                        cliente.clienteTCP = Escuchador.AcceptTcpClient();
                        cliente.stream = cliente.clienteTCP.GetStream();
                        cliente.numCliente = 1;
                        clientesInterfaz.AgregarCliente(cliente);
                    }
                    else if (clientesInterfaz.Count() == 1)
                    {
                        Cliente cliente = new Cliente();
                        cliente.clienteTCP = Escuchador.AcceptTcpClient();
                        cliente.stream = cliente.clienteTCP.GetStream();
                        cliente.numCliente = 2;
                        clientesInterfaz.AgregarCliente(cliente);
                        break;
                    }
                }

                while (true)
                {
                    //if (networkStream == null | TcpClient1.Connected == false | !networkStream.CanRead)
                    //{
                    //    SeConectoCliente.Invoke("AAAA algo salió mal :((((");
                    //    break;
                    //}

                    //SeConectoCliente.Invoke(TcpClient.Available.ToString());
                    foreach (Cliente cliente in clientesInterfaz)
                    {
                        if (cliente.clienteTCP.Available > 0 && inicializacion)
                        {
                            var mBytes = new byte[cliente.clienteTCP.ReceiveBufferSize + 1];
                            int bytesRead;

                            bytesRead = cliente.stream.Read(mBytes, 0, cliente.clienteTCP.ReceiveBufferSize);
                            

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

                        EnviarMensaje(cliente.clienteTCP, "");
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
                    foreach (Cliente cliente in clientesInterfaz)
                    {
                        LiberarCliente(cliente.clienteTCP, cliente.stream);
                    }
                    
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
