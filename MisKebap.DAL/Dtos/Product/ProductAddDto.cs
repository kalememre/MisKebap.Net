using System;
namespace MisKebap.DAL.Dtos.Product
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
