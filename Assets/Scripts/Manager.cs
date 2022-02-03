using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    #region ForRefactor
    
    public delegate void ChangeCurrentFigure();
    public event ChangeCurrentFigure OnCurrentFigureChanged;
    
    private GameField gameField;

    private GameObject figurePrefab;
    
    public static Manager Instance;

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
        gameField = GetComponent<GameField>();
        figurePrefab = Resources.Load("Prefabs/Figure", typeof(GameObject)) as GameObject;
    }

    private void SetupGame()
    {
        gameField.CreateGameField();
        SetupFigures();
    }

    public void CheckIsMove(Vector2 coordinates)
    {
        if (!_currentFigure) return;
        
        var curPos = CurrentFigure.Position;

        if (Math.Abs(curPos.x - coordinates.x) <= 1 && Math.Abs(curPos.y - coordinates.y) <= 1)
        {
            CurrentFigure.Move(coordinates);    
        }
    }

    public void SetupFigures()
    {
        Vector3 coordinate1 = new Vector3(7, figurePrefab.transform.position.y, 0);
        Vector3 coordinate2 = new Vector3(0, figurePrefab.transform.position.y, 7);
        
        var Figure1 = Instantiate(figurePrefab, coordinate1, Quaternion.identity);
        var Figure2 = Instantiate(figurePrefab, coordinate2, Quaternion.identity);
        
        Figure2.GetComponent<Figure>().SetMaterial();
    }
    
    
    #endregion

    
    private void Start()
    {
        InitGameStates();
        SetGameStateByDefault();
    }

    private void Update()
    {
        stateCurrent?.Update();
    }
    
    
    #region State Machine
    
    private Dictionary<Type, IGameState> statesMap;
    private IGameState stateCurrent;
    
    private void InitGameStates() {
        statesMap = new Dictionary<Type, IGameState>();
        
        statesMap[typeof(GameStateStart)] = new GameStateStart();
        statesMap[typeof(GameStatePlayerOneMove)] = new GameStatePlayerOneMove();
        statesMap[typeof(GameStatePlayerTwoMove)] = new GameStatePlayerTwoMove();
        statesMap[typeof(GameStateResult)] = new GameStateResult();
    }

    private void SetGameState(IGameState newState) {
        stateCurrent?.Exit();

        stateCurrent = newState;
        stateCurrent.Enter();
    }

    private void SetGameStateByDefault()
    {
        SetGameStateStart();
    }
    
    private IGameState GetGameState<T>() where T : IGameState
    {
        var type = typeof(T);
        return statesMap[type];
    }
    
    //Методы для установки состояний
    public void SetGameStateStart() {
        var state = GetGameState<GameStateStart>();
        SetGameState(state);
    }

    public void SetGameStatePlayerOneMove() {
        var state = GetGameState<GameStatePlayerOneMove>();
        SetGameState(state);
    }

    public void SetGameStatePlayerTwoMove() {
        var state = GetGameState<GameStatePlayerTwoMove>();
        SetGameState(state);
    }

    public void SetGameStateResult() {
        var state = GetGameState<GameStateResult>();
        SetGameState(state);
    }

    #endregion
}
