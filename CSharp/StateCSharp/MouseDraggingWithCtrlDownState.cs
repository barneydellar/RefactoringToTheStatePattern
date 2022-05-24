namespace StateCSharp;

internal class MouseDraggingWithCtrlDownState : IState
{
    public IState CtrlKeyUp()
    {
        return new MouseDraggingState(); 
    }
    
    public IState MouseUp(Widget widget)
    {
        return new MouseUpWithCtrlDownState(); 
    }
    
    public IState MouseMove(Point point, Widget widget)
    {
        widget.DrawLine(widget.StartPoint, point, Colour.Green);    
        return this;
    }
}