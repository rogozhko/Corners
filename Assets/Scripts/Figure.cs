using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    private Manager manager = Manager.Instance;

    public Player PlayerType { get; set; }

    private Tuple<int, int> coordinates;

    public Tuple<int, int> Coordinates
    {
        get
        {
            return coordinates;
        }
        set
        {
            coordinates = value;
            Arrays.figures[coordinates.Item1, coordinates.Item2] = this;
        }
    }

    private MeshRenderer meshRenderer;

    private Vector3 dragOffset;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
    }
    
    private Vector3 currentPos;

    
    #region Events

    private void OnMouseDown()
    {
        if (manager.CurrentPlayer != PlayerType) return;
        dragOffset = transform.position - Utils.GetMousePosition();
        currentPos = transform.position;
    }

    private void OnMouseDrag()
    {
        if (manager.CurrentPlayer != PlayerType) return;
        var mousePosition = Utils.GetMousePosition();
        mousePosition.y += 1;

        transform.position = Vector3.MoveTowards(
            transform.position, mousePosition + dragOffset, 20 * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        //Если не этот игрок - выходим
        if (manager.CurrentPlayer != PlayerType) return;

        // Если за полем и несводона клетка и расстояние не больше 1 клетки
        if (!Utils.CheckIsOutOfFieldEdge() && !Arrays.CheckIsCoordinatesAvaible() && CheckIsMoreThanAvailableMove())
        {
            RemoveFromArray();
            SnapFigure();

            DebugCoordinatesPlayerTypeAndCoordinatesInArray();
            // DebugCountInOppociteCornerAndIsWin();
        }
        
        else
        {
            transform.position = currentPos;
        }
    }

    #endregion
    

    private int cellToMoveAvailable = 2;
    
    private bool CheckIsMoreThanAvailableMove()
    {
        var current = Utils.GetCoordinatesFromPosition(currentPos);
        var mouse = Utils.GetRoundMousePosition();

        if (Mathf.Abs(mouse.Item1 - current.Item1) > cellToMoveAvailable) return false;
        if (Mathf.Abs(mouse.Item2 - current.Item2) > cellToMoveAvailable) return false;
        
        return true;
    }
    
    
    
    
    #region Move

    private void RemoveFromArray()
    {
        Arrays.figures[coordinates.Item1, coordinates.Item2] = null;
    }

    private void SnapFigure()
    {
        var mousePosition = Utils.GetRoundMousePosition();
        var position = Utils.GetPositionFromCoordinates(mousePosition);
        position.y = currentPos.y;
        transform.position = position;
        Coordinates = mousePosition;
    }

    #endregion

    #region Setup

    public void SetupCoordinates(Tuple<int, int> coordinates)
    {
        Coordinates = coordinates;
    }

    public void SetPlayerType(Player playerType)
    {
        PlayerType = playerType;
        SetFigureColor(playerType);
    }

    private void SetFigureColor(Player playerType)
    {
        if (playerType == Player.One)
            meshRenderer.material.SetColor("_Color", Color.blue);
        if (playerType == Player.Two)
            meshRenderer.material.SetColor("_Color", Color.red);
    }

    #endregion

    #region Debug
    
     private void DebugCoordinatesPlayerTypeAndCoordinatesInArray()
     {
         Debug.Log($"{gameObject.name} : Coordinates: {Coordinates}," +
                   $" Player: {PlayerType}, In Arrays.figures: {Arrays.CoordinatesOf(Arrays.figures, this)}");
     }

    private void DebugCountInOppociteCornerAndIsWin()
    {
        Debug.Log(Arrays.CountOfCurrentPlayerFiguresInEnemyField(PlayerType));
        if(Arrays.CheckIsWin(PlayerType)) Debug.Log($"Winner is {PlayerType}");
    }

    #endregion
}