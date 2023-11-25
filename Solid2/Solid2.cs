using System;
/*Порушено принцип єдиного обов'язку (The Single Responsibility Principle) - клас відповідає за відправку повідомлення
та ще і вирішує як буде вестися лог (різні обов'язки для одного класу).*/

/*Принцип відкритості/закритості (The Open Closed Principle) - якщо треба змінити спосіб логування, то будемо змушені змінювати
клас EmailSender. Додаємо можливість додавати нові способи логування, не змінюючи EmailSender, тобто створюємо інтерфейс та можемо додати нові його імплементації.
Тим самим, розширюємо функціонал класу EmailSender не змінюючи код.*/

/*Принцип інверсії залежностей (Dependency Inversion Principle) - клас EmailSender (високорівневий модуль) залежить від конкретної реалізації логування (низькорівневий модуль),
а саме від використання Console.WriteLine для ведення логів. Це означає, що зміна способу логування вимагатиме зміни в класі EmailSender, що порушує принцип інверсії залежностей.
Модулі верхнього рівня не повинні залежати від модулів нижнього рівня.*/
class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}

class EmailSender
{
    private ILogger logger;

    public EmailSender(ILogger logger)
    {
        this.logger = logger;
    }

    public void Send(Email email)
    {
        // ... sending...
        logger.Log(email);
    }
}

interface ILogger
{
    void Log(Email email);
}

class EmailLogger : ILogger
{
    public void Log(Email email)
    {
        Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}

//...//

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        ILogger logger = new EmailLogger();
        EmailSender es = new EmailSender(logger);
        es.Send(e1);
        es.Send(e2);
        es.Send(e3);
        es.Send(e4);
        es.Send(e5);
        es.Send(e6);

        Console.ReadKey();
    }
}