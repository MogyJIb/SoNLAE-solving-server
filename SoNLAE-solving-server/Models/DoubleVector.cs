using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server.Models
{

    public class DoubleVector : VectorInterface<double>
    {
        public List<double> data { get; set; }

        public int Count => data.Count;

        public bool IsReadOnly => false;

        public double this[int index] { get => data[index]; set => data[index] = value; }

        public DoubleVector(params double[] data) : this(new List<double>(data)) { }

        public DoubleVector()
        {
            this.data = new List<double>();
        }

        public DoubleVector(List<double> data)
        {
            this.data = data;
        }

        public DoubleVector(int size)
        {
            data = new List<double>();
            for (int i = 0; i < size; i++) data.Add(0.0);
        }

        public void Add(VectorInterface<double> collection)
        {
            if (data.Count != collection.Count)
                throw new ArgumentException("Wrong collection size" +
                        " (actual: " + collection.Count + ", expected: " + data.Count + ").");

            for (int i = 0; i < Count; i++) data[i] += collection[i];
        }


        public void Mul(double element)
        {
            for (int i = 0; i < Count; i++) data[i] *= element;
        }

        public VectorInterface<double> Copy()
        {
            return new DoubleVector(data.ToArray());
        }

        public List<Double> Data { get { return data; } }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is DoubleVector)) return false;

            DoubleVector dVector = (DoubleVector)obj;

            if (Data == null)
                return dVector.Data == null;
            if (Count != dVector.Count)
                return false;

            for (int i = 0; i < Count; i++)
            {
                if (Math.Abs(data[i] - dVector.Data[i]) > Constants.DELTA)
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return data != null ? data.GetHashCode() : 0;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            foreach (Double value in data)
                result.Append(value + " ");
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        public int IndexOf(double item)
        {
            return data.IndexOf(item);
        }

        public void Insert(int index, double item)
        {
            data.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            data.RemoveAt(index);
        }

        public void Add(double item)
        {
            data.Add(item);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(double item)
        {
            return data.Contains(item);
        }

        public void CopyTo(double[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public bool Remove(double item)
        {
            return data.Remove(item);
        }

        public IEnumerator<double> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}

