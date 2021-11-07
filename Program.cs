﻿using System;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[][] matrix = new int[][]{
                new int[] {1,2,3,3},
                new int[] {0,3,6,2},
                new int[] {9,8,9,6},
                new int[] {4,3,1,5},
            };
            Matrices test = new Matrices();
            Console.WriteLine(test.Determinant(matrix));
        }
    }

    class Matrices
    {
        public void multiply(int[,] firstMat, int[,] secondMat)
        {
            int firstMatRows = firstMat.GetLength(0);
            int firstMatCols = firstMat.GetLength(1);
            int secondMatRows = secondMat.GetLength(0);
            int secondMatCols = secondMat.GetLength(1);

            if (firstMatCols != secondMatRows)
            {
                Console.WriteLine("The 2 matrices cannot be multiplied");
                return;
            }

            int[,] product = new int[firstMatRows, secondMatCols];

            for (int i = 0; i < firstMatRows; i++)
            {
                for (int j = 0; j < secondMatCols; j++)
                {
                    for (int k = 0; k < firstMatCols; k++)
                    {
                        product[i, j] += firstMat[i, k] * secondMat[k, j];
                    }
                    Console.Write(" " + product[i, j]);
                }
                Console.WriteLine();
            }
        }

        public int Determinant(int[][] mat)
        {
            int rowNum = mat.Length;
            int colNum = mat[0].Length;

            if (rowNum != colNum)
            {
                throw new ArgumentException("Gerrout");
            }

            if (rowNum == 1 && colNum == 1)
            {
                return mat[0][0];
            }

            if (rowNum == 2 && colNum == 2)
            {
                int det;
                det = (mat[0][0] * mat[1][1]) - (mat[0][1] * mat[1][0]);
                return det;
            }

            if (rowNum == 3 && colNum == 3)
            {
                int det;
                det = mat[0][0] * Determinant(GetMinor(0, 0, mat)) -
                mat[0][1] * Determinant(GetMinor(0, 1, mat)) +
                mat[0][2] * Determinant(GetMinor(0, 2, mat));
                return det;
            }

            int result = 0;
            for (int col = 0; col < colNum; ++col)
            {
                if (col % 2 == 0)
                {
                    result += mat[0][col] * Determinant(GetMinor(0, col, mat));
                }
                else
                {
                    result += mat[0][col] * Determinant(GetMinor(0, col, mat));

                }
            }
            return result;
        }

        public int[][] GetMinor(int row, int col, int[][] mat)
        {
            int rowNum = mat.Length;
            int colNum = mat[0].Length;
            int[][] minor = new int[rowNum-1][];
            int rowIndex = 0;

            for (int i = 0; i < rowNum; ++i)
            {
                if (i == row)
                {
                    continue;
                }
                minor[rowIndex] = new int[colNum - 1];
                int colIndex = 0;
                for (int j = 0; j < colNum; ++j)
                {
                    if (j == col)
                    {
                        continue;
                    }
                    minor[rowIndex][colIndex++] = mat[i][j];
                }

                ++rowIndex;
            }
            return minor;
        }
    }
}
