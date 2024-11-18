using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class Datos
    {
        public int x, y;
        public bool horizontal;
        public int idBarco;
        public string estado;
        public int jugador;
        public bool[] perdiste = new bool[2];
    }
}
