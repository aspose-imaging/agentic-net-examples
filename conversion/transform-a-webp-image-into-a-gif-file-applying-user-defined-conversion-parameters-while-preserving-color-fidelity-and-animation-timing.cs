using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class WebPToGifConverter
{
    static void Main()
    {
        // Input WebP file (can be animated)
        string inputWebPPath = @"C:\Images\input.webp";

        // Output GIF file
        string outputGifPath = @"C:\Images\output.gif";

        // Load the WebP image (single or multi‑frame) using the provided load rule
        using (Image webpImage = Image.Load(inputWebPPath))
        {
            // Prepare GIF save options – user‑defined conversion parameters
            var gifOptions = new GifOptions
            {
                // Preserve as many colors as possible (max 256 for GIF)
                ColorResolution = 256,

                // Use Floyd‑Steinberg dithering to maintain visual fidelity
                Dither = DitheringMethod.FloydSteinberg,

                // Keep original animation timing if the source is animated
                // (Aspose.Imaging copies frame delays automatically when MultiPageOptions is not set)
                // Additional timing control can be done via FrameDelay property if needed
            };

            // Save the image as an animated GIF using the provided save rule
            webpImage.Save(outputGifPath, gifOptions);
        }
    }
}