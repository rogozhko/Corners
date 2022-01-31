using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;

    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    
    private bool checkerColor = true;

    private int fieldDimention = 8;


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
                
                if (checkerColor)
                {
                    cell.GetComponent<MeshRenderer>().material = material1;
                }
                else
                {
                    cell.GetComponent<MeshRenderer>().material = material2;
                }

                checkerColor = !checkerColor;
                
                cell.GetComponent<Cell>().Coordinates = new Vector2(i, j);
            }
            checkerColor = !checkerColor;
        }
    }
}
