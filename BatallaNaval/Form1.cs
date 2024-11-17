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
using Socket;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace BatallaNaval
{
    public partial class Form1 : Form
    {
        int x, y;
        private int indiceTerminar;
        //private bool c = true;
        //Thread hiloTerminar;
        public Form1()
        {
            InitializeComponent();
        }

        SocketCliente socket = new SocketCliente();

        private void Form1_Load(object sender, EventArgs e)
        {
            #region tablaJugador


            dgvJugador.AllowUserToAddRows = false;
            dgvJugador.AllowUserToDeleteRows = false;

            for (char c = 'A'; c <= 'J'; c++)
            {
                dgvJugador.Columns.Add(c.ToString(), c.ToString());
            }

            for (int i = 1; i <= 10; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvJugador);
                row.HeaderCell.Value = i.ToString();
                dgvJugador.Rows.Add(row);
            }

            foreach (DataGridViewColumn column in dgvJugador.Columns)
            {
                column.Width = 50;
            }

            dgvJugador.DefaultCellStyle.BackColor = Color.LightBlue;
            dgvJugador.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvJugador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvJugador.MultiSelect = false;
            #endregion

            #region tablaEnemigo

            dgvEnemigo.AllowUserToAddRows = false;
            dgvEnemigo.AllowUserToDeleteRows = false;

            for (char c = 'A'; c <= 'J'; c++)
            {
                dgvEnemigo.Columns.Add(c.ToString(), c.ToString());
            }

            for (int i = 1; i <= 10; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvJugador);
                row.HeaderCell.Value = i.ToString();
                dgvEnemigo.Rows.Add(row);
            }

            foreach (DataGridViewColumn column in dgvEnemigo.Columns)
            {
                column.Width = 50;
            }

            dgvEnemigo.DefaultCellStyle.BackColor = Color.LightBlue;
            dgvEnemigo.EditMode = DataGridViewEditMode.EditProgrammatically;


            dgvEnemigo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEnemigo.MultiSelect = false;

            #endregion

            btnTerminar.Enabled = false;

            socket.DatosRecibidos += SeRecibieronDatosHandler;
            socket.tuTurno += activarTurno;
            socket.grillaAtacada += actualizarGrilla;
            //socket.SocketDesconectado += DesconectadoHandlerHandler;

            //hiloTerminar = new Thread(confirmarBoton);
            //hiloTerminar.Start();

            btnAtacar.Enabled = false;
            tiempoTerminar.Start();
        }
        List<Datos> listaDatos = new List<Datos>();

        private void actualizarGrilla(Datos dato, int jugador)
        {
            if(dato.jugador == jugador)
            {
                if(dato.estado == "Agua")
                {
                    dgvEnemigo.Rows[dato.y].Cells[dato.x].Style.BackColor = Color.DarkBlue;
                } else if(dato.estado == "Tocado")
                {
                    dgvEnemigo.Rows[dato.y].Cells[dato.x].Style.BackColor = Color.DarkRed;
                } else if(dato.estado == "Hundido")
                {
                    dgvEnemigo.Rows[dato.y].Cells[dato.x].Style.BackColor = Color.DarkRed;
                }
            } 
            else
            {
                if (dato.estado == "Agua")
                {
                    dgvJugador.Rows[dato.y].Cells[dato.x].Style.BackColor = Color.DarkBlue;
                }
                else if (dato.estado == "Tocado")
                {
                    dgvJugador.Rows[dato.y].Cells[dato.x].Style.BackColor = Color.DarkRed;
                }
                else if (dato.estado == "Hundido")
                {
                    dgvJugador.Rows[dato.y].Cells[dato.x].Style.BackColor = Color.DarkRed;
                }
            }

            MessageBox.Show(dato.estado + "del jugador " + dato.jugador);
        }

        private void SeRecibieronDatosHandler(string pDatos)
        {
            MessageBox.Show(pDatos);
        }

        private void activarTurno()
        {
            ActualizarTextBox();

        }

        delegate void ActualizarBotonDelegate();
        void ActualizarTextBox()
        {
            if (InvokeRequired)
            {
                this.Invoke(new ActualizarBotonDelegate(ActualizarTextBox));
                return;
            }
            btnAtacar.Enabled = true;
            lblTurno.Text = "Tu turno";

        }


        private void btnAgregarLancha_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvJugador.SelectedCells.Count == 0)
                {
                    throw new CellSelectionException("Seleccione una coordenada de la grilla.");
                } 
                else
                {
                    x = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
                    y = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
                    bool horizontal = chkHorizontal.Checked;


                    if (dgvJugador.Rows[y].Cells[x].Style.BackColor != Color.Gray)
                    {
                        dgvJugador.Rows[y].Cells[x].Style.BackColor = Color.Gray;

                        btnAgregarLancha.Enabled = false;

                        Datos datos = new Datos();
                        datos.x = x;
                        datos.y = y;
                        datos.horizontal = horizontal;
                        datos.idBarco = 3;

                        listaDatos.Add(datos);
                    }
                    else
                    {
                        MessageBox.Show("No se puede colocar el barco.");
                    }
                }
                
            }
            catch (CellSelectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDestructor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvJugador.SelectedCells.Count == 0)
                {
                    throw new CellSelectionException("Seleccione una coordenada de la grilla.");
                }
                x = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
                y = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
                bool horizontal = chkHorizontal.Checked;


                if (Comprobacion(2))
                {
                    btnDestructor.Enabled = false;

                    Datos datos = new Datos();
                    datos.x = x;
                    datos.y = y;
                    datos.horizontal = horizontal;
                    datos.idBarco = 2;

                    listaDatos.Add(datos);
                }
            }
            catch (CellSelectionException ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        //private void confirmarBoton()
        //{ 
        //    while(c)
        //    {
        //        if (btnAcorazado.Enabled == false && btnDestructor.Enabled == false && btnPortaviones.Enabled == false
        //            && btnAgregarLancha.Enabled == false && txtIP.Text != "" && txtPuerto.Text != "")
        //        {
        //            btnTerminar.Enabled = true;
        //            c = false;
        //            hiloTerminar.Abort();
        //            hiloTerminar = null;
        //        }
        //    }
            
        //}

        private void btnAcorazado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvJugador.SelectedCells.Count == 0)
                {
                    throw new CellSelectionException("Seleccione una coordenada de la grilla.");
                }

                x = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
                y = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
                bool horizontal = chkHorizontal.Checked;

                if (Comprobacion(3))
                {
                    btnAcorazado.Enabled = false;

                    Datos datos = new Datos();
                    datos.x = x;
                    datos.y = y;
                    datos.horizontal = horizontal;
                    datos.idBarco = 1;

                    listaDatos.Add(datos);
                }
            }
            catch (CellSelectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnPortaviones_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvJugador.SelectedCells.Count == 0)
                {
                    throw new CellSelectionException("Seleccione una coordenada de la grilla.");
                }

                x = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
                y = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
                bool horizontal = chkHorizontal.Checked;


                if (Comprobacion(4))
                {
                    btnPortaviones.Enabled = false;

                    Datos datos = new Datos();
                    datos.x = x;
                    datos.y = y;
                    datos.horizontal = horizontal;
                    datos.idBarco = 0;

                    listaDatos.Add(datos);
                }
            }
            catch (CellSelectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvEnemigo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            y = int.Parse(dgvEnemigo.SelectedCells[0].ColumnIndex.ToString());
            x = int.Parse(dgvEnemigo.SelectedCells[0].RowIndex.ToString());
            lblCoordeanadas.Text = "Coordenadas: " + dgvEnemigo.Columns[y].Name + ", " + (x + 1).ToString();

        }

        

        bool Comprobacion(int indice)
        {
            bool valido = true;

            try
            {
                for (int i = 0; i < indice; i++)
                {
                    if (!chkHorizontal.Checked && valido)
                    {
                        if (dgvJugador.Rows[y + i].Cells[x].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                    else if (valido)
                    {
                        if (dgvJugador.Rows[y].Cells[x + i].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                }

                if (valido)
                {
                    for (int i = 0; i < indice; i++)
                    {
                        if (!chkHorizontal.Checked && valido)
                        {
                            dgvJugador.Rows[y + i].Cells[x].Style.BackColor = Color.Gray;
                        }
                        else if (valido)
                        {
                            dgvJugador.Rows[y].Cells[x + i].Style.BackColor = Color.Gray;
                        }
                    }


                    indiceTerminar++;
                }
                else
                {
                    MessageBox.Show("Los  barcos no pueden superponerse.");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Barco fuera de los límites.");
                valido = false;
            }

            if(indiceTerminar >= 4 && txtIP.Text != "" && txtPuerto.Text != "")
            {
                btnTerminar.Enabled = true;
            }
            

            return valido;
        }

        private void setIPAndPort()
        {
            socket.PuertoRemoto = txtPuerto.Text;
            socket.IPRemota = txtIP.Text;
        }

        private void tiempoTerminar_Tick(object sender, EventArgs e)
        {
            if (btnAcorazado.Enabled == false && btnDestructor.Enabled == false && btnPortaviones.Enabled == false
                    && btnAgregarLancha.Enabled == false && txtIP.Text != "" && txtPuerto.Text != "")
            {
                btnTerminar.Enabled = true;
                tiempoTerminar.Stop();
            }
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEnemigo.SelectedCells.Count == 0)
                {
                    throw new CellSelectionException("Seleccione una coordenada de la grilla.");
                }
                
                if (dgvEnemigo.Rows[y].Cells[x].Style.BackColor != Color.DarkBlue || dgvEnemigo.Rows[y].Cells[x].Style.BackColor != Color.DarkRed)
                {
                    //dgvEnemigo.Rows[y].Cells[x].Style.BackColor = Color.DarkBlue; //modificar segun si es tocado o no
                    lblTurno.Text = "Esperando turno";
                    btnAtacar.Enabled = false;

                    x = int.Parse(dgvEnemigo.SelectedCells[0].ColumnIndex.ToString());
                    y = int.Parse(dgvEnemigo.SelectedCells[0].RowIndex.ToString());
                    Datos datos = new Datos();
                    datos.x = x;
                    datos.y = y;
                    socket.EnviarMensaje(datos);
                }
                else
                {
                    MessageBox.Show("No se puede colocar el barco.");
                }
            }
            catch (CellSelectionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            setIPAndPort();
            socket.generarJSON(listaDatos);
            dgvJugador.ClearSelection();
            dgvJugador.Enabled = false;
            btnTerminar.Enabled = false;
        }
    }
}
