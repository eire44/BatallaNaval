using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            //dgvJugador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            #endregion


        }
    }
}
