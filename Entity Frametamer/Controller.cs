using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Entity_Frametamer
{
    public class Controller
    {
        public static void Handle(int x, BookService bookService)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введите название книги");
                    var title = Console.ReadLine();
            
                    Console.WriteLine("Введите автора книги");
                    var author = Console.ReadLine();

                    var book = bookService.Add(title, author);
                    Console.WriteLine($"Книга: '{book.Title}' под кодом: {book.Id} - добавленна в базу данных.");
                    break;
                case 2:
                    Console.WriteLine("Введите id книги, информацию о которой хотите получить");
                    var id = int.TryParse(Console.ReadLine(), out x);
                    if (id)
                    {
                        var book1 = bookService.Get(x);
                        if (book1 == null)
                            Console.WriteLine("Книги с данным id не существует, повторите операцию снова.");
                        else
                            Console.WriteLine(
                                $"\nid книги - {book1.Id} \nНазвание книги - {book1.Title} \nАвтор книги - {book1.Author}\n");
                        break;
                    }
                    Console.WriteLine("Введите id книги.");
                    break;
                case 3:
                    Console.WriteLine("Введите Id киниги информацию о которой хотите изменить");
                    var id1 = int.TryParse(Console.ReadLine(), out x);
                    if (id1)
                    {
                        var bookHave = bookService.Have(x);
                        if (bookHave != null)
                        {
                            Console.WriteLine("Что вы хотите изменить? \n Автора - 1\n Название - 2");
                            var cangeId = int.TryParse(Console.ReadLine(), out int a);
                            if (cangeId)
                            {
                                if (a == 1)
                                {
                                    var bookX = bookService.Get(x);

                                    Console.WriteLine(
                                        $"Текущий автор произведени - {bookX.Author}, введите нового автора:");
                                    string newAuthor = Console.ReadLine();
                                    var book2 = bookService.Edit(x, newAuthor, null);

                                    Console.WriteLine("Автор данного произведения успешно изменён.\n");
                                    Console.WriteLine(
                                        $"Обновлённая информация о книге: \nНазвание книги - {book2.Title} \nАвтор книги - {book2.Author} \nid книги - {book2.Id}");
                                }

                                if (a == 2)
                                {
                                    var bookX1 = bookService.Get(x);

                                    Console.WriteLine(
                                        $"Текущее название произведения - {bookX1.Title} Введите новое название книги:");
                                    string newTitle = Console.ReadLine();
                                    var book3 = bookService.Edit(x, null, newTitle);

                                    Console.WriteLine("Название данного произведения успешно изменено.");
                                    Console.WriteLine(
                                        $"Обновлённая информация о книге: \nНазвание книги - {book3.Title} \nАвтор книги - {book3.Author} \nid книги - {book3.Id}");
                                }
                                Console.WriteLine("Выберите одно из двух.");
                                break;
                            }
                            Console.WriteLine("Выберите одно из двух.");
                            break;
                        }
                        Console.WriteLine("Книги с таким id не существует");
                        break;
                    }
                    Console.WriteLine("Введите id книги.");
                    break;
                case 4:
                    Console.WriteLine("Введите id книги, которую хотите удалить");
                    var id2 = int.TryParse(Console.ReadLine(), out x);
                    if (id2)
                    {
                        var book4 = bookService.Delete(x);
                        if (book4 == null)
                        {
                            Console.WriteLine("Книги с таким id не существует");
                            break;
                        }
                        Console.WriteLine($"Книга {book4.Title} удалена.");
                        break;
                    }
                    Console.WriteLine("Введите id книги");
                    break;
            }
        }
    }
}