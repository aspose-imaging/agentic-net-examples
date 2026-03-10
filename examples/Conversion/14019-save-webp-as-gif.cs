using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source WebP file and where the GIF will be saved
        string dir = @"c:\temp\";

        // Load the WebP image from file
        using (WebPImage webPImage = new WebPImage(dir + "test.webp"))
        {
            // Configure GIF save options (optional custom settings)
            GifOptions gifOptions = new GifOptions
            {
                // Apply palette correction for optimal color mapping
                DoPaletteCorrection = true,
                // Save the GIF as interlaced (progressive loading)
                Interlaced = true
            };

            // Save the loaded WebP image as a GIF file using the specified options
            webPImage.Save(dir + "test.output.gif", gifOptions);
        }
    }
}