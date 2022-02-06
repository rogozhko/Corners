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

        Test();
        RemoveFromArray(figure);
        SnapFigure(figure);


        // else
        // {
        //     BackToCurrentPosition(figure);
        // }
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


    // Если два шага вокруг
    // Если соседей-противников не ноль
    // Получить следующую координату от противника, согласно правилу
    // Принадлежит 
    // Сравнить нет ли там другой фигуры
    // Поставить


    // Если курсор принадлежит одной из четырех точек верх низ лево право на шаге 2
    
    // Если координата на той же оси, но на шаге 1 - противник
    private void Test()
    {
        // Если на координате не null выходим
        if(Arrays.CheckIsOtherFigure()) return;
        
        // Координаты курсора
        var cursorPos = Utils.GetRoundMousePosition();

        // Массив с четыремя элементами на расстоянии 2 шага
        var arrayOfFour = GetHorizontalAndVerticalElementsTwoStep();

        foreach (var t in arrayOfFour)
        {
            if (Equals(cursorPos, t))
            {
                Debug.Log("Курсор в одной из четырех точек на расстоянии 2 клеток");
            }
        }


    }


    
    
    

    
    

    // Проверить есть ли вокруг противники
    private void GetEnemyNeighbour()
    {
        var a = GetHorizontalAndVerticalElementsOneStep();

        foreach (var t in a)
        {
            if (CheckIsEnemyFigure(t)) Debug.Log($"Тут противник: {t}");
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
    


    // Сравнивает две координаты, отдает 
    // void

    // Первая логика, ходит на одну клетку вокруг
    private bool CheckIsOneStepAround()
    {
        var a = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), a);
    }
}