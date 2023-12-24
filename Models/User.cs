using System;
namespace WebHomework.Models
{
	public class User
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}

