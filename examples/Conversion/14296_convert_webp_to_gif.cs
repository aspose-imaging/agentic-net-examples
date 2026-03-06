using System;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source WebP file
        string inputPath = @"C:\temp\input.webp";

        // Desired path for the resulting GIF file
        string outputPath = @"C:\temp\output.gif";

        // Load the WebP image using the provided constructor (load rule)
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Create default GIF save options (save rule)
            GifOptions gifOptions = new GifOptions();

            // Save the loaded image as GIF using the Save method (save rule)
            webpImage.Save(outputPath, gifOptions);
        }
    }
}