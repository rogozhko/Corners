using System;
using UnityEngine;

public class Logic2 : ILogic
{
    // Логика работы игры когда ходим только на одну клетку
    
    
    Manager manager = Manager.Instance;
    
    public bool CheckLogic()
    {
        // Debug.Log("Диагональная логика");
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