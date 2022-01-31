using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Figure : MonoBehaviour
{
    private Manager _manager;
    
    [SerializeField] public Vector2 CurrentPosition { get; set; }
    [SerializeField] private float currentY;
    
    private void Start()
    {
        currentY = gameObject.transform.position.y;
        _manager = Manager.Instance;
        CurrentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
        _manager.currentFigure = this.gameObject;
    }

    private bool isMove = false;
    
    private void Update()
    {
        
    }

    public void Move(Vector2 target)
    {
        transform.position = new Vector3(target.x, currentY, target.y);
    }

    private void OnMouseDown()
    {
        // Move(new Vector2(2,2));
    }
}
