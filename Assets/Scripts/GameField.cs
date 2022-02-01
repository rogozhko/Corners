using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    private GameObject cellPrefab;

    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    
    private bool checkerMaterial = true;

    private int fieldDimention = 8;


    private void Awake()
    {
        cellPrefab = Resources.Load("Prefabs/Cell", typeof(GameObject)) as GameObject;
    }
    
    
    public void CreateGameField()
    {
        GameObject gameField = new GameObject("GameField");

        for (int i = 0; i < fieldDimention; i++)
        {
            for (int j = 0; j < fieldDimention; j++)
            {
                var cell = Instantiate(cellPrefab,gameField.transform);

                cell.transform.position = new Vector3(i, cell.transform.position.y, j);
                
                if (checkerMaterial)
                {
                    cell.GetComponent<Cell>().SetColor(Color.grey);
                }
                else
                {
                    cell.GetComponent<Cell>().SetColor(Color.black);
                }

                checkerMaterial = !checkerMaterial;
                
                cell.GetComponent<Cell>().Coordinates = new Vector2(i, j);
            }
            checkerMaterial = !checkerMaterial;
        }
    }
}
