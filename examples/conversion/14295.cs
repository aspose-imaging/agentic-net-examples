using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"C:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "test.webp");
        string outputPath = System.IO.Path.Combine(dir, "test.gif");

        // Load the WebP image from the file system
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Convert and save the image as GIF using default GifOptions
            webPImage.Save(outputPath, new GifOptions());
        }
    }
}