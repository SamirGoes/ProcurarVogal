using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurarVogal
{
    public interface IStream
    {
        char getNext();

        bool hasNext();
    }
}
