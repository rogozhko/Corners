using System;
using System.Collections.Generic;
using UnityEngine;


public class Logic2 : ILogic
{
    Manager manager = Manager.Instance;


    public void Run(Figure figure)
    {
        // Если ячейка рядом и нет другой фигуры
        if (CheckIsOneStepAround() && !Arrays.CheckIsOtherFigure())
        {
            RemoveFromArray(figure);
            SnapFigure(figure);
            // return;
        }
        else
        {
            BackToCurrentPosition(manager.CurrentFigure);
        }

        VerticalAndHorizontalLogic();
    }

    #region Move

    private void BackToCurrentPosition(Figure figure)
    {
        figure.transform.position = Utils.GetPositionFromCoordinates(figure.Coordinates);
    }

    private void RemoveFromArray(Figure figure)
    {
        Arrays.figures[figure.Coordinates.Item1, figure.Coordinates.Item2] = null;
    }

    private void SnapFigure(Figure figure)
    {
        var mousePosition = Utils.GetRoundMousePosition();
        var position = Utils.GetPositionFromCoordinates(mousePosition);
        figure.transform.position = position;
        figure.Coordinates = mousePosition;
    }

    #endregion


    private void VerticalAndHorizontalLogic()
    {
        // Если на координате не null выходим
        if (Arrays.CheckIsOtherFigure()) return;

        // Координаты курсора
        var cursorPos = Utils.GetRoundMousePosition();

        // Массив с четыремя элементами на расстоянии 2 шага
        var arrayOfFour = GetHorizontalAndVerticalElementsTwoStep();

        Tuple<int, int> nextPos = null;

        if (Equals(arrayOfFour[0], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[0].Item1 + 1, arrayOfFour[0].Item2);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в верхней точке");
        }

        if (Equals(arrayOfFour[1], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[1].Item1 - 1, arrayOfFour[1].Item2);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в нижней точке");
        }
        if (Equals(arrayOfFour[2], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[2].Item1, arrayOfFour[2].Item2 + 1);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в левой точке");
        }
        if (Equals(arrayOfFour[3], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[3].Item1, arrayOfFour[3].Item2 - 1);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в правой точке");
        }
        
        
        // Проверить если ли враг на nextPos , на позиции плюс одна клетка к текущей фигуре
        if (nextPos != null && CheckIsEnemyFigure(nextPos))
        {
            Debug.Log("Поставить сюда фигуру");
            Debug.Log($"Противник на: {nextPos}");
            RemoveFromArray(manager.CurrentFigure);
            SnapFigure(manager.CurrentFigure);
        }
        else
        {
            BackToCurrentPosition(manager.CurrentFigure);
        }
    }


    // Получить массив 4х координат по вертикали и горизонтали
    private Tuple<int, int>[] GetHorizontalAndVerticalElementsOneStep()
    {
        var m = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        var fourCoordinates = new Tuple<int, int>[] {m[0, 1], m[2, 1], m[1, 0], m[1, 2]};

        return fourCoordinates;
    }

    private Tuple<int, int>[] GetHorizontalAndVerticalElementsTwoStep()
    {
        var m = Arrays.GetDoubleMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        var fourCoordinates = new Tuple<int, int>[] {m[0, 2], m[4, 2], m[2, 0], m[2, 4]};

        return fourCoordinates;
    }


    private bool CheckIsTwoStepAround()
    {
        var a = Arrays.GetDoubleMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), a);
    }


    private bool CheckIsEnemyFigure(Tuple<int, int> coordinates)
    {
        var array = Arrays.figures;

        if (coordinates.Item1 < 0 || coordinates.Item1 >= array.GetLength(0) ||
            coordinates.Item2 < 0 || coordinates.Item2 >= array.GetLength(1))
        {
            return false;
        }

        if (Arrays.figures[coordinates.Item1, coordinates.Item2] == null) return false;

        return Arrays.figures[coordinates.Item1, coordinates.Item2].PlayerType != manager.CurrentPlayer;
    }

    // Первая логика, ходит на одну клетку вокруг
    private bool CheckIsOneStepAround()
    {
        var a = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), a);
    }
}