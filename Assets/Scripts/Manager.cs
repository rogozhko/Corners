using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    #region General

    private Dictionary<Type, IGameState> statesMap;
    private IGameState currentState;

    public static Manager Instance;

    private Figure currentFigure;
    public Figure CurrentFigure
    {
        get => currentFigure;
        set
        {
            currentFigure = value;
            Debug.Log($"Current Figure {CurrentFigure}");
        }
    }

    public GameField GameField { get; set; }

    private void Awake()
    {
        Instance = this;
        GameField = GetComponent<GameField>();
    }

    #endregion


    #region Logic

    

    #endregion


    #region State Machine

    private void Start()
    {
        InitGameStates();
        SetGameStateByDefault();
    }

    private void Update()
    {
        currentState?.Update();
    }

    private void InitGameStates()
    {
        statesMap = new Dictionary<Type, IGameState>();

        statesMap[typeof(GameStateStart)] = new GameStateStart();
        statesMap[typeof(GameStatePlayerOneMove)] = new GameStatePlayerOneMove();
        statesMap[typeof(GameStatePlayerTwoMove)] = new GameStatePlayerTwoMove();
        statesMap[typeof(GameStateResult)] = new GameStateResult();
    }

    private void SetGameState(IGameState newState)
    {
        currentState?.Exit();

        currentState = newState;
        currentState.Enter();
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
    
    public void SetGameStateStart()
    {
        var state = GetGameState<GameStateStart>();
        SetGameState(state);
    }

    public void SetGameStatePlayerOneMove()
    {
        var state = GetGameState<GameStatePlayerOneMove>();
        SetGameState(state);
    }

    public void SetGameStatePlayerTwoMove()
    {
        var state = GetGameState<GameStatePlayerTwoMove>();
        SetGameState(state);
    }

    public void SetGameStateResult()
    {
        var state = GetGameState<GameStateResult>();
        SetGameState(state);
    }

    #endregion
}