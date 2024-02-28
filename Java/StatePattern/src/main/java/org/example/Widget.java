package org.example;

public class Widget {

    public Widget(ICanvas canvas) {
        this.canvas = canvas;
    }

    private final ICanvas canvas;
    private Mouse mouse = Mouse.Up;
    private Point startP;

    public void MouseMove(Point point)
    {
        if (mouse == Mouse.Up)
        {
            startP = point;
        }

        if (mouse == Mouse.UpWithCtrlDown)
        {
            startP = point;
        }
        else if (mouse == Mouse.Down)
        {
            mouse = Mouse.Dragging;
        }

        if (mouse == Mouse.DownWithCtrlDown)
        {
            mouse = Mouse.DraggingWithCtrlDown;
        }

        if (mouse == Mouse.Dragging)
        {
            canvas.DrawLine(startP, point, Colour.Red);
            startP = point;
        }

        if (mouse == Mouse.DraggingWithCtrlDown)
        {
            canvas.DrawLine(startP, point, Colour.Green);
            startP = point;
        }
    }

    public void MouseDown()
    {
        if (mouse == Mouse.Up)
        {
            mouse = Mouse.Down;
        }

        if (mouse == Mouse.UpWithCtrlDown)
        {
            mouse = Mouse.DownWithCtrlDown;
        }
    }

    public void CtrlKeyDown()
    {
        if (mouse == Mouse.Up)
        {
            mouse = Mouse.UpWithCtrlDown;
        }
    }

    public void MouseUp()
    {
        switch (mouse)
        {
            case DownWithCtrlDown:
                canvas.DrawPoint(startP, Colour.Green);
                break;
            case Down:
                canvas.DrawPoint(startP, Colour.Red);
                break;
        }

        if (mouse == Mouse.Down || mouse == Mouse.Dragging)
        {
            mouse = Mouse.Up;
        }

        if (mouse == Mouse.DownWithCtrlDown || mouse == Mouse.DraggingWithCtrlDown)
        {
            mouse = Mouse.UpWithCtrlDown;
        }
    }

    public void CtrlKeyUp()
    {
        {
            switch (mouse)
            {
                case UpWithCtrlDown:
                    mouse = Mouse.Up;
                    break;
                case DraggingWithCtrlDown:
                    mouse = Mouse.Dragging;
                    break;
            }

            if (mouse == Mouse.DownWithCtrlDown)
            {
                mouse = Mouse.Down;
            }
        }
    }
}
