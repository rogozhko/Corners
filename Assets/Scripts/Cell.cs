using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private Manager _manager;
    
    private enum State
    {
        Idle,
        Select
    }

    public Vector2 Coordinates { get; set; }
    
    private void Awake() {
        _manager = Manager.Instance;
    }

    void OnMouseDown()
    {
        _manager.CheckIsMove(Coordinates);
        // Debug.Log(Coordinates);
    }
}
