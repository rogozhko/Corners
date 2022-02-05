


using System;

public interface ILogic
{
    bool CheckIsOneCellAround();
    (bool, Tuple<int,int>) CheckIsNextOfEnemyFigure();
}