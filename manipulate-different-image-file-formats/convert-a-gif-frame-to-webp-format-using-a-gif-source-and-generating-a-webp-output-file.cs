using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class GifToWebpConverter
{
    static void Main()
    {
        // Define input GIF file and output WebP file paths
        string inputGifPath = @"C:\temp\input.gif";
        string outputWebpPath = @"C:\temp\output.webp";

        // Load the GIF image (only the active frame will be considered for conversion)
        using (Image gifImage = Image.Load(inputGifPath))
        {
            // Configure WebP saving options (lossless compression with high quality)
            WebPOptions webpOptions = new WebPOptions
            {
                Lossless = true,
                Quality = 90f
            };

            // Save the active frame of the GIF as a WebP image
            gifImage.Save(outputWebpPath, webpOptions);
        }
    }
}