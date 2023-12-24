using System;
namespace WebHomework.Models
{
	public class Book
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string CategoryName { get; set; }
		public bool  isRead { get; set; }

		public User user { get; set; }
	}
}

