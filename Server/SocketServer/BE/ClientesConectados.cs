using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClientesConectados : IEnumerable<Cliente>
    {
        private List<Cliente> listaClientes = new List<Cliente>();

        public void AgregarCliente(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }

        public IEnumerator<Cliente> GetEnumerator()
        {
            return listaClientes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listaClientes.GetEnumerator();
        }
    }
}
