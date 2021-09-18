namespace StateCSharp
{
    public class Widget
    {
        private readonly ICanvas canvas_;
        private MouseState mouse_state_ = MouseState.MouseUp;

        private Point start_p_;

        public Widget(ICanvas canvas)
        {
            canvas_ = canvas;
        }

        public void MouseMove(Point p)
        {
            if (mouse_state_ == MouseState.MouseUp)
            {
                start_p_ = p;
            }

            if (mouse_state_ == MouseState.MouseUpWithCtrlDown)
            {
                start_p_ = p;
            }
            else if (mouse_state_ == MouseState.MouseDown)
            {
                mouse_state_ = MouseState.MouseDragging;
            }

            if (mouse_state_ == MouseState.MouseDownWithCtrlDown)
            {
                mouse_state_ = MouseState.MouseDraggingWithCtrlDown;
            }

            if (mouse_state_ == MouseState.MouseDragging)
            {
                canvas_.DrawLine(start_p_, p, Colour.Red);
                start_p_ = p;
            }

            if (mouse_state_ == MouseState.MouseDraggingWithCtrlDown)
            {
                canvas_.DrawLine(start_p_, p, Colour.Green);
                start_p_ = p;
            }
        }

        public void MouseDown()
        {
            if (mouse_state_ == MouseState.MouseUp)
            {
                mouse_state_ = MouseState.MouseDown;
            }

            if (mouse_state_ == MouseState.MouseUpWithCtrlDown)
            {
                mouse_state_ = MouseState.MouseDownWithCtrlDown;
            }
        }

        public void CtrlKeyDown()
        {
            if (mouse_state_ == MouseState.MouseUp)
            {
                mouse_state_ = MouseState.MouseUpWithCtrlDown;
            }
        }

        public void MouseUp()
        {
            if (mouse_state_ == MouseState.MouseDownWithCtrlDown)
            {
                canvas_.DrawPoint(start_p_, Colour.Green);
            }
            else if (mouse_state_ == MouseState.MouseDown)
            {
                canvas_.DrawPoint(start_p_, Colour.Red);
            }

            if (mouse_state_ == MouseState.MouseDown || mouse_state_ == MouseState.MouseDragging)
            {
                mouse_state_ = MouseState.MouseUp;
            }

            if (mouse_state_ == MouseState.MouseDownWithCtrlDown ||
                mouse_state_ == MouseState.MouseDraggingWithCtrlDown)
            {
                mouse_state_ = MouseState.MouseUpWithCtrlDown;
            }
        }

        public void CtrlKeyUp()
        {
            {
                if (mouse_state_ == MouseState.MouseUpWithCtrlDown)
                {
                    mouse_state_ = MouseState.MouseUp;
                }
                else if (mouse_state_ == MouseState.MouseDraggingWithCtrlDown)
                {
                    mouse_state_ = MouseState.MouseDragging;
                }

                if (mouse_state_ == MouseState.MouseDownWithCtrlDown)
                {
                    mouse_state_ = MouseState.MouseDown;
                }
            }
        }
    }
}