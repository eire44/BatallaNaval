using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.IO;

namespace Socket
{
    public class SocketCliente
    {
        public string IPRemota;
        public string PuertoRemoto;
        private static TcpClient TcpClient;
        private static NetworkStream NetworkStream;
        private Thread thread;

        public event SeRecibieronDatosEventHandler DatosRecibidos;

        public delegate int[] SeRecibieronDatosEventHandler(int datos);

        public event DesconectadoEventHandler SocketDesconectado;

        public delegate void DesconectadoEventHandler();

        public bool Conectar()
        {
            TcpClient = new TcpClient();
            TcpClient.Connect(IPRemota, int.Parse(PuertoRemoto));
            NetworkStream = TcpClient.GetStream();
            IPRemota = TcpClient.Client.RemoteEndPoint.ToString();

            thread = new Thread(EsperarDatos);
            thread.Start();
            
            return TcpClient.Connected;
        }

        public void EsperarDatos()
        {
            try
            {
                if (TcpClient != null && TcpClient.Connected)
                {
                    while(true)
                    {
                        NetworkStream = TcpClient.GetStream(); //porque obtiene otra vez el stream?
                        if (NetworkStream == null | TcpClient.Connected == false | !NetworkStream.CanRead)
                        {
                            break;
                        }

                        if(TcpClient.Connected && NetworkStream.CanWrite)
                        {
                            //var objeto = new
                            //{
                            //    Nombre = "Batalla Naval",
                            //    Jugadores = 2,
                            //    Estado = "En curso"
                            //};
                            //string json = JsonConvert.SerializeObject(objeto);
                            string json = File.ReadAllText("Barco.json", Encoding.UTF8);
                            if (TcpClient.Connected && NetworkStream.CanWrite)
                            {
                                byte[] datosAEnviar = Encoding.UTF8.GetBytes(json);
                                NetworkStream.Write(datosAEnviar, 0, datosAEnviar.Length);

                                ayuda(json, datosAEnviar.Length);
                            }

                        }

                        if (TcpClient.Available > 0)
                        {
                            var mBytes = new byte[TcpClient.ReceiveBufferSize + 1];
                            if (NetworkStream.Read(mBytes, 0, TcpClient.ReceiveBufferSize) <= 0)
                            {
                                break;
                            }

                            string mDatosRecibidos = Encoding.ASCII.GetString(mBytes);
                            if (DatosRecibidos != null)
                                DatosRecibidos.Invoke(int.Parse(mDatosRecibidos));
                        }




                    }
                    if (SocketDesconectado != null)
                        SocketDesconectado.Invoke();
                    LiberarTodo();


                }
            }
            catch (Exception)
            {
                if (thread != null && thread.ThreadState == System.Threading.ThreadState.Running)
                {
                    if (SocketDesconectado != null)
                        SocketDesconectado.Invoke();
                    LiberarTodo();
                }
            }
        }

        public string datosJ;
        public int tamano;

        public void ayuda(string datosJSON, int tamanoDatos)
        {
            datosJ = datosJSON;
            tamano = tamanoDatos;
        }

        public void datos (string json)
        {

            byte[] datosAEnviar = Encoding.UTF8.GetBytes(json);
            NetworkStream.Write(datosAEnviar, 0, datosAEnviar.Length);
        }

        public void LiberarTodo()
        {
            if (NetworkStream != null)
            {
                NetworkStream.Close();
                NetworkStream.Dispose();
                NetworkStream = null;
            }

            if (TcpClient != null)
            {
                if (TcpClient.Connected)
                {
                    TcpClient.Client.Shutdown(SocketShutdown.Both);
                    TcpClient.Client.Close();
                }

                TcpClient = null;
            }

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }
    }
}
