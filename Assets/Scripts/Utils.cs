using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static Tuple<int, int> GetRoundMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var x = Mathf.RoundToInt(mousePosition.x);
        var y = Mathf.RoundToInt(mousePosition.z);
        return new Tuple<int, int>(x, y);
    }

    public static bool CheckIsOutOfFieldEdge()
    {
        var pos = GetRoundMousePosition();

        if (pos.Item1 < 0 || pos.Item1 > 7)
            return true;
        if (pos.Item2 < 0 || pos.Item2 > 7)
            return true;
        
        return false;
    }


    public static Vector3 GetPositionFromCoordinates(Tuple<int, int> coordinates)
    {
        return new Vector3(coordinates.Item1, 0, coordinates.Item2);
    }

    public static Tuple<int, int> GetCoordinatesFromPosition(Vector3 position)
    {
        Tuple<int, int> t = new Tuple<int, int>((int)position.x, (int)position.z);
        return t;
    }
    
    
}