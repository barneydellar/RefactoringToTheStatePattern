namespace StateCSharp;

internal class MouseDownState : IState
{
    public IState MouseUp(Widget widget)
    {
        widget.DrawPoint(widget.StartPoint, Colour.Red);
        return new MouseUpState();
    }    
    
    public IState MouseMove(Point point, Widget widget)
    {
        widget.DrawLine(widget.StartPoint, point, Colour.Red);
        return new MouseDraggingState();
    }
}