﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum CellColor
{
    White,
    Black
}

public class Cell : MonoBehaviour
{
    public Vector2 Coordinates { get; set; }
    private MeshRenderer meshRenderer;


    public Cell(CellColor cellColor)
    {
        if (cellColor == CellColor.Black)
            Debug.Log("Создали черную клетку");
        if (cellColor == CellColor.White)
            Debug.Log("Создали белую клетку");
    }


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnMouseDown()
    {
    }

    void OnMouseEnter()
    {
    }

    void OnMouseExit()
    {
    }

    public void SetCellColor(CellColor cellColor)
    {
        if (cellColor == CellColor.Black)
            meshRenderer.material.SetColor("_Color", Color.black);
        if(cellColor == CellColor.White)
            meshRenderer.material.SetColor("_Color", Color.white);
    }
}