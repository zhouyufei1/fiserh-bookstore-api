using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class AuthorsRepository : IAuthorsRepository
    {
         private readonly BookstoreContext db;

        public IEnumerable<Author> GetAuthors()
        {
            return db.Authors;
        }

        public Author GetAuthor(int authorId)
        {
            return db.Authors.Find(authorId);
        }

        public int AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author.Id;
        }

        public void UpdateAuthor(Author author)
        {
            var UpdateAuthor = db.Authors.Find(author.Id);
            UpdateAuthor.Name = author.Name;
            db.Authors.Update(UpdateAuthor);
            db.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = db.Authors.Find(authorId);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public bool AuthorExists(int authorId)
        {
            return (db.Authors.Find(authorId) != null);
        }
    }
}