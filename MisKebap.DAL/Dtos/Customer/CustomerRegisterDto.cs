using System;
namespace MisKebap.DAL.Dtos.Customer
{
    public class CustomerRegisterDto
    {
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CustomerRole { get; set; }
    }
}
