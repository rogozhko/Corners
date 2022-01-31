using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public delegate void ChangeCurrentFigure();

    public event ChangeCurrentFigure OnCurrentFigureChanged;
    
    public static Manager Instance;
    public enum State
    {
        MovePlayerOne,
        MovePlayerTwo,
    }

    [HideInInspector] public State CurrentState = State.MovePlayerOne;
    
    [SerializeField] private GameObject figurePrefab;

    private Figure _currentFigure;
    [HideInInspector] public Figure CurrentFigure
    {
        get => _currentFigure;
        set {
            _currentFigure = value;
            OnCurrentFigureChanged?.Invoke();
        }
    }
    
    
    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        SetupFigures();
    }

    public void CheckIsMove(Vector2 coordinates)
    {
        CurrentFigure.Move(coordinates);
    }

    public void SetupFigures()
    {
        Vector3 coordinate_1 = new Vector3(7, figurePrefab.transform.position.y, 0);
        Vector3 coordinate_2 = new Vector3(0, figurePrefab.transform.position.y, 7);
        
        Instantiate(figurePrefab, coordinate_1, Quaternion.identity);
        Instantiate(figurePrefab, coordinate_2, Quaternion.identity);
    }
    
    
    
    
    
    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
}
