package org.example;

public class Widget {

    public Widget(ICanvas canvas) {
        this.canvas = canvas;
    }

    private final ICanvas canvas;
    private Mouse mouse = Mouse.Up;
    private Point startP;

    public void mouseMove(Point point)
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
            canvas.drawLine(startP, point, Colour.Red);
            startP = point;
        }

        if (mouse == Mouse.DraggingWithCtrlDown)
        {
            canvas.drawLine(startP, point, Colour.Green);
            startP = point;
        }
    }

    public void mouseDown()
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

    public void ctrlKeyDown()
    {
        if (mouse == Mouse.Up)
        {
            mouse = Mouse.UpWithCtrlDown;
        }
    }

    public void mouseUp()
    {
        switch (mouse)
        {
            case DownWithCtrlDown:
                canvas.drawPoint(startP, Colour.Green);
                break;
            case Down:
                canvas.drawPoint(startP, Colour.Red);
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

    public void ctrlKeyUp()
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
