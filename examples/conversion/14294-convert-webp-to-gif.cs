using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class WebPToGifConverter
{
    static void Main()
    {
        // Define input WebP file and output GIF file paths
        string inputPath = @"C:\Temp\input.webp";
        string outputPath = @"C:\Temp\output.gif";

        // Load the WebP image from the file system
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save the loaded image as a GIF using default GIF options
            webPImage.Save(outputPath, new GifOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}