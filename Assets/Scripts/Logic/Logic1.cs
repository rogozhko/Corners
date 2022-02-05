// using System;
// using UnityEngine;
//
// public class Logic1 : ILogic
// {
//     // Логика работы игры когда ходим только на одну клетку
//     
//     
//     Manager manager = Manager.Instance;
//     
//     public (bool, bool) CheckLogic()
//     {
//         // Debug.Log("Logic one");
//         // Debug.Log($"Mouse Position: {Utils.GetRoundMousePosition()}");
//
//         return (CheckIsOneCellAround(), false);
//     }
//
//     public bool CheckIsOneCellAround()
//     {
//         var coordinatesAroundFigure = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
//         // Arrays.ShowMatrix(coordinatesAroundFigure);
//         
//         if(Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), coordinatesAroundFigure))
//         {
//             // Debug.Log("Принадлежит");
//             return true;
//         }
//
//         // Debug.Log("Не принадлежит");
//         return false;
//     }
// }