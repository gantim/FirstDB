using System;
using Entity_Frametamer;

public class Program
{
    public static void Main()
    {
        BookService bookService = new BookService();
        while (true)
        {
            int number;
            Console.WriteLine("Введите цифру соотвествующему вашему выбору: \n  1 - добавть книгу \n  2 - получить данные о книге \n  3 - изменить навание или автора книги \n  4 - удалить книгу");
            var x = Console.ReadLine();
            var success = int.TryParse(x, out number);
            if(success) 
                Controller.Handle(number, bookService);
            else 
                Console.WriteLine("Введите число. \n");
        }
    }
}
