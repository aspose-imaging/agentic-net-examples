using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // Path to the source lossless WebP image
        string inputPath = @"C:\Images\source_lossless.webp";

        // Desired output path for the GIF image
        string outputPath = @"C:\Images\converted.gif";

        // Load the WebP image using the dedicated constructor
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save the image as GIF.
            // The Save(string) overload infers the format from the file extension,
            // preserving the visual content of the active frame.
            webPImage.Save(outputPath);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}