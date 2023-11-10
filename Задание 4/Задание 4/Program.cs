using System;
using System.Collections.Generic;

class Program
{
    static int[,] graph = {
        {0, 10, 15, 20},
        {10, 0, 35, 25},
        {15, 35, 0, 30},
        {20, 25, 30, 0}
    };

    static int numCities = graph.GetLength(0);
    static List<int> path = new List<int>();

    static int GetTravelingSalesmanDistance(List<int> path)
    {
        int distance = 0;

        for (int i = 0; i < numCities - 1; i++)
        {
            int currentCity = path[i];
            int nextCity = path[i + 1];
            distance += graph[currentCity, nextCity];
        }

        distance += graph[path[numCities - 1], path[0]];

        return distance;
    }

    static void Main()
    {
        for (int i = 0; i < numCities; i++)
        {
            path.Add(i);
        }

        int minDistance = int.MaxValue;

        // Полный перебор всех возможных путей
        do
        {
            int distance = GetTravelingSalesmanDistance(path);

            if (distance < minDistance)
            {
                minDistance = distance;
            }

        } while (NextPermutation()); // Метод для генерации следующей перестановки

        Console.WriteLine("Минимальное расстояние: " + minDistance);
    }

    static bool NextPermutation()
    {
        int i = numCities - 2;
        while (i >= 0 && path[i] >= path[i + 1])
        {
            i--;
        }

        if (i < 0)
        {
            return false;
        }

        int j = numCities - 1;
        while (path[j] <= path[i])
        {
            j--;
        }

        Swap(i, j);

        Array.Reverse(path.GetRange(i + 1, numCities - i - 1).ToArray());
        return true;
    }

    static void Swap(int i, int j)
    {
        int temp = path[i];
        path[i] = path[j];
        path[j] = temp;
    }
}