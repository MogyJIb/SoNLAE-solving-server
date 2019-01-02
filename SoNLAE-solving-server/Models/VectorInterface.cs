using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server.Models
{
    public interface VectorInterface<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        void Mul(T element);

        VectorInterface<T> Copy();
        void Add(VectorInterface<T> collection);
    }
}
