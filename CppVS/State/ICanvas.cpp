#include "pch.h"
#include "ICanvas.h"

bool operator==(const Point& a, const Point& b)
{
    return a.x == b.x && a.y == b.y;
}