using System;

//Принцип розділення інтерфейсу - багато клієнтських специфічних інтерфейсів краще, ніж один загальний.

interface IItemFeatures
{
    void SetColor(byte color);
    void SetSize(byte size);
}

interface IPromocode
{
    void ApplyPromocode(string promocode);
}

interface IDiscount
{
    void ApplyDiscount(string discount);
}

interface IPrice
{
    void SetPrice(double price);
}

class Books : IDiscount, IPrice
{
    private string discount { get; set; }
    private double price { get; set; }

    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void ShowInfo()
    {
        Console.WriteLine("A book with discount|price: " + discount + '|' + price);
    }

}

class Outerwear : IItemFeatures, IDiscount, IPrice
{
    private string discount { get; set; }
    private double price { get; set; }
    private byte color { get; set; }
    private byte size { get; set; }

    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void SetColor(byte color)
    {
        this.color = color;
    }

    public void SetSize(byte size)
    {
        this.size = size;
    }

    public void ShowInfo()
    {
        Console.WriteLine("A coat with discount|price|color|size: " + discount + '|' + price + '|' + color + '|' + size);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Books b = new Books();
        b.ApplyDiscount("22 dollars");
        b.SetPrice(2300);
        b.ShowInfo();

        Outerwear o = new Outerwear();
        o.ApplyDiscount("10 dollars");
        o.SetPrice(3400);
        o.SetColor(32);
        o.SetSize(4);
        o.ShowInfo();

        Console.ReadKey();
    }
}