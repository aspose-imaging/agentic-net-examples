using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // Input WebP file (can be static or animated)
        string inputWebPPath = @"C:\Images\input.webp";

        // Output GIF file path
        string outputGifPath = @"C:\Images\output.gif";

        // Load the WebP image using the dedicated constructor (load rule)
        using (WebPImage webpImage = new WebPImage(inputWebPPath))
        {
            // ------------------------------------------------------------
            // User‑defined conversion parameters
            // ------------------------------------------------------------
            // Example: preserve original animation timing by copying frame delays
            // (Aspose.Imaging automatically copies frame timing when saving to GIF
            //  if the source image implements IMultipageImage.)
            // Additional GIF‑specific options can be set here.
            GifOptions gifOptions = new GifOptions
            {
                // Preserve the original color palette depth (default is 8‑bit)
                // ColorDepth = 8, // Uncomment if you need to enforce a specific depth

                // Preserve animation loop count if the source is animated
                // LoopCount = 0, // 0 means infinite looping; set as needed

                // You can also control dithering, transparency, etc., here.
            };

            // Save the image as GIF using the Save(string, ImageOptionsBase) method (save rule)
            // This operation keeps color fidelity and animation timing.
            webpImage.Save(outputGifPath, gifOptions);
        }
    }
}