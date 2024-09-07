﻿using SkiaSharp;
using System.Runtime.InteropServices;

namespace InputTextureService.TextureConfig
{
    public class InputTextureReader : IAsyncTexturReader
    {
        private readonly string fileName;

        public InputTextureReader(string fileName)
        {
            this.fileName = fileName;
        }

        public async Task<InputTexture> ReadTextureAsync()
        {
            string path = GetTextureImageFilePath(fileName);
            var inputTexture = GetImageBytes(fileName);
            return inputTexture;
        }

        public InputTexture GetImageBytes(string fileName)
        {
            var outputImagePath = GetTextureImageFilePath(fileName);
            using var image = SKImage.FromEncodedData(outputImagePath);
            using var bitmap = SKBitmap.FromImage(image);
            int Width = image.Width;
            int Height = image.Height;
            using var pixmap = bitmap.PeekPixels();
            var span = pixmap.GetPixelSpan();
            byte[] bitmapBytes = MemoryMarshal.AsBytes(span).ToArray();

            return new InputTexture(Width, Height, bitmapBytes);
        }

        public string GetTextureImageFilePath(string fileName)
        {
            const string textureImagesPath = "Images";
            string basePath = Path.GetFullPath(@".");
            string imagePath = Path.Combine(basePath, textureImagesPath, fileName);
            return imagePath;
        }
    }
}
