using System;
namespace MisKebap.DAL.Dtos.Product
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsEnabled { get; set; }

        public string CategoryName { get; set; }
    }
}
