// ReSharper disable UnusedMember.Local
namespace StateCSharp;

public struct Point(int i, int j)
{
    private int _x = i;
    private int _y = j;
}