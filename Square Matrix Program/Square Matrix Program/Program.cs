using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_Matrix_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, i, j, max;
            Console.Write("\nInput : ");
            n = Convert.ToInt32(Console.ReadLine()); //Input the Number
            int[,] matrix = new int[n, n];
            Random random = new Random();

            #region Dimension of the Square Matrix
            if (n % 2 != 0)
                max = (n / 2) + 1;
            else
                max = (n / 2);
            do
            {
                m = random.Next(2, 2000);
            } while (m > max);
            #endregion

            #region Create the Square Matrix 0-1
            int y = new int();
            y = m;
            for (i = 0; i < n; i++)
            {
                if (i != y)
                {
                    int x = new int();
                    x = m;
                    for (j = 0; j < n; j++)
                    {
                        if (j == x)
                        {
                            matrix[i, j] = Convert.ToInt32(1);
                            x = (x + m) + 1;
                        }
                        else
                        {
                            matrix[i, j] = Convert.ToInt32(0);
                        }
                    }
                }
                else
                {
                    for (j = 0; j < n; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(1);
                    }
                    y = (y + m) + 1;
                }
            }

            for (i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
            }
            #endregion

            Console.Write("\n");
            Console.Write("\nOutput : ");

            #region Count of Plus in Square Matrix

            #region Variable
            int a, b = 0;
            int dim = 3;
            int count = (n - 2);
            int plus = 0;
            #endregion

            for (int z = 0; 1 <= count; z++)
            {
                int dimA = dim;
                int dimC = 0;
                for (a = 0; a < count; a++)
                {
                    int dimB = dim;
                    int dimD = 0;
                    if (dimA == dim)
                        dimC = ((dimA - 1) / 2);
                    for (b = 0; b < count; b++)
                    {
                        int countRow = 0;
                        int countCol = 0;
                        bool isRow = false;
                        bool isCol = false;
                        if (dimB == dim)
                            dimD = ((dimB - 1) / 2);
                        for (int c = 0; c < ((dim - 1) / 2); c++)
                        {
                            for (int d = 0; d < ((dim - 1) / 2); d++)
                            {
                                if ((matrix[a, b] == matrix[a, dimB - 1]) && (matrix[a, b] != matrix[a, dimD]) &&
                                    (matrix[dimA - 1, b] == matrix[dimA - 1, dimB - 1]) && (matrix[dimA - 1, b] != matrix[dimA - 1, dimD]))
                                {
                                    countRow++;
                                    if (countRow == ((dim - 1) / 2))
                                        isRow = true;
                                }
                                if ((matrix[a, b] == matrix[dimA - 1, b]) && (matrix[a, b] != matrix[dimC, b]) &&
                                    (matrix[a, dimB - 1] == matrix[dimA - 1, dimB - 1]) && (matrix[a, dimB - 1] != matrix[dimC, dimB - 1]))
                                {
                                    countCol++;
                                    if (countCol == ((dim - 1) / 2))
                                        isCol = true;
                                }
                            }
                        }
                        dimB++;
                        dimD++;

                        if (isRow && isCol)
                            plus++;
                    }
                    dimA++;
                    dimC++;
                }
                count = (count - 2);
                dim = (dim + 2);
            }

            #endregion

            Console.Write(plus);
            Console.ReadLine();
        }
    }
}