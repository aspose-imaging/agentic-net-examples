using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Path to the source WebP file (can be animated)
        string sourcePath = @"C:\Images\sample.webp";

        // Path where the converted GIF will be saved
        string destinationPath = @"C:\Images\sample_converted.gif";

        // Load the WebP image using the provided constructor that accepts a file path
        using (WebPImage webpImage = new WebPImage(sourcePath))
        {
            // Save the loaded WebP image as GIF.
            // GifOptions are used to preserve all frames (animation) from the source.
            webpImage.Save(destinationPath, new GifOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}