using SoftrayNewsAPI.DL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.DL.Models
{
    public class User
    {
        //public User(int id, string name, DateTime date)
        //{
        //    Id = id;
        //    Name = name;
        //    DateInserted = date;
        //}
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public UserStatus Status { get; set; }
        public DateTime DateInserted { get; set; }
        public ICollection<News> News { get; set; }
    }
}
