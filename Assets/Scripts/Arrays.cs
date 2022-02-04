using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays
{
    public void Message()
    {
        // Debug.Log("Hi! I'm Arrays class!");

        
    }

    /// <summary>
    /// Проверить есть ли что-то в ячейке
    /// </summary>
    /// <param name="a">Горизонталь a</param>
    /// <param name="b">Вертикаль b</param>
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
}