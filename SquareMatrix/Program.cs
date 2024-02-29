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
        private int _sideSize { get; set; }
        private int[,] _matrix;
        static Random st_randomInt = new Random();

        public SquareMatrix(int sideSize, int[,] matrix = null)
        {
            this._sideSize = sideSize;
            if (matrix == null)
            {
                _matrix = new int[this._sideSize, this._sideSize];
                RandomizeMatrix();
            }
            else
            {
                _matrix = matrix;
            }    
        }

        public void RandomizeMatrix()
        {
            for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                {
                    _matrix[rowIndex, columnIndex] = st_randomInt.Next(-1000, 1000);
                }
            }
        }

        public void NullifingMatrix()
        {
            for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                {
                    _matrix[rowIndex, columnIndex] = 0;
                }
            }
        }

        public override bool Equals(object other)
        {
            if (other is SquareMatrix)
            {
                var comparedMatrix = other as SquareMatrix;
                if (_sideSize != comparedMatrix._sideSize)
                {
                    return false;
                }
                for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                    {
                        if (_matrix[rowIndex, columnIndex] != comparedMatrix._matrix[rowIndex, columnIndex])
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

                for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                    {
                        thisMatrixWeight += _matrix[rowIndex, columnIndex];
                    }
                }

                for (int rowIndex = 0; rowIndex < comparedMatrix._sideSize; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < comparedMatrix._sideSize; ++columnIndex)
                    {
                        comparedMatrixWeight += comparedMatrix._matrix[rowIndex, columnIndex];
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
            if (firstMatrix._sideSize != secondMatrix._sideSize)
            {
                throw new DifferentMatrixSizesException("Матрицы не совпадают по размеру");
            }

            int sideSize;
            sideSize = firstMatrix._sideSize;
            SquareMatrix resultMatrix = new SquareMatrix(sideSize);
            resultMatrix.NullifingMatrix();

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    resultMatrix._matrix[rowIndex, columnIndex] = firstMatrix._matrix[rowIndex, columnIndex] + secondMatrix._matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator -(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix._sideSize != secondMatrix._sideSize)
            {
                throw new DifferentMatrixSizesException("Матрицы не совпадают по размеру");
            }

            int sideSize;
            sideSize = firstMatrix._sideSize;
            SquareMatrix resultMatrix = new SquareMatrix(sideSize);
            resultMatrix.NullifingMatrix();

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    resultMatrix._matrix[rowIndex, columnIndex] = firstMatrix._matrix[rowIndex, columnIndex] - secondMatrix._matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix._sideSize != secondMatrix._sideSize)
            {
                throw new DifferentMatrixSizesException("Матрицы не совпадают по размеру");
            }

            int sideSize;
            sideSize = firstMatrix._sideSize;
            SquareMatrix resultMatrix = new SquareMatrix(sideSize);
            resultMatrix.NullifingMatrix();

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    resultMatrix._matrix[rowIndex, columnIndex] = firstMatrix._matrix[rowIndex, columnIndex] * secondMatrix._matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int sideSize;
            sideSize = firstMatrix._sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix._matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix._matrix[rowIndex, columnIndex];
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
            sideSize = firstMatrix._sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix._matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix._matrix[rowIndex, columnIndex];
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
            sideSize = firstMatrix._sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix._matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix._matrix[rowIndex, columnIndex];
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
            sideSize = firstMatrix._sideSize;
            int firstMatrixWeight, secondMatrixWeight;
            firstMatrixWeight = 0;
            secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix._matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix._matrix[rowIndex, columnIndex];
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
            sideSize = firstMatrix._sideSize;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    if (firstMatrix._matrix[rowIndex, columnIndex] != secondMatrix._matrix[rowIndex, columnIndex])
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
            sideSize = firstMatrix._sideSize;

            for (int rowIndex = 0; rowIndex < sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < sideSize; ++columnIndex)
                {
                    if (firstMatrix._matrix[rowIndex, columnIndex] != secondMatrix._matrix[rowIndex, columnIndex])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator true(SquareMatrix squareMatrix)
        {
            if (squareMatrix._sideSize != 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator false(SquareMatrix squareMatrix)
        {
            if (squareMatrix._sideSize != 0)
            {
                return false;
            }
            return true;
        }

        public SquareMatrix GetSubMatrix(int columnFromMatrix, SquareMatrix mainMatrix)
        {
            SquareMatrix subMatrix = new SquareMatrix(mainMatrix._sideSize - 1);

            for (int rowIndex = 0; rowIndex < subMatrix._sideSize; ++rowIndex)
            {
                for (int columnIndex = 0 ; columnIndex < columnFromMatrix; ++columnIndex)
                {
                    subMatrix._matrix[rowIndex, columnIndex] = mainMatrix._matrix[rowIndex + 1, columnIndex + 1];
                }
            }
            return subMatrix;

        }

        public int GetDeterminant(SquareMatrix squareMatrix)
        {

            int Determinant = 0;

            if (squareMatrix.   _sideSize == 1)
            {
                Determinant = squareMatrix._matrix[0, 0];
            }
            else if (squareMatrix._sideSize == 2)
            {
                Determinant = squareMatrix._matrix[0, 0] * squareMatrix._matrix[1, 1] - squareMatrix._matrix[0, 1] * squareMatrix._matrix[1, 0];
            }
            else
            {
                for (int columnIndex = 0; columnIndex < squareMatrix._sideSize; ++columnIndex)
                {
                    int minor = Convert.ToInt32(Math.Pow(-1, columnIndex));
                    int ColumnNumber = minor * squareMatrix._matrix[0, columnIndex];
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
            for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                {
                    reversedMatrix._matrix[rowIndex, columnIndex] = _matrix[rowIndex, columnIndex] * determinant;
                }
            }
            return reversedMatrix;
        }

        public override string ToString()
        {
            StringBuilder matrixStringBuilder = new StringBuilder();
            for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                {
                    matrixStringBuilder.AppendFormat("{0, 4} ", _matrix[rowIndex, columnIndex]);
                }
                matrixStringBuilder.Append('\n');
            }
            return matrixStringBuilder.ToString();
        }
        
        public object Clone()
        {
            SquareMatrix clonedMatrix = new SquareMatrix(_sideSize);
            for (int rowIndex = 0; rowIndex < _sideSize; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < _sideSize; ++columnIndex)
                {
                    clonedMatrix._matrix[rowIndex, columnIndex] = _matrix[rowIndex, columnIndex];
                }
            }
            return clonedMatrix;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix firstExhibitionMatrix = new SquareMatrix(4);
            Console.WriteLine(firstExhibitionMatrix);
            SquareMatrix secondExhibitionMatrix = new SquareMatrix(4);
            Console.WriteLine(secondExhibitionMatrix);

            Console.WriteLine(firstExhibitionMatrix + secondExhibitionMatrix);
            Console.WriteLine(firstExhibitionMatrix > secondExhibitionMatrix);
            Console.WriteLine(firstExhibitionMatrix.Equals(secondExhibitionMatrix));
            Console.WriteLine(firstExhibitionMatrix.CompareTo(secondExhibitionMatrix));
            Console.WriteLine(firstExhibitionMatrix.GetHashCode());
            Console.WriteLine(firstExhibitionMatrix.GetDeterminant(firstExhibitionMatrix));
            Console.WriteLine(firstExhibitionMatrix.ReverseMatrix());

            SquareMatrix thirdExhibitionMatrix = new SquareMatrix(5);
            SquareMatrix fourthExhibitionMatrix = thirdExhibitionMatrix.Clone() as SquareMatrix;
            Console.WriteLine(thirdExhibitionMatrix);
            try
            {
                Console.WriteLine(firstExhibitionMatrix + thirdExhibitionMatrix);
            }
            catch (Exception Error) 
            {
                Console.WriteLine(Error.Message);
            };
            Console.WriteLine("\n");

            Console.WriteLine(thirdExhibitionMatrix.GetHashCode());
            Console.WriteLine(fourthExhibitionMatrix.GetHashCode());
            Console.WriteLine("\n");
            Console.WriteLine(thirdExhibitionMatrix);
            Console.WriteLine(fourthExhibitionMatrix);
            thirdExhibitionMatrix.RandomizeMatrix();
            Console.WriteLine(thirdExhibitionMatrix);
            Console.WriteLine(fourthExhibitionMatrix);
            Console.ReadLine();
        }
    }
}

