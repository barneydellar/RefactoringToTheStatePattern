namespace StateCSharp;

internal class MouseUpState : IState
{
    public IState MouseDown()
    {
        return new MouseDownState(); 
    }
    
    public IState CtrlKeyDown()
    {
        return new MouseUpWithCtrlDownState(); 
    }
    
    public IState MouseMove(Point point, Widget widget)
    {
        widget.StartPoint = point;
        return this;
    }
}