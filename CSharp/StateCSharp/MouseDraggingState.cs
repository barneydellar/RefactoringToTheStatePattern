namespace StateCSharp;

internal class MouseDraggingState : IState
{
    public IState MouseMove(Point point, Widget widget)
    {
        widget.DrawLine(widget.StartPoint, point, Colour.Red);
        return this;
    }
    
    public IState MouseUp(Widget widget)
    {
        return new MouseUpState(); 
    }
}