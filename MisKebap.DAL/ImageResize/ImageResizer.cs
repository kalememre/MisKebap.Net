using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MisKebap.DAL.ImageResize
{
    public static class ImageResizer
    {
        public static byte[] Resize(IFormFile file)
        {
            Image currentImage = Image.FromStream(file.OpenReadStream(), true, true);
            var newImage = new Bitmap(currentImage.Width, currentImage.Height);

            using (var drawnImage = Graphics.FromImage(newImage))
            {
                drawnImage.DrawImage(currentImage, 0, 0, currentImage.Width, currentImage.Height);
            }

            using var stream = new MemoryStream();
            newImage.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }
    }
}
