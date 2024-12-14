using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatic_question_generation_testing
{
    internal class Matrix
    {
        // fields
        protected double[,] matrix;

        // size: r -> rows, c -> columns
        protected int r;
        protected int c;

        // properties
        public double[,] Items { get { return matrix; } protected set { matrix = value; } }
        public int Rows { get { return r; } protected set { r = value; } }
        public int Columns { get { return c; } protected set { c = value; } }

        // this program will only handle 2x2 or 2x1 matrices

        public override string ToString()
        {
            // return a string representation of a matrix for testing
            if (c == 1) return $"({matrix[0, 0]})\n({matrix[1, 0]})";
            else return $"({matrix[0, 0]}, {matrix[0, 1]})\n({matrix[1, 0]}, {matrix[1, 1]})";
        }
        
        /// <summary>
        /// Multiplies a 2x2 matrix with another 2x1 matrix for simultaneous equations.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>A new 2x1 matrix: result of the multiplication.</returns>
        /// <exception cref="Exception"></exception>
        public Matrix MultiplyWith(Matrix other)
        {
            // only multiply a 2x2 matrix with a 2x1 matrix, otherwise throw exception
            if (r == 2 && c == 2 && other.r == 2 && other.c == 1)
            {
                double a = matrix[0, 0] * other.matrix[0, 0] + matrix[0, 1] * other.matrix[1, 0];
                double b = matrix[1, 0] * other.matrix[0, 0] + matrix[1, 1] * other.matrix[1, 0];

                // return a new matrix as the result
                return new _2x1Matrix(new double[,] { { a }, { b } });
            }
            else
            {
                throw new Exception("Cannot multiply matrices with these dimensions.");
            }
        }
    }

    internal class _2x1Matrix : Matrix
    {
        public _2x1Matrix(double[,] items)
        {
            // if there are not 2 items, throw an exception
            if (items.Length != 2) throw new Exception("Incorrect item structure for a 2x1 matrix.");

            base.matrix = items;
            base.r = 2;
            base.c = 1;
        }

        // inverse and determinant do not exist for non-square matrices
    }

    internal class _2x2Matrix : Matrix
    {
        // | a  b |
        // | c  d |
        public _2x2Matrix(double[,] items)
        {
            // if array not in form { { a,b }, { c,d } }
            if (items.Length != 4 || items.GetLength(0) != 2) throw new Exception("Incorrect item structure for a 2x2 matrix.");
            
            base.matrix = items;
            base.r = 2;
            base.c = 2;
        }

        /// <summary>
        /// Finds the determinant of a 2x2 matrix.
        /// </summary>
        /// <returns></returns>
        public double Det()
        {
            // ac - bd
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        /// <summary>
        /// Finds the shorthand inverse of a 2x2 matrix.
        /// </summary>
        /// <returns>A new 2x2 matrix containing the inverse of the matrix.</returns>
        public _2x2Matrix Inverse()
        {
            // inverse: 1/detM * C^T
            double inverseDet = 1 / Det();

            // shorthand method
            double[,] transposedC = new double[2, 2] { { inverseDet * matrix[1, 1], inverseDet * -matrix[0, 1] }, { inverseDet * -matrix[1, 0], inverseDet * matrix[0, 0] } };

            // return a new 2x2 matrix as a result
            return new _2x2Matrix(transposedC);
        }
    }
}
