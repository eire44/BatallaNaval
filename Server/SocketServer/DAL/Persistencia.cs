using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Newtonsoft.Json;
using Sockets;

namespace DAL
{
    public class Persistencia
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=DatabaseTest;Integrated Security=True");
        private static int ID;

        public void insertarDatos(Datos dato)
        {
            BEBarcos barco;
            if(dato.idBarco == 0)
            {
                barco = new Portaviones(dato.horizontal, dato.x, dato.y);

            } else if(dato.idBarco == 1)
            {
                barco = new Acorazado(dato.horizontal, dato.x, dato.y);
            }
            else if (dato.idBarco == 2)
            {
                barco = new Destructor(dato.horizontal, dato.x, dato.y);
            }
            else if (dato.idBarco == 3)
            {
                barco = new Lancha(dato.horizontal, dato.x, dato.y);
            } else
            {
                barco = null;
            }

            SqlCommand insertar = new SqlCommand("INSERT INTO Barcos (Barco_Id, Barco_Tipo, Barco_Direccion, Barco_Slots, Barco_Vida, Barco_Jugador) VALUES (@pID, @pTipo, @pDireccion,@pSlots, @pVida, @pJugador)", conexion);
            insertar.Parameters.AddWithValue("@pID", generarId());
            insertar.Parameters.AddWithValue("@pTipo", barco.Nombre);
            insertar.Parameters.AddWithValue("@pDireccion", barco.Horizontal);
            insertar.Parameters.AddWithValue("@pSlots", barco.Slots);
            insertar.Parameters.AddWithValue("@pVida", barco.Vidas);
            insertar.Parameters.AddWithValue("@pJugador", barco.Jugador);

            conexion.Open();
            insertar.ExecuteNonQuery();
            conexion.Close();
        }


        public int generarId()
        {
            if (ID < 0)
            {
                SqlCommand id = new SqlCommand("SELECT ISNULL(MAX(Barco_Id), 0) FROM Barcos", conexion);
                conexion.Open();
                ID = int.Parse(id.ExecuteScalar().ToString());
                conexion.Close();
            }
            ID++;

            return ID;
        }
    }
}
