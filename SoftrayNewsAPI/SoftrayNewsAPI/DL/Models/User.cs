using SoftrayNewsAPI.DL.Enums;
using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public UserStatus Status { get; set; }
        public DateTime DateInserted { get; set; }
    }
}
