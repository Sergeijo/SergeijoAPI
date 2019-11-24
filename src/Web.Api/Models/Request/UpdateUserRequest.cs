using System;

namespace Web.Api.Models.Request
{
    public class UpdateUserRequest
    {
        public int Updated_id { get; set; }
        public string Updated_name { get; set; }
        public DateTime Updated_birthdate { get; set; }
        public string Updated_password { get; set; }
    }
}
