namespace StateCSharp;

public class Widget
{
    private readonly ICanvas _canvas;
    private Mouse _mouse = Mouse.Up;
    private Point _startP;

    public Widget(ICanvas canvas)
    {
        _canvas = canvas;
    }

    public void MouseMove(Point point)
    {
        if (_mouse == Mouse.Up)
        {
            _startP = point;
        }

        if (_mouse == Mouse.UpWithCtrlDown)
        {
            _startP = point;
        }
        else if (_mouse == Mouse.Down)
        {
            _mouse = Mouse.Dragging;
        }

        if (_mouse == Mouse.DownWithCtrlDown)
        {
            _mouse = Mouse.DraggingWithCtrlDown;
        }

        if (_mouse == Mouse.Dragging)
        {
            _canvas.DrawLine(_startP, point, Colour.Red);
            _startP = point;
        }

        if (_mouse == Mouse.DraggingWithCtrlDown)
        {
            _canvas.DrawLine(_startP, point, Colour.Green);
            _startP = point;
        }
    }

    public void MouseDown()
    {
        if (_mouse == Mouse.Up)
        {
            _mouse = Mouse.Down;
        }

        if (_mouse == Mouse.UpWithCtrlDown)
        {
            _mouse = Mouse.DownWithCtrlDown;
        }
    }

    public void CtrlKeyDown()
    {
        if (_mouse == Mouse.Up)
        {
            _mouse = Mouse.UpWithCtrlDown;
        }
    }

    public void MouseUp()
    {
        if (_mouse == Mouse.DownWithCtrlDown)
        {
            _canvas.DrawPoint(_startP, Colour.Green);
        }
        else if (_mouse == Mouse.Down)
        {
            _canvas.DrawPoint(_startP, Colour.Red);
        }

        if (_mouse == Mouse.Down || _mouse == Mouse.Dragging)
        {
            _mouse = Mouse.Up;
        }

        if (_mouse == Mouse.DownWithCtrlDown ||
            _mouse == Mouse.DraggingWithCtrlDown)
        {
            _mouse = Mouse.UpWithCtrlDown;
        }
    }

    public void CtrlKeyUp()
    {
        {
            if (_mouse == Mouse.UpWithCtrlDown)
            {
                _mouse = Mouse.Up;
            }
            else if (_mouse == Mouse.DraggingWithCtrlDown)
            {
                _mouse = Mouse.Dragging;
            }

            if (_mouse == Mouse.DownWithCtrlDown)
            {
                _mouse = Mouse.Down;
            }
        }
    }
}