using System;

namespace Web.Api.Models.Request
{
    public class AddUserRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
    }
}
