using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define the folder where the source WebP and the resulting GIF will be stored.
        string dir = @"c:\temp\";

        // Load the WebP image from file using the WebPImage constructor (load rule).
        using (WebPImage webPImage = new WebPImage(dir + "test.webp"))
        {
            // Prepare GIF export options.
            // DoPaletteCorrection builds an optimal palette for the GIF.
            // Interlaced enables progressive rendering of the GIF.
            GifOptions gifOptions = new GifOptions
            {
                DoPaletteCorrection = true,
                Interlaced = true,
                // Optional: set color resolution (bits per color - 1). 7 means 8 bits per color.
                ColorResolution = 7
            };

            // Save the active frame of the WebP image as a GIF file (save rule).
            webPImage.Save(dir + "test.output.gif", gifOptions);
        }
    }
}