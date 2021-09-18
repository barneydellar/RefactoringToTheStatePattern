#include "pch.h"
#include "Widget.h"

#include "ICanvas.h"

Widget::Widget(ICanvas& c) :
    canvas_{ c } {}

void Widget::MouseDown()
{
    if (mouse_state_ == MouseState::MouseUp) {
        mouse_state_ = MouseState::MouseDown;
    }
    if (mouse_state_ == MouseState::MouseUpWithCtrlDown) {
        mouse_state_ = MouseState::MouseDownWithCtrlDown;
    }
}

void Widget::MouseMove(const Point p)
{
    if (mouse_state_ == MouseState::MouseUp) {
        start_p_ = p;
    }
    if (mouse_state_ == MouseState::MouseUpWithCtrlDown) {
        start_p_ = p;
    }
    else if (mouse_state_ == MouseState::MouseDown) {
        mouse_state_ = MouseState::MouseDragging;
    }
    if (mouse_state_ == MouseState::MouseDownWithCtrlDown) {
        mouse_state_ = MouseState::MouseDraggingWithCtrlDown;
    }
    if (mouse_state_ == MouseState::MouseDragging) {
        canvas_.DrawLine(start_p_, p, Red);
        start_p_ = p;
    }
    if (mouse_state_ == MouseState::MouseDraggingWithCtrlDown) {
        canvas_.DrawLine(start_p_, p, Green);
        start_p_ = p;
    }
}

void Widget::MouseUp()
{
    if (mouse_state_ == MouseState::MouseDownWithCtrlDown) {
        canvas_.DrawPoint(start_p_, Green);
    }
    else if (mouse_state_ == MouseState::MouseDown) {
        canvas_.DrawPoint(start_p_, Red);
    }
    if (mouse_state_ == MouseState::MouseDown || mouse_state_ == MouseState::MouseDragging)
    {
        mouse_state_ = MouseState::MouseUp;
    }
    if (mouse_state_ == MouseState::MouseDownWithCtrlDown || mouse_state_ == MouseState::MouseDraggingWithCtrlDown)
    {
        mouse_state_ = MouseState::MouseUpWithCtrlDown;
    }
}

void Widget::CtrlKeyDown()
{
    if (mouse_state_ == MouseState::MouseUp) {
        mouse_state_ = MouseState::MouseUpWithCtrlDown;
    }
}

void Widget::CtrlKeyUp()
{
    if (mouse_state_ == MouseState::MouseUpWithCtrlDown) {
        mouse_state_ = MouseState::MouseUp;
    }
    else if (mouse_state_ == MouseState::MouseDraggingWithCtrlDown) {
        mouse_state_ = MouseState::MouseDragging;
    }
    if (mouse_state_ == MouseState::MouseDownWithCtrlDown) {
        mouse_state_ = MouseState::MouseDown;
    }
}
