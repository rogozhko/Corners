using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    private Manager manager = Manager.Instance;

    public Player PlayerType { get; set; }
    public Tuple<int, int> Coordinates { get; set; }
    private float currentY;

    private MeshRenderer meshRenderer;

    private Vector3 dragOffset;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        currentY = gameObject.transform.position.y;
    }


    private Vector3 currentPos;

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
        if (manager.CurrentPlayer != PlayerType) return;

        if (!Utils.CheckIsOutOfFieldEdge() && !CheckIsAvaible())
        {
            SnapFigure();
            PullFromArray();
            UpdateCoordinates();
            PutInArray();
        }
        else
        {
            transform.position = currentPos;
        }

        // ShowDebug();
        Debug.Log(Arrays.CountOfCurrentPlayerFiguresInEnemyField(PlayerType));
        if(Arrays.CheckIsWin(PlayerType)) Debug.Log($"Winner is {PlayerType}");
    }
    
    private bool CheckIsAvaible()
    {
        var mousePosition = Utils.GetRoundMousePosition();
        return Arrays.CheckIsContain(mousePosition.Item1, mousePosition.Item2);
    }

    private void SnapFigure()
    {
        var mousePosition = Utils.GetRoundMousePosition();
        var position = new Vector3(mousePosition.Item1, currentY, mousePosition.Item2);
        transform.position = position;
    }

    private void UpdateCoordinates()
    {
        var a = transform.position.x;
        var b = transform.position.z;
        Coordinates = new Tuple<int, int>(Mathf.RoundToInt(a), Mathf.RoundToInt(b));
    }

    public void UpdateCoordinates(Tuple<int, int> coordinates)
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


    private void PullFromArray()
    {
        Arrays.figures[Coordinates.Item1, Coordinates.Item2] = null;
    }

    private void PutInArray()
    {
        Arrays.figures[Coordinates.Item1, Coordinates.Item2] = this;
    }

    #region Debug

    //Debug
    // private void ShowDebug()
    // {
    //     Debug.Log($"{gameObject.name} : Coordinates: {Coordinates}," +
    //               $" Player: {PlayerType}, In Arrays.figures: {Arrays.CoordinatesOf(Arrays.figures, this)}");
    // }

    #endregion
}