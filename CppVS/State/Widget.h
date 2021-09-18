#pragma once
#include "ICanvas.h"
#include "MouseState.h"

class Widget {
public:

    explicit Widget(ICanvas&);

    void MouseDown();
    void MouseMove(Point);
    void MouseUp();
    void CtrlKeyDown();
    void CtrlKeyUp();

private:
    ICanvas& canvas_;
    MouseState mouse_state_ = MouseState::MouseUp;
    Point start_p_{};
};
