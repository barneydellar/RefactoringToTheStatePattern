namespace StateCSharp;

public class Widget
{
    private IState _state;
    private readonly ICanvas _canvas;
    public Point StartPoint { get; set; }

    public Widget(ICanvas canvas)
    {
        _canvas = canvas;
        _state = new MouseUpState();
    }

    public void MouseMove(Point p) => _state = _state.MouseMove(p, this);
    public void MouseDown() => _state = _state.MouseDown();
    public void CtrlKeyDown() => _state = _state.CtrlKeyDown();
    public void MouseUp() => _state = _state.MouseUp(this);
    public void CtrlKeyUp() => _state = _state.CtrlKeyUp();
        
    public void DrawPoint(Point point, Colour color)
    {
        _canvas.DrawPoint(point, color);
    }

    public void DrawLine(Point startPoint, Point endPoint, Colour color)
    {
        _canvas.DrawLine(startPoint, endPoint, color);
        StartPoint = endPoint;
    }
}