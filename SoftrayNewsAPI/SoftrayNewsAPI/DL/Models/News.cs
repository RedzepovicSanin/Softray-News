using SoftrayNewsAPI.DL.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SoftrayNewsAPI.DL.Models
{
    public class News
    {
        //public News (int id, string title, string text, NewsStatus status, DateTime date, User user)
        //{
        //    Id = id;
        //    Title = title;
        //    Text = text;
        //    Status = status;
        //    DateInserted = date;
        //    UserCreated = user;
        //}
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NewsStatus Status { get; set; }
        public DateTime DateInserted { get; set; }
            
        [ForeignKey("UserId")]
        public User UserCreated { get; set; }
    }
}
