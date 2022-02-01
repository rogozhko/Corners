using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private Manager _manager;

    public Vector2 Coordinates { get; set; }

    private MeshRenderer _meshRenderer;
    private Color _baseColor;
    
    private void Awake() {
        _manager = Manager.Instance;
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    
    void OnMouseDown() {
        // Переписать это
        _manager.CheckIsMove(Coordinates);
    }

    void OnMouseEnter() {
        _baseColor = _meshRenderer.material.GetColor("_Color");
        SetColor(Color.green);
    }

    void OnMouseExit() {
        SetColor(_baseColor);
    }
    
    public void SetColor(Color color) {
        _meshRenderer.material.SetColor("_Color", color);
    }
}
