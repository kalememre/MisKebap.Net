using System;
namespace MisKebap.DAL.Dtos.Other
{
    public class SettingsUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsOpen { get; set; }
    }
}
