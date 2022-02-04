using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays
{
    public static bool CheckIsContain(int a, int b)
    {
        return figures[a, b].name != null;
        
    }



    public static Figure[,] figures = new Figure[8,8];

    
    
    
    public static Tuple<int, int>[] playerOneFigureCoordinates = new Tuple<int, int>[]
    {
        new Tuple<int, int>(5,0), new Tuple<int, int>(6,0), new Tuple<int, int>(7,0),
        new Tuple<int, int>(5,1), new Tuple<int, int>(6,1), new Tuple<int, int>(7,1),
        new Tuple<int, int>(5,2), new Tuple<int, int>(6,2), new Tuple<int, int>(7,2)
    };
    
    public static Tuple<int, int>[] playerTwoFigureCoordinates = new Tuple<int, int>[]
    {
        new Tuple<int, int>(0,5), new Tuple<int, int>(0,6), new Tuple<int, int>(0,7),
        new Tuple<int, int>(1,5), new Tuple<int, int>(1,6), new Tuple<int, int>(1,7),
        new Tuple<int, int>(2,5), new Tuple<int, int>(2,6), new Tuple<int, int>(2,7)
    };
    
    
    // PlayerOne выиграет, если все фигуры будут в координатах playerTwo и наоборот
    // Метод, который проверяет это здесь и вызывать его в конце каждого хода.
    // Принимает плеера, чтобы не сравнивать сразу двух, поскольку по очереди ходят

    public void CheckIsWin(Player player)
    {
        
    }
    
    
    public static Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
    {
        int w = matrix.GetLength(0); // width
        int h = matrix.GetLength(1); // height

        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (matrix[x, y] == null) continue;
                if (!matrix[x, y].Equals(value)) continue;
                // Debug.Log($"{matrix[x,y]}");
                return Tuple.Create(x, y);
            }
        }

        return Tuple.Create(-1, -1);
    }
}