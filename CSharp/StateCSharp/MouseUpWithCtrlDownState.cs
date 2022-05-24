namespace StateCSharp;

internal class MouseUpWithCtrlDownState : IState
{
    public IState MouseDown()
    {
        return new MouseDownWithCtrlDownState(); 
    }
    
    public IState CtrlKeyUp()
    {
        return new MouseUpState(); 
    }
    
    public IState MouseMove(Point point, Widget widget)
    {
        widget.StartPoint = point;
        return this;
    }
}