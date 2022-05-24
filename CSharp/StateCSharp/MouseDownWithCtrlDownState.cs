namespace StateCSharp;

internal class MouseDownWithCtrlDownState : IState
{
    public IState MouseUp(Widget widget)
    {
        widget.DrawPoint(widget.StartPoint, Colour.Green);
        return new MouseUpWithCtrlDownState();
    }
    
    public IState CtrlKeyUp()
    {
        return new MouseDownState(); 
    }

    public IState MouseMove(Point point, Widget widget)
    {
        widget.DrawLine(widget.StartPoint, point, Colour.Green);
        return new MouseDraggingWithCtrlDownState(); 
    }
}