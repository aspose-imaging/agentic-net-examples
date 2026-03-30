using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

public class ImageController : Microsoft.AspNetCore.Mvc.Controller
{
    public Microsoft.AspNetCore.Mvc.FileResult GetFilteredImage()
    {
        // Hardcoded input path
        string inputPath = "Input/sample.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return null;
        }

        // Load WebP image, apply grayscale filter, and return as PNG
        using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
        {
            webpImage.Grayscale();

            using (var memoryStream = new MemoryStream())
            {
                webpImage.Save(memoryStream, new PngOptions());
                byte[] imageBytes = memoryStream.ToArray();
                return new Microsoft.AspNetCore.Mvc.FileContentResult(imageBytes, "image/png");
            }
        }
    }
}