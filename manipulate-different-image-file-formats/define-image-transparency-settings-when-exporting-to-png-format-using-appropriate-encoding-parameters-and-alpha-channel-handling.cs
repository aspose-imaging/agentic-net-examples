using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_transparent.png";

        // Load the source image (must contain an alpha channel)
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG export options to preserve transparency and control encoding
            PngOptions pngOptions = new PngOptions
            {
                // Preserve the alpha channel
                ColorType = PngColorType.TruecolorWithAlpha,
                // Enable progressive PNG loading
                Progressive = true,
                // Maximum compression level (0-9)
                CompressionLevel = 9,
                // Use adaptive filtering for optimal compression
                FilterType = PngFilterType.Adaptive,
                // Set bits per channel
                BitDepth = 8,
                // Keep original metadata if present
                KeepMetadata = true
            };

            // Save the image using the defined PNG options
            image.Save(outputPath, pngOptions);
        }
    }
}