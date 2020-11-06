using System;
using System.Reflection;

namespace SoftrayNewsAPI.Models
{
    public class News
    {
        public News (int id, string title, string desc, NewsStatus status, DateTime date, User user)
        {
            Id = id;
            Title = title;
            Description = desc;
            Status = status;
            DateInserted = date;
            UserCreated = user;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public NewsStatus Status { get; set; }
        public DateTime DateInserted { get; set; }
        public User UserCreated { get; set; }
    }
}
