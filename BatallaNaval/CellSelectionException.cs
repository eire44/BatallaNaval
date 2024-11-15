using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaNaval
{
    public class CellSelectionException : Exception
    {
        public CellSelectionException() 
        {
        
        }

        public CellSelectionException(string message)
            : base(message) 
        { 

        }

        public CellSelectionException(string message, Exception inner)
            : base(message, inner) 
        { 
            
        }

    }
}
