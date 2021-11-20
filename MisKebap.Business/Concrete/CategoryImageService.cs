using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Context;
using MisKebap.DAL.Entities;
using MisKebap.DAL.ImageResize;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MisKebap.Business.Concrete
{
    public class CategoryImageService : ICategoryImageService
    {
        private readonly IMongoCollection<CategoryImage> _mongoCollection;
        private readonly MisKebapContext _misKebapContext;

        public CategoryImageService(IMongoDbContext mongoDbContext, MisKebapContext misKebapContext)
        {
            _mongoCollection = mongoDbContext.GetCollection<CategoryImage>();
            _misKebapContext = misKebapContext;
        }

        public int AddCategoryImage(int CategoryId, IFormFile file)
        {
            
            var current = _misKebapContext.Categories.FirstOrDefault(q => !q.IsDeleted && q.Id == CategoryId);
            if (current == null) return -1;

            var currentImage = _mongoCollection.Find(q => q.CategoryId == CategoryId).FirstOrDefault();
            if (currentImage != null) return -2;

            var resizedImage = ImageResizer.Resize(file);
            var categoryImage = new CategoryImage
            {
                Id = ObjectId.GenerateNewId(),
                CategoryId = CategoryId,
                Image = resizedImage
            };

            _mongoCollection.InsertOne(categoryImage);
            return 1;
        }

        public int DeleteCategoryImage(int CategoryId)
        {
            var current = _mongoCollection.Find(q => q.CategoryId == CategoryId).FirstOrDefault();
            if (current == null) return -1;

            var currentImage = _mongoCollection.DeleteOne(q => q.CategoryId == CategoryId);
            if (!currentImage.IsAcknowledged) return -2;
            return 1;
        }

        public byte[] GetCategoryImageById(int CategoryId)
        {
            var currentImage = _mongoCollection.Find(q => q.CategoryId == CategoryId).FirstOrDefault();
            if (currentImage == null) return null;
            return currentImage?.Image;
        }

        public int UpdateCategoryImage(int CategoryId, IFormFile file)
        {
            var current = _misKebapContext.Categories.FirstOrDefault(q => !q.IsDeleted && q.Id == CategoryId);
            var currentImage = _mongoCollection.Find(q => q.CategoryId == CategoryId).FirstOrDefault();

            if (current == null) return -1;

            var resizedImage = ImageResizer.Resize(file);
            currentImage.Image = resizedImage;
            var result = _mongoCollection.ReplaceOne(q => q.CategoryId == CategoryId, currentImage);
            if (!result.IsAcknowledged) return -2;
            return 1;
        }
    }
}
