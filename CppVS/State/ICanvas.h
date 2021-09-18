#pragma once

struct Point
{
    int x;
    int y;
};
bool operator==(const Point& a, const Point& b);

enum Colour
{
    Red,
    Green
};

class ICanvas
{
public:
    virtual ~ICanvas() = default;
    virtual void DrawLine(Point, Point, Colour) = 0;
    virtual void DrawPoint(Point, Colour) = 0;
};

