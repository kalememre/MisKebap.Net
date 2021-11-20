using System;
using MongoDB.Bson;

namespace MisKebap.DAL.Entities
{
    public class CategoryImage
    {
        public ObjectId Id { get; set; }
        public int CategoryId { get; set; }
        public byte[] Image { get; set; }

    }
}
