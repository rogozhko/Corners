using System;
using UnityEngine;

public class Logic3 : ILogic
{
    // Логика работы игры когда ходим только на одну клетку
    
    
    Manager manager = Manager.Instance;
    
    public bool CheckLogic()
    {
        Debug.Log("Вертикально-горизонтальная");
        // Debug.Log($"Mouse Position: {Utils.GetRoundMousePosition()}");

        var coordinatesAroundFigure = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        // Arrays.ShowMatrix(coordinatesAroundFigure);
        
        if(Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), coordinatesAroundFigure))
        {
            // Debug.Log("Принадлежит");
            return true;
        }

        // Debug.Log("Не принадлежит");
        return false;
    }
}