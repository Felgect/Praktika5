using Praktika5;
using System;

    Console.WriteLine("Введите размер матрицы: ");
        int n = Convert.ToInt32(Console.ReadLine());

    Matrix matrix = new Matrix(n);
    Console.WriteLine("Введите матрицу смежности: ");
        matrix.WriteMatrix();

    Console.WriteLine("Матрица смежности: ");
        matrix.ReadMatrix();

    Matrix reachibilityMatrix = new Matrix(n);
        reachibilityMatrix = reachibilityMatrix.ReachabilityMatrix(matrix);

    Console.WriteLine("Матрица достижимости: ");
        reachibilityMatrix.ReadMatrix();

    Console.Write("Проверка на связность: ");
    Console.WriteLine(reachibilityMatrix.ConnectedGraph(reachibilityMatrix));
