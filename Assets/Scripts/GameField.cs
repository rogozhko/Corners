using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    private GameObject cellPrefab;
    private bool checkerColor = true;
    private int fieldDimention = 8;

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


    public void CreateFigures()
    {
        GameObject figures = new GameObject("Figures");

        foreach (var t in Arrays.playerOneFigureCoordinates)
        {
            var figure = CreateOneFigure(t, Player.One);
            figure.transform.SetParent(figures.transform);
        }

        foreach (var t in Arrays.playerTwoFigureCoordinates)
        {
            var figure = CreateOneFigure(t, Player.Two);
            figure.transform.SetParent(figures.transform);
        }
    }


    private GameObject CreateOneFigure(Tuple<int, int> coordinates, Player playerType)
    {
        var position = Utils.GetVector3FromCoordinates(coordinates);

        position.y = figurePrefab.transform.position.y;

        GameObject figureGO = Instantiate(figurePrefab, position, Quaternion.identity);

        var figure = figureGO.GetComponent<Figure>();

        figure.SetPlayerType(playerType);
        figure.UpdateCoordinates(coordinates);
        //
        // figure.GetComponent<Figure>().SetPlayerType(playerType);
        // figure.GetComponent<Figure>().UpdateCoordinates(coordinates);

        figureGO.name = "Figure" + figureCount;
        figureCount++;
        
        Arrays.figures[coordinates.Item1, coordinates.Item2] = figure;


        return figureGO;
    }
}