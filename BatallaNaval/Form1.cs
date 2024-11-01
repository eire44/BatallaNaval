﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BL;

namespace BatallaNaval
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

        }


        private void btnAgregarLancha_Click(object sender, EventArgs e)
        {
            int y = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
            int x = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
            bool horizontal = chkHorizontal.Checked;


            if (dgvJugador.Rows[x].Cells[y].Style.BackColor != Color.Gray)
            {
                dgvJugador.Rows[x].Cells[y].Style.BackColor = Color.Gray;
            }
            else
            {
                MessageBox.Show("No se puede colocar el barco.");
            }

            Lancha lancha = new Lancha(horizontal, x, y);

            btnAgregarLancha.Enabled = false;
        }

        private void btnDestructor_Click(object sender, EventArgs e)
        {
            int y = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
            int x = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
            bool horizontal = chkHorizontal.Checked;

            Destructor destructor = new Destructor(horizontal, x, y);


            bool valido = true;

            try
            {
                for (int i = 0; i < destructor.Slots; i++)
                {
                    if (!destructor.Horizontal && valido)
                    {
                        if (dgvJugador.Rows[x + i].Cells[y].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                    else if (valido)
                    {
                        if (dgvJugador.Rows[x].Cells[y + i].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                }

                if (valido)
                {
                    for (int i = 0; i < destructor.Slots; i++)
                    {
                        if (!destructor.Horizontal && valido)
                        {
                            dgvJugador.Rows[x + i].Cells[y].Style.BackColor = Color.Gray;
                        }
                        else if (valido)
                        {
                            dgvJugador.Rows[x].Cells[y + i].Style.BackColor = Color.Gray;
                        }
                    }

                    btnDestructor.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Los  barcos no pueden superponerse.");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Barco fuera de los límites.");
            }

        }

        private void btnAcorazado_Click(object sender, EventArgs e)
        {
            int y = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
            int x = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
            bool horizontal = chkHorizontal.Checked;


            Acorazado acorazado = new Acorazado(horizontal, x, y);

            bool valido = true;
            try
            {
                for (int i = 0; i < acorazado.Slots; i++)
                {
                    if (!acorazado.Horizontal && valido)
                    {
                        if (dgvJugador.Rows[x + i].Cells[y].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                    else if (valido)
                    {
                        if (dgvJugador.Rows[x].Cells[y + i].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                }

                if (valido)
                {
                    for (int i = 0; i < acorazado.Slots; i++)
                    {
                        if (!acorazado.Horizontal && valido)
                        {
                            dgvJugador.Rows[x + i].Cells[y].Style.BackColor = Color.Gray;
                        }
                        else if (valido)
                        {
                            dgvJugador.Rows[x].Cells[y + i].Style.BackColor = Color.Gray;
                        }
                    }

                    btnAcorazado.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Los  barcos no pueden superponerse.");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Barco fuera de los límites.");
            }
            
        }

        private void btnPortaviones_Click(object sender, EventArgs e)
        {
            int y = int.Parse(dgvJugador.SelectedCells[0].ColumnIndex.ToString());
            int x = int.Parse(dgvJugador.SelectedCells[0].RowIndex.ToString());
            bool horizontal = chkHorizontal.Checked;


            Portaviones portaviones = new Portaviones(horizontal, x, y);

            bool valido = true;

            try
            {
                for (int i = 0; i < portaviones.Slots; i++)
                {
                    if (!portaviones.Horizontal && valido)
                    {
                        if (dgvJugador.Rows[x + i].Cells[y].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                    else if (valido)
                    {
                        if (dgvJugador.Rows[x].Cells[y + i].Style.BackColor == Color.Gray)
                        {
                            valido = false;
                        }
                    }
                }

                if (valido)
                {
                    for (int i = 0; i < portaviones.Slots; i++)
                    {
                        if (!portaviones.Horizontal && valido)
                        {
                            dgvJugador.Rows[x + i].Cells[y].Style.BackColor = Color.Gray;
                        }
                        else if (valido)
                        {
                            dgvJugador.Rows[x].Cells[y + i].Style.BackColor = Color.Gray;
                        }
                    }

                    btnPortaviones.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Los  barcos no pueden superponerse.");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Barco fuera de los límites.");
            }

            
        }

        private void dgvEnemigo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int y = int.Parse(dgvEnemigo.SelectedCells[0].ColumnIndex.ToString());
            int x = int.Parse(dgvEnemigo.SelectedCells[0].RowIndex.ToString());
            lblCoordeanadas.Text = "Coordenadas: " + dgvEnemigo.Columns[y].Name + ", " + (x + 1).ToString();

        }

        BLMetodos bl = new BLMetodos();

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text;
            int puerto = int.Parse(txtPuerto.Text);

            bl.crearSocket(ip, puerto);
        }
    }
}
