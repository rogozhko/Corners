using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FigureColor
{
    Red,
    Blue
}

public class Figure : MonoBehaviour
{
    private Manager manager;


    [SerializeField] public Vector2 Coordinates { get; set; }
    [SerializeField] private float currentY;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        currentY = gameObject.transform.position.y;
        manager = Manager.Instance;


        UpdateCoordinates();
    }


    private Vector3 dragOffset;

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


    Vector3 GetMousePosition()
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
        Debug.Log($"Position is Update {Coordinates}");
    }

    public void SetFigureColor(FigureColor figureColor)
    {
        if (figureColor == FigureColor.Blue)
            meshRenderer.material.SetColor("_Color", Color.blue);
        if (figureColor == FigureColor.Red)
            meshRenderer.material.SetColor("_Color", Color.red);
    }
}