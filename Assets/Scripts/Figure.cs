﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    private Manager manager = Manager.Instance;

    [SerializeField] private Player playerType;
    
    [SerializeField] public Vector2 Coordinates { get; set; }
    [SerializeField] private float currentY;

    private MeshRenderer meshRenderer;

    private Vector3 dragOffset;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        currentY = gameObject.transform.position.y;
        UpdateCoordinates();
    }


    private void OnMouseDown()
    {
        UpdateCoordinates();
        dragOffset = transform.position - GetMousePosition();
        manager.CurrentFigure = this;
    }

    private void OnMouseDrag()
    {
        var mousePosition = GetMousePosition();
        mousePosition.y += 1;
        transform.position = Vector3.MoveTowards(
            transform.position, mousePosition + dragOffset, 20 * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        transform.position = GetPositionFromCoordinates();
    }


    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = currentY;
        return mousePosition;
    }

    private Vector3 GetPositionFromCoordinates()
    {
        return new Vector3(Coordinates.x, currentY, Coordinates.y);
    }

    private void UpdateCoordinates()
    {
        Coordinates = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
    }

    public void SetPlayerType(Player playerType)
    {
        this.playerType = playerType;
        SetFigureColor(playerType);
    }
    
    private void SetFigureColor(Player playerType)
    {
        if (playerType == Player.One)
            meshRenderer.material.SetColor("_Color", Color.blue);
        if (playerType == Player.Two)
            meshRenderer.material.SetColor("_Color", Color.red);
    }
}