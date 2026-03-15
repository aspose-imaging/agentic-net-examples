using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // Path to the source animated WebP file
        string inputWebPPath = @"C:\Images\animation.webp";

        // Desired path for the output animated GIF file
        string outputGifPath = @"C:\Images\animation_converted.gif";

        // Load the WebP image (including all animation frames)
        using (WebPImage webPImage = new WebPImage(inputWebPPath))
        {
            // Save the loaded WebP image as GIF.
            // GifOptions ensures that the output respects GIF format capabilities
            // (palette, frame delays, etc.) while preserving animation frames.
            webPImage.Save(outputGifPath, new GifOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}