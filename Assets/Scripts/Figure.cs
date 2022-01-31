using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Figure : MonoBehaviour
{
    private Manager _manager;

    [SerializeField] private GameObject selector;
    [SerializeField] private Material[] _materials;
    
    
    [SerializeField] public Vector2 Position { get; set; }
    [SerializeField] private float currentY;
    
    private void Start()
    {
        currentY = gameObject.transform.position.y;
        _manager = Manager.Instance;

        _manager.OnCurrentFigureChanged += HideSelector;
        UpdatePosition();
    }

    private void Update()
    {
        
    }

    public void Move(Vector2 target) {
        transform.position = new Vector3(target.x, currentY, target.y);
        UpdatePosition();
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

    private void UpdatePosition()
    {
        Position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
    }

    public void SetMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = _materials[1];
    }
}
