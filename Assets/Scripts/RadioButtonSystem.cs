using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadioButtonSystem : MonoBehaviour
{
    private ToggleGroup toggleGroup;

    private void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }
    
    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();

        var text = toggle.GetComponentInChildren<Text>().text;
        
        Debug.Log(toggle.GetComponentInChildren<Text>().text);

        // DataHolder.LogicNumber = 1;
        
        if(text == "Diagonal jump") DataHolder.LogicNumber = 1;
        if(text == "Vertical And Horizontal") DataHolder.LogicNumber = 2;
        if(text == "No Jump") DataHolder.LogicNumber = 3;
        if (text == "Debug")
        {
            DataHolder.WinCount = 9;
            DataHolder.LogicNumber = 4;
        }
        
        SceneManager.LoadScene("Game");
    }
}

