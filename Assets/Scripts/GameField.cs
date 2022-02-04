using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    private GameObject cellPrefab;
    private bool checkerColor = true;
    private int fieldDimention = 8;

    [SerializeField] private List<Figure> figures;
    private GameObject figurePrefab;

    private int figureCount;

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


    private Vector2[] playerOneFigurePositions = new[]
    {
        new Vector2(5, 0), new Vector2(6, 0), new Vector2(7, 0),
        new Vector2(5, 1), new Vector2(6, 1), new Vector2(7, 1),
        new Vector2(5, 2), new Vector2(6, 2), new Vector2(7, 2),
    };
    
    private Vector2[] playerTwoFigurePositions = new[]
    {
        new Vector2(0, 5), new Vector2(0, 6), new Vector2(0, 7),
        new Vector2(1, 5), new Vector2(1, 6), new Vector2(1, 7),
        new Vector2(2, 5), new Vector2(2, 6), new Vector2(2, 7),
    };
    
    public void CreateFigures()
    {
        GameObject figures = new GameObject("Figures");

        foreach (var position in playerOneFigurePositions)
        {
            var figure = CreateOneFigure(position, FigureColor.Blue);
            figure.transform.SetParent(figures.transform);
        }
        
        foreach (var position in playerTwoFigurePositions)
        {
            var figure = CreateOneFigure(position, FigureColor.Red);
            figure.transform.SetParent(figures.transform);
        }
    }

    private GameObject CreateOneFigure(Vector2 coordinates, FigureColor figureColor)
    {
        Vector3 position =
            new Vector3(coordinates.x, figurePrefab.transform.position.y, coordinates.y);
        GameObject figure = Instantiate(figurePrefab, position, Quaternion.identity);

        figure.GetComponent<Figure>().SetFigureColor(figureColor);

        figures.Add(figure.GetComponent<Figure>());

        figure.name = "Figure" + figureCount;
        figureCount++;

        return figure;
    }
}