using System;
namespace MisKebap.DAL.Dtos.Other
{
    public class WriteUsViewDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
