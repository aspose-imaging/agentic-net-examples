using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class WebPToGifConverter
{
    static void Main()
    {
        // Directory containing the source WebP file and where the GIF will be saved
        string dir = @"C:\temp\";

        // Load the animated WebP image
        using (WebPImage webPImage = new WebPImage(System.IO.Path.Combine(dir, "animation.webp")))
        {
            // Prepare GIF options – FullFrame ensures each animation frame is stored as a full image
            GifOptions gifOptions = new GifOptions
            {
                FullFrame = true
            };

            // Save the WebP animation as an animated GIF
            webPImage.Save(System.IO.Path.Combine(dir, "animation_converted.gif"), gifOptions);
        }
    }
}