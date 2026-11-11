using System;
using System.Linq;
using FirstClass;

namespace ClassPaper
{

    


    public class Paper
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public Paper(string title, Person author, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Paper()
        {
            Title = "Без названия";
            Author = new Person();
            PublicationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Публикация: \"{Title}\", Автор: {Author.ToShortString()}, Дата: {PublicationDate:dd.MM.yyyy}";
        }
    }

}