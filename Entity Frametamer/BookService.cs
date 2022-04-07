using System;
using System.Linq;

namespace Entity_Frametamer
{
    public class BookService
    {
        public Book Add(string title, string author)
        {
            using (Application db = new Application())
            {
                Book book = new Book() {Title = title, Author = author};

                db.Books.Add(book);
                db.SaveChanges();

                return book;
            }
        }

        public Book Get(int id)
        {
            using (Application db = new Application())
            {
                var book = db.Books.FirstOrDefault(g => g.Id == id);
                if (book == null)
                    return null;
                return book;
            }
        }
        public Book Edit(int id, string newAuthor, string newTitle)
        {
            using (Application db = new Application())
            {
                var book = db.Books.FirstOrDefault(g => g.Id == id);
                if (book == null)
                    return null;
                if (newAuthor == null)
                {
                    book.Title = newTitle;
                    db.Books.Update(book);
                    db.SaveChanges();
                    
                    return book;
                }
                {
                    book.Author = newAuthor;
                    db.Books.Update(book);
                    db.SaveChanges();

                    return book;
                }
            }
        }
        public Book Delete(int id)
        {
            using (Application db = new Application())
            {
                var book = db.Books.FirstOrDefault(g => g.Id == id);
                if (book == null)
                    return null;
                else
                {
                    db.Books.Remove(book);
                    db.SaveChanges();

                    return book;
                }
            }
        }

        public Book Have(int id)
        {
            using (Application db = new Application())
            {
                var book = db.Books.FirstOrDefault(g => g.Id == id);
                if (book == null)
                    return null;
                return book;
            }
        }
    }
}