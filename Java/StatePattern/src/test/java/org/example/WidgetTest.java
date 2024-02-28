package org.example;
import org.junit.jupiter.api.Test;
import static org.mockito.Mockito.*;

class WidgetTest {

    @Test
    public void AWidgetCanBeCreated()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);
    }

    @Test
    public void AWidgetCanDrawARedLine()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var start = new Point(10, 10);
        var end = new Point(20, 20);

        w.MouseMove(start);
        w.MouseDown();
        w.MouseMove(end);

        verify(c, times(1)).DrawLine(start, end, Colour.Red);
    }

    @Test
    public void AWidgetCanDrawAGreenLine()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var start = new Point(5, 0);
        var end = new Point(0, 5);

        w.MouseMove(start);
        w.CtrlKeyDown();
        w.MouseDown();
        w.MouseMove(end);

        verify(c, times(1)).DrawLine(start, end, Colour.Green);
    }

    @Test
    public void PressingControlAfterStartingALineDoesntMakeItGreen()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var start = new Point(5, 0);
        var end = new Point(0, 5);

        w.MouseMove(start);
        w.MouseDown();
        w.CtrlKeyDown();
        w.MouseMove(end);

        verify(c, times(1)).DrawLine(start, end, Colour.Red);
    }

    @Test
    public void ClickingDrawsAPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.MouseMove(p);
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p, Colour.Red);
    }

    @Test
    public void ClickingWithControlDrawsAGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.CtrlKeyDown();
        w.MouseMove(p);
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p, Colour.Green);
    }

    @Test
    public void ClickingWithControlAfterMovingDrawsAGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.MouseMove(p);
        w.CtrlKeyDown();
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p, Colour.Green);
    }

    @Test
    public void ClickingThenControlDrawsARedPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.MouseMove(p);
        w.MouseDown();
        w.CtrlKeyDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p, Colour.Red);
    }

    @Test
    public void CanDragToMakeMultipleLines()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);
        w.MouseMove(p3);
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Red);
        verify(c, times(1)).DrawLine(p2, p3, Colour.Red);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Red);
    }

    @Test
    public void CanPressControlAndDragToMakeMultipleGreenLines()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.CtrlKeyDown();
        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);
        w.MouseMove(p3);
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Green);
        verify(c, times(1)).DrawLine(p2, p3, Colour.Green);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Green);
    }

    @Test
    public void CanDragTwiceToMakeTwoLines()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);

        w.MouseUp();

        w.MouseMove(p3);
        w.MouseDown();
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Red);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Red);
    }

    @Test
    public void CanDragTwiceWithControlDownToMakeTwoGreenLines()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.CtrlKeyDown();
        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);

        w.MouseUp();

        w.MouseMove(p3);
        w.MouseDown();
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Green);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Green);
    }

    @Test
    public void ICanDragToMakeOneRedAndOneGreenLine()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);

        w.MouseUp();
        w.CtrlKeyDown();

        w.MouseMove(p3);
        w.MouseDown();
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Red);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Green);
    }

    @Test
    public void ICanDragToMakeOneGreenAndOneRedLine()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.CtrlKeyDown();
        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);

        w.MouseUp();
        w.CtrlKeyUp();

        w.MouseMove(p3);
        w.MouseDown();
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Green);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Red);
    }

    @Test
    public void ICanDragToMakeOneGreenAndOneRedLineReleasingTheControlKeyEarly()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(0, 0);
        var p2 = new Point(0, 1);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);

        w.CtrlKeyDown();
        w.MouseMove(p1);
        w.MouseDown();
        w.MouseMove(p2);

        w.CtrlKeyUp();
        w.MouseUp();

        w.MouseMove(p3);
        w.MouseDown();
        w.MouseMove(p4);

        verify(c, times(1)).DrawLine(p1, p2, Colour.Green);
        verify(c, times(1)).DrawLine(p3, p4, Colour.Red);
    }

    @Test
    public void ClickingTwiceDrawsTwoPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.MouseMove(p1);
        w.MouseDown();
        w.MouseUp();

        w.MouseMove(p2);
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p1, Colour.Red);
        verify(c, times(1)).DrawPoint(p2, Colour.Red);
    }

    @Test
    public void ClickingTwiceWithControlDrawsTwoGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.MouseMove(p1);
        w.CtrlKeyDown();
        w.MouseDown();
        w.MouseUp();

        w.MouseMove(p2);
        w.CtrlKeyDown();
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p1, Colour.Green);
        verify(c, times(1)).DrawPoint(p2, Colour.Green);
    }

    @Test
    public void ICanCreateOneRedAndOneGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.MouseMove(p1);
        w.MouseDown();
        w.MouseUp();

        w.MouseMove(p2);
        w.CtrlKeyDown();
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p1, Colour.Red);
        verify(c, times(1)).DrawPoint(p2, Colour.Green);
    }

    @Test
    public void ICanCreateOneGreenAndOneRedPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.MouseMove(p1);
        w.CtrlKeyDown();
        w.MouseDown();
        w.MouseUp();

        w.MouseMove(p2);
        w.CtrlKeyUp();
        w.MouseDown();
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p1, Colour.Green);
        verify(c, times(1)).DrawPoint(p2, Colour.Red);
    }

    @Test
    public void CanCreateLotsOfPointsAndLines()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);
        var p3 = new Point(29, 12);
        var p4 = new Point(-5, 8);
        var p5 = new Point(3, 7);

        // Click
        w.MouseMove(p1);
        w.MouseDown();
        w.MouseUp();

        w.CtrlKeyDown();

        // Drag
        w.MouseDown();
        w.MouseMove(p2);
        w.MouseMove(p3);
        w.MouseUp();

        // Click
        w.MouseMove(p4);
        w.MouseDown();
        w.MouseUp();

        w.CtrlKeyUp();
        w.CtrlKeyUp();

        // Drag
        w.MouseDown();
        w.MouseMove(p5);
        w.MouseUp();

        verify(c, times(1)).DrawPoint(p1, Colour.Red);
        verify(c, times(1)).DrawLine(p1, p2, Colour.Green);
        verify(c, times(1)).DrawLine(p2, p3, Colour.Green);
        verify(c, times(1)).DrawPoint(p4, Colour.Green);
        verify(c, times(1)).DrawLine(p4, p5, Colour.Red);
    }

}