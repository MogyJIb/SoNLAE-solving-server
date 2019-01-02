using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server.Models
{
    public class DoubleMatrix : MatrixInterface<Double>
    {
        private VectorInterface<Double>[] data;

        public int RowCount { get => data.Length; }
        public int ColumnCount { get => data.Length == 0 ? 0 : data[0].Count; }
        public VectorInterface<double>[] Vectors { get => data; }

        public double this[int i, int j] { get => data[i][j]; set => data[i][j] = value; }

        public DoubleMatrix(int rowCount, int columnCount)
        {
            this.data = new VectorInterface<double>[rowCount];

            for (int i = 0; i < data.Length; i++)
                this.data[i] = new DoubleVector(columnCount);
        }

        public DoubleMatrix(double[][] data)
        {
            this.data = new VectorInterface<double>[data.Length];

            for (int i = 0; i < data.Length; i++)
                this.data[i] = new DoubleVector(data[i]);
        }

        public DoubleMatrix(params VectorInterface<double>[] data)
        {
            this.data = data;
        }

        public MatrixInterface<double> Transpose()
        {
            VectorInterface<double>[] data = new VectorInterface<double>[ColumnCount];
            for (int i = 0; i < ColumnCount; i++)
            {
                double[] line = new double[RowCount];
                for (int j = 0; j < RowCount; j++)
                    line[j] = this.data[j][i];
                data[i] = new DoubleVector(line);
            }
            return new DoubleMatrix(data);
        }

        public VectorInterface<double> Row(int i)
        {
            return data[i];
        }

        public VectorInterface<double> Column(int i)
        {
            double[] column = new double[RowCount];
            for (int j = 0; j < column.Length; j++)
                column[j] = this[j, i];
            return new DoubleVector(column);
        }

        public void UpendColumn(VectorInterface<double> column)
        {
            for (int i = 0; i < RowCount; i++)
            {
                data[i].Add(column[i]);
            }
        }

        public double[][] ToArray()
        {
            double[][] array = new double[data.Length][];
            for (int i = 0; i < data.Length; i++)
                array[i] = data[i].ToArray();
            return array;
        }

        public MatrixInterface<double> Copy()
        {
            VectorInterface<double>[] data = new VectorInterface<double>[RowCount];
            for (int i = 0; i < RowCount; i++)
                data[i] = this.data[i].Copy();
            return new DoubleMatrix(data);
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is DoubleMatrix)) return false;

            DoubleMatrix doubleMatrix = (DoubleMatrix)obj;

            for (int i = 0; i < Vectors.Length; i++)
                if (!Vectors[i].Equals(doubleMatrix.Vectors[i])) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return Vectors.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            foreach (VectorInterface<double> vector in data)
                result.Append(vector + "\n");
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        double[][] MatrixInterface<double>.toArray()
        {
            throw new NotImplementedException();
        }
    }
}
