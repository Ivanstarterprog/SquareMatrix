using System;
using System.Text;

namespace Matrix
{
    public class DifferentMatrixSizesException : Exception
    {
        public DifferentMatrixSizesException()
        {
        }

        public DifferentMatrixSizesException(string message)
            : base(message)
        {
        }

        public DifferentMatrixSizesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    class SquareMatrix : IComparable, ICloneable
    {
        private int sideSize { get; set; }
        private int[,] matrix;
        public SquareMatrix(int sideSize)
        {
            this.sideSize = sideSize;
            matrix = new int[this.sideSize, this.sideSize];
            RandomizeMatrix();
        }
        private void RandomizeMatrix()
        {
            Random RandomInt = new Random();
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = RandomInt.Next(-1000, 1000);
                }
            }
        }
        private void NullifingMatrix()
        {
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = 0;
                }
            }
        }

        public override bool Equals(object other)
        {
            if (other is SquareMatrix)
            {
                var comparedMatrix = other as SquareMatrix;
                if (sideSize != comparedMatrix.sideSize)
                {
                    return false;
                }
                for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                    {
                        if (matrix[rowIndex, columnIndex] != comparedMatrix.matrix[rowIndex, columnIndex])
                        {
                            return false;
                        }
                    }
                }
                return true;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object other)
        {
            if (other is SquareMatrix)
            {
                SquareMatrix comparedMatrix = other as SquareMatrix;
                int thisMatrixWeight, comparedMatrixWeight;
                thisMatrixWeight = 0;
                comparedMatrixWeight = 0;
                for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                    {
                        thisMatrixWeight += matrix[rowIndex, columnIndex];
                    }
                }
                for (int rowIndex = 0; rowIndex < comparedMatrix.sideSize; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < comparedMatrix.sideSize; ++columnIndex)
                    {
                        comparedMatrixWeight += comparedMatrix.matrix[rowIndex, columnIndex];
                    }
                }
                if (thisMatrixWeight == comparedMatrixWeight)
                {
                    return 0;
                }
                else if (thisMatrixWeight < comparedMatrixWeight)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return -1;
        }

        public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.sideSize != secondMatrix.sideSize)
            {
                throw new DifferentMatrixSizesException("Матрицы не совпадают по размеру");
            }
            int sideSize;
            sideSize = firstMatrix.sideSize;
            SquareMatrix resultMatrix = new SquareMatrix(sideSize);
            resultMatrix.NullifingMatrix();

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] + secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator -(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.sideSize != secondMatrix.sideSize)
            {
                throw new DifferentMatrixSizesException("Матрицы не совпадают по размеру");
            }
            int sideSize;
            sideSize = firstMatrix.sideSize;
            SquareMatrix resultMatrix = new SquareMatrix(sideSize);
            resultMatrix.NullifingMatrix();

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] - secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.sideSize != secondMatrix.sideSize)
            {
                throw new DifferentMatrixSizesException("Матрицы не совпадают по размеру");
            }
            int sideSize;
            sideSize = firstMatrix.sideSize;
            SquareMatrix resultMatrix = new SquareMatrix(sideSize);
            resultMatrix.NullifingMatrix();

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] * secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix.sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            if (firstMatrixWeight < secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix.sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            if (firstMatrixWeight < secondMatrixWeight)
            {
                return false;
            }
            return true;
        }
        public static bool operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix.sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            if (firstMatrixWeight > secondMatrixWeight)
            {
                return false;
            }
            return true;
        }

        public static bool operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix.sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            if (firstMatrixWeight > secondMatrixWeight)
            {
                return true;
            }
            return false;
        }
        
        public static bool operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix.sideSize;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    if (firstMatrix.matrix[rowIndex, columnIndex] != secondMatrix.matrix[rowIndex, columnIndex])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix.sideSize;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    if (firstMatrix.matrix[rowIndex, columnIndex] != secondMatrix.matrix[rowIndex, columnIndex])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator true(SquareMatrix squareMatrix)
        {
            if (squareMatrix.sideSize != 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator false(SquareMatrix squareMatrix)
        {
            if (squareMatrix.sideSize != 0)
            {
                return false;
            }
            return true;
        }

        public SquareMatrix GetSubMatrix(int columnFromMatrix, SquareMatrix mainMatrix)
        {
            SquareMatrix subMatrix = new SquareMatrix(mainMatrix.sideSize - 1);
            for (int rowIndex = 0; rowIndex < subMatrix.sideSize; ++rowIndex)
            {
                for (int columnIndex = 0 ; columnIndex < columnFromMatrix; ++columnIndex)
                {
                    subMatrix.matrix[rowIndex, columnIndex] = mainMatrix.matrix[rowIndex + 1, columnIndex + 1];
                }
            }
            return subMatrix;

        }

        public int GetDeterminant(SquareMatrix squareMatrix)
        {

            int Determinant = 0;

            if (squareMatrix.sideSize == 1)
            {
                Determinant = squareMatrix.matrix[0, 0];
            }
            else if (squareMatrix.sideSize == 2)
            {
                Determinant = squareMatrix.matrix[0, 0] * squareMatrix.matrix[1, 1] - squareMatrix.matrix[0, 1] * squareMatrix.matrix[1, 0];
            }
            else
            {
                for (int columnIndex = 0; columnIndex < squareMatrix.sideSize; ++columnIndex)
                {
                    int minor = Convert.ToInt32(Math.Pow(-1, columnIndex));
                    int ColumnNumber = minor * squareMatrix.matrix[0, columnIndex];
                    SquareMatrix SubMatrix = GetSubMatrix(columnIndex, squareMatrix);

                    Determinant += ColumnNumber * GetDeterminant(SubMatrix);
                }
            }

            return Determinant;
        }

        public SquareMatrix ReverseMatrix()
        {
            int determinant = GetDeterminant(this);
            SquareMatrix reversedMatrix = this.Clone() as SquareMatrix;
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    reversedMatrix.matrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex] * determinant;
                }
            }
            return reversedMatrix;
        }

        public override string ToString()
        {
            StringBuilder matrixStringBuilder = new StringBuilder();
            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    matrixStringBuilder.AppendFormat("{0, 4} ", matrix[rowIndex, columnIndex]);
                }
                matrixStringBuilder.Append('\n');
            }
            return matrixStringBuilder.ToString();
        }
        
        public object Clone()
        {
            SquareMatrix clonedMatrix = new SquareMatrix(sideSize);
            clonedMatrix.matrix = matrix;
            return clonedMatrix;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix test = new SquareMatrix(4);
            Console.WriteLine(test);
            SquareMatrix test2 = new SquareMatrix(4);
            Console.WriteLine(test2);

            Console.WriteLine(test + test2);
            Console.WriteLine(test > test2);
            Console.WriteLine(test.Equals(test2));
            Console.WriteLine(test.CompareTo(test2));
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test.GetDeterminant(test));
            Console.WriteLine(test.ReverseMatrix());
            SquareMatrix test3 = new SquareMatrix(5);
            Console.WriteLine(test3);
            try
            {
                Console.WriteLine(test + test3);
            }
            catch (Exception Error) 
            {
                Console.WriteLine(Error.Message);
            }
            Console.ReadLine();
        }
    }
}

