using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private enum State
    {
        Idle,
        Select
    }


    public Vector2 Coordinates { get; set; }

    void OnMouseDown()
    {
        Debug.Log(Coordinates);
    }
}
