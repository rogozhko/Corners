using System;
using UnityEngine;


public class Logic1 : Logic
{
    Manager manager = Manager.Instance;


    public override void Run()
    {
        base.Run();

        DiagonalLogic();
    }


    #region Logic1

    private void DiagonalLogic()
    {
        // Если на координате не null выходим
        if (Arrays.CheckIsOtherFigure()) return;

        // Координаты курсора
        var cursorPos = Utils.GetRoundMousePosition();

        // Массив с четыремя ДИАГОНАЛЬНЫМИ элементами на расстоянии 2 шага
        var arrayOfFour = GetFourDialgonalElementsTwoStep();

        Tuple<int, int> nextPos = null;

        if (Equals(arrayOfFour[0], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[0].Item1 + 1, arrayOfFour[0].Item2 + 1);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в верхнем левом углу");
        }
        if (Equals(arrayOfFour[1], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[1].Item1 + 1, arrayOfFour[1].Item2 - 1);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в верхнем правом углу");
        }
        if (Equals(arrayOfFour[2], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[2].Item1 - 1, arrayOfFour[2].Item2 + 1);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в нижнем левом углу");
        }
        if (Equals(arrayOfFour[3], cursorPos))
        {
            nextPos = new Tuple<int, int>(arrayOfFour[3].Item1 - 1, arrayOfFour[3].Item2 - 1);
            Debug.Log($"{manager.CurrentFigure.Coordinates} Курсор в нижнем правом углу");
        }


        // Проверить если ли враг на nextPos , на позиции плюс одна клетка к текущей фигуре
        if (nextPos != null && Arrays.CheckIsEnemyFigure(nextPos))
        {
            // Debug.Log("Поставить сюда фигуру");
            Debug.Log($"Противник на: {nextPos}");
            RemoveFromArray(manager.CurrentFigure);
            MoveFigure(manager.CurrentFigure);
        }
        else
        {
            BackToCurrentPosition(manager.CurrentFigure);
        }
    }

    private Tuple<int, int>[] GetFourDialgonalElementsTwoStep()
    {
        var m = Arrays.GetDoubleMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        var fourCoordinates = new Tuple<int, int>[] {m[0, 0], m[0, 4], m[4, 0], m[4, 4]};

        return fourCoordinates;
    }

    #endregion
}