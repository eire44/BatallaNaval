using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Newtonsoft.Json;

namespace DAL
{
    public class Persistencia
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=DatabaseTest;Integrated Security=True");
        private int ID;

        public void insertarDatos(BEBarcos barco)
        {

            SqlCommand insertar = new SqlCommand("INSERT INTO Barcos (Barco_Id, Barco_Tipo, Barco_Vida, Barco_Jugador) VALUES (@pID, @pTipo, @pVida, @pJugador)", conexion);
            insertar.Parameters.AddWithValue("@pID", generarId("Barco_Id", "Barcos"));
            insertar.Parameters.AddWithValue("@pTipo", barco.Nombre);
            insertar.Parameters.AddWithValue("@pVida", barco.Vidas);
            insertar.Parameters.AddWithValue("@pJugador", barco.Jugador);

            conexion.Open();
            insertar.ExecuteNonQuery();
            conexion.Close();

            insertarCoordenadas(barco);
        }


        public int generarId(string idTipo, string tabla)
        {
                SqlCommand id = new SqlCommand("SELECT ISNULL(MAX(" + idTipo + "), 0) FROM " + tabla, conexion);
                conexion.Open();
                ID = int.Parse(id.ExecuteScalar().ToString());
                conexion.Close();
            ID++;
            return ID;
        }

        public void eliminarDatos(string tabla)
        {
            SqlCommand eliminar = new SqlCommand("DELETE FROM " + tabla, conexion);

            conexion.Open();
            eliminar.ExecuteNonQuery();
            conexion.Close();
        }

        public void insertarCoordenadas(BEBarcos barco)
        {
            for (int i = 0; i < barco.Vidas; i++)
            {
                SqlCommand insertar = new SqlCommand("INSERT INTO Coordenadas (Coor_Id, Barco_Id, Coor_X, Coor_Y, Coor_Jugador) VALUES (@pCoorID, @pBarcoId, @pCoorX, @pCoorY, @pCoorJug)", conexion);
                insertar.Parameters.AddWithValue("@pCoorID", generarId("Coor_Id", "Coordenadas"));
                insertar.Parameters.AddWithValue("@pBarcoId", generarId("Barco_Id", "Barcos") - 1);

                insertar.Parameters.AddWithValue("@pCoorX", barco.devolverX(i));
                insertar.Parameters.AddWithValue("@pCoorY", barco.devolverY(i));

                insertar.Parameters.AddWithValue("@pCoorJug", barco.Jugador);
                conexion.Open();
                insertar.ExecuteNonQuery();
                conexion.Close();

            }
        }

        public Datos compararCoordenadas(Datos dato)
        {
            int coorId = 0;
            int barcoId = 0;
            int barcoVida = 0;
            SqlCommand contains = new SqlCommand("SELECT Coor_Id, Barco_Id FROM Coordenadas WHERE Coor_X = " + dato.x + "AND Coor_Y = " + dato.y + " AND Coor_Jugador = " + dato.jugador, conexion);
            conexion.Open();
            SqlDataReader readerCoor = contains.ExecuteReader();
            
            while (readerCoor.Read())
            {
                coorId = readerCoor.GetInt32(0);
                barcoId = readerCoor.GetInt32(1);
            }
            readerCoor.Close();
            if (coorId !=  0)
            {
                SqlCommand borrarCoor = new SqlCommand("DELETE FROM Coordenadas WHERE Coor_Id = " + coorId, conexion);
                borrarCoor.ExecuteNonQuery();
            }
            if(barcoId != 0)
            {
                SqlCommand confirmarVida = new SqlCommand("SELECT Barco_Vida FROM Barcos WHERE Barco_Id = " + barcoId, conexion);
                SqlDataReader readerBarco = confirmarVida.ExecuteReader();

                while (readerBarco.Read())
                {
                    barcoVida = readerBarco.GetInt32(0);
                }
                readerBarco.Close();
                barcoVida -= 1;
                if(barcoVida <= 0)
                {
                    dato.estado = "Hundido";
                    SqlCommand borrarBarco = new SqlCommand("DELETE FROM Barcos WHERE Barco_Id = " + barcoId, conexion);
                    borrarBarco.ExecuteNonQuery();
                } else
                {
                    dato.estado = "Tocado";
                    SqlCommand borrarBarco = new SqlCommand("UPDATE Barcos SET Barco_Vida = " + barcoVida + " WHERE Barco_Id = " + barcoId, conexion);
                    borrarBarco.ExecuteNonQuery();
                }

            }

            if(coorId == 0 && barcoId == 0)
            {
                dato.estado = "Agua";
            }
            conexion.Close();

            return dato;
        }
    }
}
