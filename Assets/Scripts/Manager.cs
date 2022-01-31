using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public enum State
    {
        MovePlayerOne,
        MovePlayerTwo,
    }
    public static Manager Instance;
    
    public GameObject currentFigure;
    
    private void Awake() {
        Instance = this;
    }

    public void CheckIsMove(Vector2 coordinates)
    {
        currentFigure.GetComponent<Figure>().Move(coordinates);
    }

    public State CurrentState = State.MovePlayerOne;

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
}
