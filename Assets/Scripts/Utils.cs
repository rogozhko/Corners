using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetVector3FromCoordinates(int a, int b)
    {
        return new Vector3(a, 0, b);
    }
    public static Vector3 GetVector3FromCoordinates(Tuple<int, int> coordinates)
    {
        return new Vector3(coordinates.Item1, 0, coordinates.Item2);
    }
}
