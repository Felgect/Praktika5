using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika5
{
    internal class Matrix
    {

        private int n; 
        private int[,] mass;


        public Matrix() { }  
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }


        public Matrix(int n) 
        {
            this.n = n;
            mass = new int[this.n, this.n];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }


        public void WriteMatrix() 
        {
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //mass[i, j] = r.Next(2);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }


        public void ReadMatrix() 
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }



        public void oneMat(Matrix a)  
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 1 && i == j)
                    {
                        count++;
                    }
                }

            }
            if (count == a.N)
            {
                Console.WriteLine("Единичная");
            }
            else Console.WriteLine("Не единичная");
        }



        public static Matrix umnch(Matrix a, int ch)   
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] += a[i, j] * ch;
                }
            }
            return resMass;
        }


        public static Matrix umn(Matrix a, Matrix b)    
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }



        public Matrix UnitMatrix()  
        {
            Matrix unitMatrix = new Matrix(n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        unitMatrix[i, j] = 1;
                    else
                        unitMatrix[i, j] = 0;
                }
            return unitMatrix;
        }


        public string ConnectedGraph(Matrix reachabilityMatrix) 
        {
            int t = 1;

            for (int i = 0; i < reachabilityMatrix.N; i++)
                for (int j = 0; j < reachabilityMatrix.N; j++)
                    if (reachabilityMatrix[i, j] == 0)
                    {
                        t = 0;
                        break;
                    }

            if (t == 1)
                return "Граф является связным";
            else
                return "Граф не является связным";

        }


        public Matrix ReachabilityMatrix(Matrix matrix) 
        {
            Matrix reachabilityMatrix = new Matrix(n);
            reachabilityMatrix = reachabilityMatrix.UnitMatrix();

            for (int i = 1; i < n; i++)
            {
                Matrix value = new Matrix(n);
                value = matrix;

                for (int j = 0; j < i; j++)
                    value = value * matrix;

                reachabilityMatrix = reachabilityMatrix + value;
            }

            reachabilityMatrix = reachabilityMatrix.BooleanMatrix(reachabilityMatrix);
            return reachabilityMatrix;
        }


        public Matrix BooleanMatrix(Matrix matrix) 
        {
            for (int i = 0; i < matrix.n; i++)
                for (int j = 0; j < matrix.n; j++)
                {
                    if (matrix[i, j] != 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }

            return matrix;
        }


        public static Matrix operator *(Matrix a, Matrix b) 
        {
            return Matrix.umn(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.umnch(a, b);
        }



        public static Matrix razn(Matrix a, Matrix b) 
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }


        public static Matrix operator -(Matrix a, Matrix b)  
        {
            return Matrix.razn(a, b);
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }

        public static Matrix operator +(Matrix a, Matrix b) 
        {
            return Matrix.Sum(a, b);
        }

        ~Matrix()
        {
            Console.WriteLine("Очистка"); 
        }
    }
}
