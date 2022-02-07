using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    One,
    Two
}

public class Manager : MonoBehaviour
{
    #region General

    private Dictionary<Type, IGameState> statesMap;
    private IGameState currentState;

    public static Manager Instance;

    [SerializeField] private Player currentPlayer;

    public Player CurrentPlayer
    {
        get => currentPlayer;
        set => currentPlayer = value;
    }

    private Figure currentFigure;

    public Figure CurrentFigure
    {
        get => currentFigure;
        set { currentFigure = value; }
    }

    public GameField GameField { get; set; }

    public Logic CurrentLogic { get; set; }

    #region UI -----------------------------

    public UIManager uiManager { get; set; }
    public int FirstPlayerMoves { get; set; }
    public int SecondPlayerMoves { get; set; }

    #endregion

    #endregion

    private void Awake()
    {
        Instance = this;
        GameField = GetComponent<GameField>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        SetLogic();
        Debug.Log(CurrentLogic);

        InitGameStates();
        SetGameStateByDefault();
    }

    private void SetLogic()
    {
        if (DataHolder.LogicNumber == 1) CurrentLogic = new Logic1();
        if (DataHolder.LogicNumber == 2) CurrentLogic = new Logic2();
        if (DataHolder.LogicNumber == 3) CurrentLogic = new Logic3();
        if (DataHolder.LogicNumber == 4) CurrentLogic = new DebugLogic();
    }

    private void Update()
    {
        currentState?.Update();
    }

    #region State Machine

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


    #region Debug ChangeColor

    private Color currentColor = Color.black;


    public void ChangeFiguresColor()
    {
        foreach (var figure in Arrays.figures)
        {
            if (figure == null || figure.PlayerType == CurrentPlayer) continue;
            var current = figure.GetComponent<MeshRenderer>().material.color;
            currentColor = current;

            current = Color.black;
            var some = 0;
            figure.GetComponent<MeshRenderer>().material
                .SetColor("_Color", new Color(current.r + some, current.g + some, current.b + some));
        }
    }

    public void BackFiguresColor()
    {
        foreach (var figure in Arrays.figures)
        {
            if (figure == null || figure.PlayerType == CurrentPlayer) continue;
            var current = figure.GetComponent<MeshRenderer>().material.color;
            figure.GetComponent<MeshRenderer>().material
                .SetColor("_Color", currentColor);
        }
    }

    #endregion
}