namespace StateCSharp;

public class MockCanvas : ICanvas
{
    public void DrawLine(Point p1, Point p2, Colour colour)
    {
        throw new System.NotImplementedException();
    }

    public void DrawPoint(Point p1, Colour colour)
    {
        throw new System.NotImplementedException();
    }
}