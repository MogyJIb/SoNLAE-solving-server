using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server.Models
{
    public interface MatrixInterface<T>
    {
        MatrixInterface<T> Transpose();

        VectorInterface<T> Row(int i);

        VectorInterface<T> Column(int i);

        void UpendColumn(VectorInterface<T> column);
        int RowCount { get; }
        int ColumnCount { get; }
        T[][] toArray();

        VectorInterface<T>[] Vectors { get; }

        MatrixInterface<T> Copy();
    }
}
