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


    [SerializeField] public Vector2 Position { get; set; }
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


        UpdatePosition();
    }


    private Vector3 dragOffset;

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePosition();
        manager.CurrentFigure = this;
        UpdatePosition();
    }

    private void OnMouseDrag()
    {
        var mousePosition = GetMousePosition();
        mousePosition.y += 1;
        transform.position = Vector3.MoveTowards(
            transform.position, mousePosition + dragOffset, 10 * Time.deltaTime);
    }


    Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = currentY;
        return mousePosition;
    }


    private void UpdatePosition()
    {
        Position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
        Debug.Log("Position is Update");
    }

    public void SetFigureColor(FigureColor figureColor)
    {
        if (figureColor == FigureColor.Blue)
            meshRenderer.material.SetColor("_Color", Color.blue);
        if (figureColor == FigureColor.Red)
            meshRenderer.material.SetColor("_Color", Color.red);
    }
}