using System;
namespace EntityFrameworkAssignment.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Full_name { get; set; }
        public int Popularity { get; set; }
    }   
}
