using Moq;
using NUnit.Framework;

namespace StateCSharp
{
    public class WidgetTests
    {

        [Test]
        public void AWidgetCanBeCreated()
        {
            MockCanvas c = new MockCanvas();
            Widget w = new Widget(c);
        }

        [Test]
        public void AWidgetCanDrawARedLine()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point start = new Point(10, 10);
            Point end = new Point(20, 20);

            w.MouseMove(start);
            w.MouseDown();
            w.MouseMove(end);

            c.Verify(mock => mock.DrawLine(start, end, Colour.Red), Times.Once());
        }

        [Test]
        public void AWidgetCanDrawAGreenLine()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point start = new Point(5, 0);
            Point end = new Point(0, 5);

            w.MouseMove(start);
            w.CtrlKeyDown();
            w.MouseDown();
            w.MouseMove(end);

            c.Verify(mock => mock.DrawLine(start, end, Colour.Green), Times.Once());
        }

        [Test]
        public void PressingControlAfterStartingALineDoesntMakeItGreen()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point start = new Point(5, 0);
            Point end = new Point(0, 5);

            w.MouseMove(start);
            w.MouseDown();
            w.CtrlKeyDown();
            w.MouseMove(end);

            c.Verify(mock => mock.DrawLine(start, end, Colour.Red), Times.Once());
        }

        [Test]
        public void ClickingDrawsAPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p = new Point(5, 5);

            w.MouseMove(p);
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p, Colour.Red), Times.Once());
        }

        [Test]
        public void ClickingWithControlDrawsAGreenPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p = new Point(5, 5);

            w.CtrlKeyDown();
            w.MouseMove(p);
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p, Colour.Green), Times.Once());
        }

        [Test]
        public void ClickingWithControlAfterMovingDrawsAGreenPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p = new Point(5, 5);

            w.MouseMove(p);
            w.CtrlKeyDown();
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p, Colour.Green), Times.Once());
        }

        [Test]
        public void ClickingThenControlDrawsARedPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p = new Point(5, 5);

            w.MouseMove(p);
            w.MouseDown();
            w.CtrlKeyDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p, Colour.Red), Times.Once());
        }

        [Test]
        public void ICanDragToMakeMultipleLines()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);
            w.MouseMove(p3);
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawLine(p2, p3, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Red), Times.Once());
        }

        [Test]
        public void ICanPressControlAndDragToMakeMultipleGreenLines()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.CtrlKeyDown();
            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);
            w.MouseMove(p3);
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p2, p3, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Green), Times.Once());
        }

        [Test]
        public void ICanDragTwiceToMakeTwoLines()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);

            w.MouseUp();

            w.MouseMove(p3);
            w.MouseDown();
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Red), Times.Once());
        }

        [Test]
        public void ICanDragTwiceWithControlDownToMakeTwoGreenLines()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.CtrlKeyDown();
            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);

            w.MouseUp();

            w.MouseMove(p3);
            w.MouseDown();
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Green), Times.Once());
        }

        [Test]
        public void ICanDragToMakeOneRedAndOneGreenLine()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);

            w.MouseUp();
            w.CtrlKeyDown();

            w.MouseMove(p3);
            w.MouseDown();
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Green), Times.Once());
        }

        [Test]
        public void ICanDragToMakeOneGreenAndOneRedLine()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.CtrlKeyDown();
            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);

            w.MouseUp();
            w.CtrlKeyUp();

            w.MouseMove(p3);
            w.MouseDown();
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Red), Times.Once());
        }

        [Test]
        public void ICanDragToMakeOneGreenAndOneRedLineReleasingTheControlKeyEarly()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(5, 5);

            w.CtrlKeyDown();
            w.MouseMove(p1);
            w.MouseDown();
            w.MouseMove(p2);

            w.CtrlKeyUp();
            w.MouseUp();

            w.MouseMove(p3);
            w.MouseDown();
            w.MouseMove(p4);

            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p3, p4, Colour.Red), Times.Once());
        }

        [Test]
        public void ClickingTwiceDrawsTwoPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(5, 5);
            Point p2 = new Point(10, 20);

            w.MouseMove(p1);
            w.MouseDown();
            w.MouseUp();

            w.MouseMove(p2);
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p1, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawPoint(p2, Colour.Red), Times.Once());
        }

        [Test]
        public void ClickingTwiceWithControlDrawsTwoGreenPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(5, 5);
            Point p2 = new Point(10, 20);

            w.MouseMove(p1);
            w.CtrlKeyDown();
            w.MouseDown();
            w.MouseUp();

            w.MouseMove(p2);
            w.CtrlKeyDown();
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p1, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawPoint(p2, Colour.Green), Times.Once());
        }

        [Test]
        public void ICanCreateOneRedAndOneGreenPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(5, 5);
            Point p2 = new Point(10, 20);

            w.MouseMove(p1);
            w.MouseDown();
            w.MouseUp();

            w.MouseMove(p2);
            w.CtrlKeyDown();
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p1, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawPoint(p2, Colour.Green), Times.Once());
        }

        [Test]
        public void ICanCreateOneGreenAndOneRedPoint()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(5, 5);
            Point p2 = new Point(10, 20);

            w.MouseMove(p1);
            w.CtrlKeyDown();
            w.MouseDown();
            w.MouseUp();

            w.MouseMove(p2);
            w.CtrlKeyUp();
            w.MouseDown();
            w.MouseUp();

            c.Verify(mock => mock.DrawPoint(p1, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawPoint(p2, Colour.Red), Times.Once());
        }

        [Test]
        public void ICanCreateLotsOfPointsAndLines()
        {
            var c = new Mock<ICanvas>();
            Widget w = new Widget(c.Object);

            Point p1 = new Point(5, 5);
            Point p2 = new Point(10, 20);
            Point p3 = new Point(29, 12);
            Point p4 = new Point(-5, 8);
            Point p5 = new Point(3, 7);

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

            c.Verify(mock => mock.DrawPoint(p1, Colour.Red), Times.Once());
            c.Verify(mock => mock.DrawLine(p1, p2, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p2, p3, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawPoint(p4, Colour.Green), Times.Once());
            c.Verify(mock => mock.DrawLine(p4, p5, Colour.Red), Times.Once());
        }
    }
}