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

        w.mouseMove(start);
        w.mouseDown();
        w.mouseMove(end);

        verify(c, times(1)).drawLine(start, end, Colour.Red);
    }

    @Test
    public void AWidgetCanDrawAGreenLine()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var start = new Point(5, 0);
        var end = new Point(0, 5);

        w.mouseMove(start);
        w.ctrlKeyDown();
        w.mouseDown();
        w.mouseMove(end);

        verify(c, times(1)).drawLine(start, end, Colour.Green);
    }

    @Test
    public void PressingControlAfterStartingALineDoesntMakeItGreen()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var start = new Point(5, 0);
        var end = new Point(0, 5);

        w.mouseMove(start);
        w.mouseDown();
        w.ctrlKeyDown();
        w.mouseMove(end);

        verify(c, times(1)).drawLine(start, end, Colour.Red);
    }

    @Test
    public void ClickingDrawsAPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.mouseMove(p);
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p, Colour.Red);
    }

    @Test
    public void ClickingWithControlDrawsAGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.ctrlKeyDown();
        w.mouseMove(p);
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p, Colour.Green);
    }

    @Test
    public void ClickingWithControlAfterMovingDrawsAGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.mouseMove(p);
        w.ctrlKeyDown();
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p, Colour.Green);
    }

    @Test
    public void ClickingThenControlDrawsARedPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p = new Point(5, 5);

        w.mouseMove(p);
        w.mouseDown();
        w.ctrlKeyDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p, Colour.Red);
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

        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);
        w.mouseMove(p3);
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Red);
        verify(c, times(1)).drawLine(p2, p3, Colour.Red);
        verify(c, times(1)).drawLine(p3, p4, Colour.Red);
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

        w.ctrlKeyDown();
        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);
        w.mouseMove(p3);
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Green);
        verify(c, times(1)).drawLine(p2, p3, Colour.Green);
        verify(c, times(1)).drawLine(p3, p4, Colour.Green);
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

        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);

        w.mouseUp();

        w.mouseMove(p3);
        w.mouseDown();
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Red);
        verify(c, times(1)).drawLine(p3, p4, Colour.Red);
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

        w.ctrlKeyDown();
        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);

        w.mouseUp();

        w.mouseMove(p3);
        w.mouseDown();
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Green);
        verify(c, times(1)).drawLine(p3, p4, Colour.Green);
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

        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);

        w.mouseUp();
        w.ctrlKeyDown();

        w.mouseMove(p3);
        w.mouseDown();
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Red);
        verify(c, times(1)).drawLine(p3, p4, Colour.Green);
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

        w.ctrlKeyDown();
        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);

        w.mouseUp();
        w.ctrlKeyUp();

        w.mouseMove(p3);
        w.mouseDown();
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Green);
        verify(c, times(1)).drawLine(p3, p4, Colour.Red);
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

        w.ctrlKeyDown();
        w.mouseMove(p1);
        w.mouseDown();
        w.mouseMove(p2);

        w.ctrlKeyUp();
        w.mouseUp();

        w.mouseMove(p3);
        w.mouseDown();
        w.mouseMove(p4);

        verify(c, times(1)).drawLine(p1, p2, Colour.Green);
        verify(c, times(1)).drawLine(p3, p4, Colour.Red);
    }

    @Test
    public void ClickingTwiceDrawsTwoPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.mouseMove(p1);
        w.mouseDown();
        w.mouseUp();

        w.mouseMove(p2);
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p1, Colour.Red);
        verify(c, times(1)).drawPoint(p2, Colour.Red);
    }

    @Test
    public void ClickingTwiceWithControlDrawsTwoGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.mouseMove(p1);
        w.ctrlKeyDown();
        w.mouseDown();
        w.mouseUp();

        w.mouseMove(p2);
        w.ctrlKeyDown();
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p1, Colour.Green);
        verify(c, times(1)).drawPoint(p2, Colour.Green);
    }

    @Test
    public void ICanCreateOneRedAndOneGreenPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.mouseMove(p1);
        w.mouseDown();
        w.mouseUp();

        w.mouseMove(p2);
        w.ctrlKeyDown();
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p1, Colour.Red);
        verify(c, times(1)).drawPoint(p2, Colour.Green);
    }

    @Test
    public void ICanCreateOneGreenAndOneRedPoint()
    {
        var c = mock(ICanvas.class);
        var w = new Widget(c);

        var p1 = new Point(5, 5);
        var p2 = new Point(10, 20);

        w.mouseMove(p1);
        w.ctrlKeyDown();
        w.mouseDown();
        w.mouseUp();

        w.mouseMove(p2);
        w.ctrlKeyUp();
        w.mouseDown();
        w.mouseUp();

        verify(c, times(1)).drawPoint(p1, Colour.Green);
        verify(c, times(1)).drawPoint(p2, Colour.Red);
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
        w.mouseMove(p1);
        w.mouseDown();
        w.mouseUp();

        w.ctrlKeyDown();

        // Drag
        w.mouseDown();
        w.mouseMove(p2);
        w.mouseMove(p3);
        w.mouseUp();

        // Click
        w.mouseMove(p4);
        w.mouseDown();
        w.mouseUp();

        w.ctrlKeyUp();
        w.ctrlKeyUp();

        // Drag
        w.mouseDown();
        w.mouseMove(p5);
        w.mouseUp();

        verify(c, times(1)).drawPoint(p1, Colour.Red);
        verify(c, times(1)).drawLine(p1, p2, Colour.Green);
        verify(c, times(1)).drawLine(p2, p3, Colour.Green);
        verify(c, times(1)).drawPoint(p4, Colour.Green);
        verify(c, times(1)).drawLine(p4, p5, Colour.Red);
    }

}