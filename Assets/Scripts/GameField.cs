using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    private GameObject cellPrefab;
    private bool checkerColor = true;
    private int fieldDimention = 8;

    private Figure[] figures;
    private GameObject figurePrefab;

    private void Awake()
    {
        cellPrefab = Resources.Load("Prefabs/Cell", typeof(GameObject)) as GameObject;
        figurePrefab = Resources.Load("Prefabs/Figure", typeof(GameObject)) as GameObject;
    }


    public void CreateGameField()
    {
        GameObject gameField = new GameObject("GameField");

        for (int i = 0; i < fieldDimention; i++)
        {
            for (int j = 0; j < fieldDimention; j++)
            {
                var cell = Instantiate(cellPrefab, gameField.transform);

                cell.transform.position = new Vector3(i, cell.transform.position.y, j);

                if (checkerColor)
                {
                    cell.GetComponent<Cell>().SetCellColor(CellColor.White);
                }
                else
                {
                    cell.GetComponent<Cell>().SetCellColor(CellColor.Black);
                }

                checkerColor = !checkerColor;

                cell.GetComponent<Cell>().Coordinates = new Vector2(i, j);
            }

            checkerColor = !checkerColor;
        }
    }

    public void CreateFigures()
    {
        CreateOneFigure(new Vector2(7, 0), FigureColor.Red);
        CreateOneFigure(new Vector2(0, 7), FigureColor.Blue);
    }

    private void CreateOneFigure(Vector2 coordinates, FigureColor figureColor)
    {
        Vector3 position =
            new Vector3(coordinates.x, figurePrefab.transform.position.y, coordinates.y);
        GameObject figure = Instantiate(figurePrefab, position, Quaternion.identity);
        figure.GetComponent<Figure>().SetFigureColor(figureColor);
    }
}