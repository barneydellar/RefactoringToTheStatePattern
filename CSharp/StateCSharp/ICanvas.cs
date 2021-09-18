namespace StateCSharp
{
    public interface ICanvas
    {
        public void DrawLine(Point p1, Point p2, Colour c);
        public void DrawPoint(Point p1, Colour c);
    };
}