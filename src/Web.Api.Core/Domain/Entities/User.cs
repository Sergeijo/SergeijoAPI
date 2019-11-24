using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Core.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public string Name { get; }
        public DateTime Birthdate { get; }
        public string Password { get; }

        public User(int id, string name, DateTime birthdate, string password = null)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            Password = password;
        }
    }
}
