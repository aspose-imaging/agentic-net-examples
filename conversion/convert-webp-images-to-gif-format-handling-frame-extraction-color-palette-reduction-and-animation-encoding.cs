using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class WebpToGifConverter
{
    static void Main()
    {
        // Path to the source WebP file (can be animated)
        string inputWebpPath = @"C:\Temp\input.webp";

        // Path where the resulting GIF will be saved
        string outputGifPath = @"C:\Temp\output.gif";

        // Load the WebP image (single or multi‑frame) using the provided constructor
        using (WebPImage webpImage = new WebPImage(inputWebpPath))
        {
            // Create GIF save options – this object follows the required lifecycle rules
            GifOptions gifOptions = new GifOptions();

            // Optional: reduce the color palette to 256 colors (maximum for GIF)
            // If the source image has more colors, Aspose.Imaging will automatically
            // generate a suitable palette when saving.
            // gifOptions.Palette = webpImage.Palette; // uncomment if you want to reuse a palette

            // Save the WebP image (including all frames) as an animated GIF.
            // The Save method respects the multi‑page nature of the source image.
            webpImage.Save(outputGifPath, gifOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}