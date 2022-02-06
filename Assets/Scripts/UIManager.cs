using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Manager manager;
    
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text firstPlayerMoves;
    [SerializeField] private TMP_Text secondPlayerMoves;

    private void Start()
    {
        manager = Manager.Instance;
    }
    
    public void UpdateStateUI()
    {
        if (manager.CurrentPlayer == Player.One)
        {
            text.text = "First Player Turn";
        }
        
        if (manager.CurrentPlayer == Player.Two)
        {
            text.text = "Second Player Turn";
        }

        firstPlayerMoves.text = manager.FirstPlayerMoves.ToString();
        secondPlayerMoves.text = manager.SecondPlayerMoves.ToString();
    }
    
    public void UpdateStateUI(string inText)
    {
        text.text = inText;
    }
    
    
}
