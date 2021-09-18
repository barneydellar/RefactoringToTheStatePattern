#include "pch.h"

#include "ICanvas.h"
#include "MockCanvas.h"
#include "Widget.h"

TEST_CASE("A Widget can be created")
{
    MockCanvas c;
    Widget{ c };
}

TEST_CASE("A Widget can draw a red line")
{
    MockCanvas c;
    Widget w{ c };

    Point start{ 10, 10 };
    Point end{ 20, 20 };

    REQUIRE_CALL(c, DrawLine(start, end, Colour::Red)).TIMES(1);

    w.MouseMove(start);
    w.MouseDown();
    w.MouseMove(end);
}

TEST_CASE("A Widget can draw a green line")
{
    MockCanvas c;
    Widget w{ c };

    Point start{ 5, 0 };
    Point end{ 0, 5 };

    REQUIRE_CALL(c, DrawLine(start, end, Colour::Green)).TIMES(1);

    w.MouseMove(start);
    w.CtrlKeyDown();
    w.MouseDown();
    w.MouseMove(end);
}

TEST_CASE("Pressing Control after starting a line doesn't make it green")
{
    MockCanvas c;
    Widget w{ c };

    Point start{ 5, 0 };
    Point end{ 0, 5 };

    REQUIRE_CALL(c, DrawLine(start, end, Colour::Red)).TIMES(1);

    w.MouseMove(start);
    w.MouseDown();
    w.CtrlKeyDown();
    w.MouseMove(end);
}

TEST_CASE("Clicking draws a point")
{
    MockCanvas c;
    Widget w{ c };

    Point p{ 5, 5 };

    REQUIRE_CALL(c, DrawPoint(p, Colour::Red)).TIMES(1);

    w.MouseMove(p);
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("Clicking with control draws a green point")
{
    MockCanvas c;
    Widget w{ c };

    Point p{ 5, 5 };

    REQUIRE_CALL(c, DrawPoint(p, Colour::Green)).TIMES(1);

    w.CtrlKeyDown();
    w.MouseMove(p);
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("Clicking with control after moving draws a green point")
{
    MockCanvas c;
    Widget w{ c };

    Point p{ 5, 5 };

    REQUIRE_CALL(c, DrawPoint(p, Colour::Green)).TIMES(1);

    w.MouseMove(p);
    w.CtrlKeyDown();
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("Clicking then control draws a RED point")
{
    MockCanvas c;
    Widget w{ c };

    Point p{ 5, 5 };

    REQUIRE_CALL(c, DrawPoint(p, Colour::Red)).TIMES(1);

    w.MouseMove(p);
    w.MouseDown();
    w.CtrlKeyDown();
    w.MouseUp();
}

TEST_CASE("I can drag to make multiple lines")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p2, p3, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Red)).TIMES(1);

    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);
    w.MouseMove(p3);
    w.MouseMove(p4);
}

TEST_CASE("I can press control and drag to make multiple green lines")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p2, p3, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Green)).TIMES(1);

    w.CtrlKeyDown();
    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);
    w.MouseMove(p3);
    w.MouseMove(p4);
}

TEST_CASE("I can drag twice to make two lines")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Red)).TIMES(1);

    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);

    w.MouseUp();

    w.MouseMove(p3);
    w.MouseDown();
    w.MouseMove(p4);
}

TEST_CASE("I can drag twice with control down to make two green lines")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Green)).TIMES(1);

    w.CtrlKeyDown();
    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);

    w.MouseUp();

    w.MouseMove(p3);
    w.MouseDown();
    w.MouseMove(p4);
}

TEST_CASE("I can drag to make one red and one green line")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Green)).TIMES(1);

    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);

    w.MouseUp();
    w.CtrlKeyDown();

    w.MouseMove(p3);
    w.MouseDown();
    w.MouseMove(p4);
}

TEST_CASE("I can drag to make one green and one red line")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Red)).TIMES(1);

    w.CtrlKeyDown();
    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);

    w.MouseUp();
    w.CtrlKeyUp();

    w.MouseMove(p3);
    w.MouseDown();
    w.MouseMove(p4);
}

TEST_CASE("I can drag to make one green and one red line, releasing the control key early")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 0, 0 };
    Point p2{ 0, 1 };
    Point p3{ 1, 1, };
    Point p4{ 5, 5 };

    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p3, p4, Colour::Red)).TIMES(1);

    w.CtrlKeyDown();
    w.MouseMove(p1);
    w.MouseDown();
    w.MouseMove(p2);

    w.CtrlKeyUp();
    w.MouseUp();

    w.MouseMove(p3);
    w.MouseDown();
    w.MouseMove(p4);
}

TEST_CASE("Clicking twice draws two point")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 5, 5 };
    Point p2{ 10, 20 };

    REQUIRE_CALL(c, DrawPoint(p1, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawPoint(p2, Colour::Red)).TIMES(1);

    w.MouseMove(p1);
    w.MouseDown();
    w.MouseUp();

    w.MouseMove(p2);
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("Clicking twice with control draws two green point")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 5, 5 };
    Point p2{ 10, 20 };

    REQUIRE_CALL(c, DrawPoint(p1, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawPoint(p2, Colour::Green)).TIMES(1);

    w.MouseMove(p1);
    w.CtrlKeyDown();
    w.MouseDown();
    w.MouseUp();

    w.MouseMove(p2);
    w.CtrlKeyDown();
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("I can create one red and one green point")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 5, 5 };
    Point p2{ 10, 20 };

    REQUIRE_CALL(c, DrawPoint(p1, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawPoint(p2, Colour::Green)).TIMES(1);

    w.MouseMove(p1);
    w.MouseDown();
    w.MouseUp();

    w.MouseMove(p2);
    w.CtrlKeyDown();
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("I can create one green and one red point")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 5, 5 };
    Point p2{ 10, 20 };

    REQUIRE_CALL(c, DrawPoint(p1, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawPoint(p2, Colour::Red)).TIMES(1);

    w.MouseMove(p1);
    w.CtrlKeyDown();
    w.MouseDown();
    w.MouseUp();

    w.MouseMove(p2);
    w.CtrlKeyUp();
    w.MouseDown();
    w.MouseUp();
}

TEST_CASE("I can create lots of points and lines")
{
    MockCanvas c;
    Widget w{ c };

    Point p1{ 5, 5 };
    Point p2{ 10, 20 };
    Point p3{ 29, 12 };
    Point p4{ -5, 8 };
    Point p5{ 3, 7 };

    REQUIRE_CALL(c, DrawPoint(p1, Colour::Red)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p1, p2, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p2, p3, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawPoint(p4, Colour::Green)).TIMES(1);
    REQUIRE_CALL(c, DrawLine(p4, p5, Colour::Red)).TIMES(1);

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
}
