using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix<Type>
    {
        Type[,] matrix;

        public Matrix(int dim)
        {
            if (dim < 0)
                throw new ArgumentException("dim is negative");
            matrix = new Type[dim, dim];
        }

        public Matrix(int height, int width)
        {
            if (height < 0 || width < 0)
                throw new ArgumentException("dim is negative");
            matrix = new Type[height, width];
        }

        public Matrix(int height, int width, Type init)
        {
            if (height < 0 || width < 0)
                throw new ArgumentException("dim is negative");
            matrix = new Type[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    matrix[i, j] = init;
                }
            }
        }

        public static Matrix<Type> operator -(Matrix<Type> a, Matrix<Type> b)
        {
            if (a.matrix.GetLength(1) != b.matrix.GetLength(1)
                || a.matrix.GetLength(0) != b.matrix.GetLength(0))
                throw new ArgumentException("Dimension of a and b icompatible for substraction");
            int height = a.matrix.GetLength(0);
            int width = a.matrix.GetLength(1);
            Matrix<Type> c = new Matrix<Type>(height, width);
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    c.matrix[i, j] = (dynamic)a.matrix[i, j] - (dynamic)b.matrix[i, j];
                }
            }
            return c;
        }

        public static Matrix<Type> operator +(Matrix<Type> a, Matrix<Type> b)
        {
            if (a.matrix.GetLength(1) != b.matrix.GetLength(1)
                || a.matrix.GetLength(0) != b.matrix.GetLength(0))
                throw new ArgumentException("Dimension of a and b icompatible for addition");
            int height = a.matrix.GetLength(0);
            int width = a.matrix.GetLength(1);
            Matrix<Type> c = new Matrix<Type>(height, width);
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    c.matrix[i, j] = (dynamic)a.matrix[i, j] + (dynamic)b.matrix[i, j];
                }
            }
            return c;
        }

        public static Matrix<Type> operator *(Matrix<Type> a, Matrix<Type> b)
        {
            if (a.matrix.GetLength(1) != b.matrix.GetLength(0))
                throw new ArgumentException("Dimension of a and b icompatible for multiplication");
            int height = a.matrix.GetLength(0);
            int width = b.matrix.GetLength(1);
            Matrix<Type> c = new Matrix<Type>(height, width);
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    for (int k = 0; k < a.matrix.GetLength(1); ++k)
                    {
                        c.matrix[i, j] += (dynamic)a.matrix[i, k] * (dynamic)b.matrix[k, j];
                    }
                }
            }
            return c;
        }

        public override String ToString()
        {
            string display = "";
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                display += "| ";
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    display += matrix[i, j].ToString() + " ";
                }
                display += "|\n";
            }
            return display;
        }

        public Type this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }
    }
}
