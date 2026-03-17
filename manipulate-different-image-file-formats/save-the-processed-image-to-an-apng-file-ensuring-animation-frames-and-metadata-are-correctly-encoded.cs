using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Path to the source image (can be a multi‑page format like TIFF or a single raster image)
        string sourcePath = "input.tif";

        // Desired output APNG file path
        string outputPath = "output.apng";

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Configure APNG saving options
            var apngOptions = new ApngOptions
            {
                // Set default frame duration (in milliseconds)
                DefaultFrameTime = 200,

                // Number of times the animation should loop (0 = infinite)
                NumPlays = 0,

                // Preserve original metadata (EXIF, XMP, etc.) in the exported file
                KeepMetadata = true
            };

            // Save the loaded image as an animated PNG using the configured options
            image.Save(outputPath, apngOptions);
        }
    }
}