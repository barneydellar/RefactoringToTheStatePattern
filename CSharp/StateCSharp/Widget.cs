namespace StateCSharp
{
    public class Widget
    {
        private readonly ICanvas _canvas;
        private MouseState _mouseState = MouseState.MouseUp;
        private Point _startP;

        public Widget(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void MouseMove(Point point)
        {
            if (_mouseState == MouseState.MouseUp)
            {
                _startP = point;
            }

            if (_mouseState == MouseState.MouseUpWithCtrlDown)
            {
                _startP = point;
            }
            else if (_mouseState == MouseState.MouseDown)
            {
                _mouseState = MouseState.MouseDragging;
            }

            if (_mouseState == MouseState.MouseDownWithCtrlDown)
            {
                _mouseState = MouseState.MouseDraggingWithCtrlDown;
            }

            if (_mouseState == MouseState.MouseDragging)
            {
                _canvas.DrawLine(_startP, point, Colour.Red);
                _startP = point;
            }

            if (_mouseState == MouseState.MouseDraggingWithCtrlDown)
            {
                _canvas.DrawLine(_startP, point, Colour.Green);
                _startP = point;
            }
        }

        public void MouseDown()
        {
            if (_mouseState == MouseState.MouseUp)
            {
                _mouseState = MouseState.MouseDown;
            }

            if (_mouseState == MouseState.MouseUpWithCtrlDown)
            {
                _mouseState = MouseState.MouseDownWithCtrlDown;
            }
        }

        public void CtrlKeyDown()
        {
            if (_mouseState == MouseState.MouseUp)
            {
                _mouseState = MouseState.MouseUpWithCtrlDown;
            }
        }

        public void MouseUp()
        {
            if (_mouseState == MouseState.MouseDownWithCtrlDown)
            {
                _canvas.DrawPoint(_startP, Colour.Green);
            }
            else if (_mouseState == MouseState.MouseDown)
            {
                _canvas.DrawPoint(_startP, Colour.Red);
            }

            if (_mouseState == MouseState.MouseDown || _mouseState == MouseState.MouseDragging)
            {
                _mouseState = MouseState.MouseUp;
            }

            if (_mouseState == MouseState.MouseDownWithCtrlDown ||
                _mouseState == MouseState.MouseDraggingWithCtrlDown)
            {
                _mouseState = MouseState.MouseUpWithCtrlDown;
            }
        }

        public void CtrlKeyUp()
        {
            {
                if (_mouseState == MouseState.MouseUpWithCtrlDown)
                {
                    _mouseState = MouseState.MouseUp;
                }
                else if (_mouseState == MouseState.MouseDraggingWithCtrlDown)
                {
                    _mouseState = MouseState.MouseDragging;
                }

                if (_mouseState == MouseState.MouseDownWithCtrlDown)
                {
                    _mouseState = MouseState.MouseDown;
                }
            }
        }
    }
}