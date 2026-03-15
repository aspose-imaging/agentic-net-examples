using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

public class WebPProcessing
{
    public static void Main()
    {
        // Paths for input and output files
        string inputPath = @"c:\temp\input.webp";
        string outputWebPPath = @"c:\temp\output.webp";
        string outputPngPath = @"c:\temp\output.png";

        // Load a WebP image from a file using the provided constructor
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // ----- Transformations -----
            // Resize the image to 200x200 pixels
            webPImage.Resize(200, 200);

            // Rotate the image 45 degrees, expand canvas, fill background with white
            webPImage.Rotate(45f, true, Color.White);

            // Increase brightness by 20 units
            webPImage.AdjustBrightness(20);

            // ----- Save as WebP (encoding) -----
            // Create WebP save options (lossy compression with quality 80)
            WebPOptions saveOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 80f
            };
            // Save the transformed image back to WebP using the provided Save method
            webPImage.Save(outputWebPPath, saveOptions);

            // ----- Decode to PNG (saving) -----
            // Save the active frame of the WebP image as PNG
            PngOptions pngOptions = new PngOptions();
            webPImage.Save(outputPngPath, pngOptions);
        }
    }
}