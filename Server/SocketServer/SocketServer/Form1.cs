using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sockets;
using BL;
using BE;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BLMetodos BLMetodos = new BLMetodos();
        ServidorConexion conexion = new ServidorConexion();

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbIPs.Items.AddRange(conexion.ObtenerDireccionesLocales());

            conexion.SeRecibieronDatos += SeRecibieronDatosHandler;
        }

        private void btnEscuchar_Click(object sender, EventArgs e)
        {
            int puerto;
            if (int.TryParse(txtPuerto.Text, out puerto))
            {
                conexion.PuertoEscucha = puerto;
                conexion.EscucharPuerto();
                
            }
            else
            {
                MessageBox.Show("El puerto debe conformarse por número", "Error");
            }
        }

        private void SeRecibieronDatosHandler(string pDatos)
        {
            ActualizarTextBox(pDatos);
            
        }

        delegate void ActualizarTextBoxDelegate(string pTexto);
        void ActualizarTextBox(string pTexto)
        {
            if (InvokeRequired)
            {
                this.Invoke(new ActualizarTextBoxDelegate(ActualizarTextBox), pTexto);
                return;
            }
            //MessageBox.Show(pTexto);
            txtDatos.AppendText(pTexto);
        }

        void SeConectoClienteHandler(string datos)
        {
            ActualizarTextBox(datos);
        }
    }
}
