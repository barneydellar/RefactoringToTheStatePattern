namespace StateCSharp
{
    public class Widget
    {
        private readonly ICanvas _canvas;
        private Mouse _mouse = Mouse.MouseUp;
        private Point _startP;

        public Widget(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void MouseMove(Point point)
        {
            if (_mouse == Mouse.MouseUp)
            {
                _startP = point;
            }

            if (_mouse == Mouse.MouseUpWithCtrlDown)
            {
                _startP = point;
            }
            else if (_mouse == Mouse.MouseDown)
            {
                _mouse = Mouse.MouseDragging;
            }

            if (_mouse == Mouse.MouseDownWithCtrlDown)
            {
                _mouse = Mouse.MouseDraggingWithCtrlDown;
            }

            if (_mouse == Mouse.MouseDragging)
            {
                _canvas.DrawLine(_startP, point, Colour.Red);
                _startP = point;
            }

            if (_mouse == Mouse.MouseDraggingWithCtrlDown)
            {
                _canvas.DrawLine(_startP, point, Colour.Green);
                _startP = point;
            }
        }

        public void MouseDown()
        {
            if (_mouse == Mouse.MouseUp)
            {
                _mouse = Mouse.MouseDown;
            }

            if (_mouse == Mouse.MouseUpWithCtrlDown)
            {
                _mouse = Mouse.MouseDownWithCtrlDown;
            }
        }

        public void CtrlKeyDown()
        {
            if (_mouse == Mouse.MouseUp)
            {
                _mouse = Mouse.MouseUpWithCtrlDown;
            }
        }

        public void MouseUp()
        {
            if (_mouse == Mouse.MouseDownWithCtrlDown)
            {
                _canvas.DrawPoint(_startP, Colour.Green);
            }
            else if (_mouse == Mouse.MouseDown)
            {
                _canvas.DrawPoint(_startP, Colour.Red);
            }

            if (_mouse == Mouse.MouseDown || _mouse == Mouse.MouseDragging)
            {
                _mouse = Mouse.MouseUp;
            }

            if (_mouse == Mouse.MouseDownWithCtrlDown ||
                _mouse == Mouse.MouseDraggingWithCtrlDown)
            {
                _mouse = Mouse.MouseUpWithCtrlDown;
            }
        }

        public void CtrlKeyUp()
        {
            {
                if (_mouse == Mouse.MouseUpWithCtrlDown)
                {
                    _mouse = Mouse.MouseUp;
                }
                else if (_mouse == Mouse.MouseDraggingWithCtrlDown)
                {
                    _mouse = Mouse.MouseDragging;
                }

                if (_mouse == Mouse.MouseDownWithCtrlDown)
                {
                    _mouse = Mouse.MouseDown;
                }
            }
        }
    }
}