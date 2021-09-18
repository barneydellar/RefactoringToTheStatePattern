#pragma once
#include "ICanvas.h"

class MockCanvas : public ICanvas
{
public:
    MAKE_MOCK3(DrawLine, void(Point, Point, Colour), override);
    MAKE_MOCK2(DrawPoint, void(Point, Colour), override);
};
