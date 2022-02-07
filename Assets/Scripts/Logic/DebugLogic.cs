public class DebugLogic : Logic
{
    public override void Run()
    {
        Manager manager = Manager.Instance;
        
        
        if (!Arrays.CheckIsOtherFigure())
        {
            RemoveFromArray(manager.CurrentFigure);
            MoveFigure(manager.CurrentFigure);
        }
        else
        {
            BackToCurrentPosition(manager.CurrentFigure);
        }
    }
}