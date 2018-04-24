using System;
class WidgetsProgram
{
    static void Main()
    {
        SquareWidget sq = new SquareWidget();
        sq.SideLength = 5.0;
        Console.WriteLine(sq.Area);
    }
}
