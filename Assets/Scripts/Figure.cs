using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Figure : MonoBehaviour
{
    private Manager _manager;

    [SerializeField] private GameObject selector;
    
    [SerializeField] private Vector2 CurrentPosition { get; set; }
    [SerializeField] private float currentY;
    
    private void Start()
    {
        currentY = gameObject.transform.position.y;
        _manager = Manager.Instance;
        CurrentPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);

        _manager.OnCurrentFigureChanged += HideSelector;
    }

    private void Update()
    {
        
    }

    public void Move(Vector2 target) {
        transform.position = new Vector3(target.x, currentY, target.y);
    }

    private void OnMouseDown() {
        _manager.CurrentFigure = this;
        selector.gameObject.SetActive(true);
    }
    
    private void HideSelector() {
        if (_manager.CurrentFigure != this) {
            selector.gameObject.SetActive(false);
        }
    }
}
