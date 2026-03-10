using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Prerequisites for SVG to BMP conversion:
        // 1. Load the SVG image using Image.Load (auto-detects format).
        // 2. Provide VectorRasterizationOptions with at least PageSize set.
        // 3. Optionally set background color, smoothing mode, and text rendering hint.
        // 4. Attach the rasterization options to BmpOptions.
        // 5. Save the image using BmpOptions.

        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        // Load the SVG image.
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options required for vector-to-raster conversion.
            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
            {
                // Define the output size; preserving aspect ratio if one dimension is zero.
                PageSize = image.Size,
                // Set a background color to avoid transparency issues in BMP.
                BackgroundColor = Color.White,
                // Define rendering quality settings.
                SmoothingMode = SmoothingMode.None,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel
            };

            // Set up BMP save options and associate the rasterization options.
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Perform the conversion and save as BMP.
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}