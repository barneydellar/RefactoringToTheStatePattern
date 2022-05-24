namespace StateCSharp;

public interface IState
{
    IState MouseMove(Point point, Widget widget) => this;
    IState MouseDown() => this;
    IState CtrlKeyDown() => this;
    IState MouseUp(Widget widget) => this;
    IState CtrlKeyUp() => this;
}