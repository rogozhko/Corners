using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    private Color _color = new Color(215, 215, 215);
    private bool checkerColor = true;

    private int fieldDimention = 4;

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        CreateGameField();
    }

    private void CreateGameField()
    {
        GameObject gameField = new GameObject("GameField");

        for (int i = 0; i < fieldDimention; i++)
        {
            for (int j = 0; j < fieldDimention; j++)
            {
                var cell = Instantiate(cellPrefab,gameField.transform);

                cell.transform.position = new Vector3(i, cell.transform.position.y, j);
                
                if (checkerColor) {
                    cell.GetComponent<MeshRenderer>().material.color = _color;
                }

                checkerColor = !checkerColor;
                
                cell.GetComponent<Cell>().Coordinates = new Vector2(i, j);
            }
            checkerColor = !checkerColor;
        }
    }
}
