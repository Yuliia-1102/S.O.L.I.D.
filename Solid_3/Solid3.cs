using System;

/* Liskov Substitution Principle - принцип підстановки Лісков. Завдяки своєрідному перевизначенню властивостей переписується одночасно висота/ширина квадрата (rect.Height), тому виходить 100. 
Через квадрат змінюється поведінка прямокутника - порушення. Роз'єднуємо функціональність квадратів і прямокутників.  
*/

class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int GetRectangleArea()
    {
        return Width * Height;
    }
}

interface IShape
{
    public int Side { get; set; }
    int GetRectangleArea();
}

class Square : IShape
{
    public int Side { get; set; }
    public int GetRectangleArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle();
        IShape sq = new Square();
        rect.Width = 5;
        rect.Height = 10;

        sq.Side = 4;

        Console.WriteLine(rect.GetRectangleArea());
        Console.WriteLine(sq.GetRectangleArea());
        Console.ReadKey();
    }
}