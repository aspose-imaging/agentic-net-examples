using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Input PNG file path
        string inputPath = @"C:\temp\sample.png";

        // Output PNG file path (will retain PNG format)
        string outputPath = @"C:\temp\sample_filtered.png";

        // Load the existing PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options with a specific filter type
            PngOptions pngOptions = new PngOptions
            {
                // Apply Adaptive filtering – best compression (slowest execution)
                FilterType = PngFilterType.Adaptive,

                // Enable progressive loading (optional, but keeps PNG compliance)
                Progressive = true,

                // Set maximum compression level (0‑9)
                CompressionLevel = 9,

                // Preserve original color type (adjust if needed)
                ColorType = PngColorType.TruecolorWithAlpha,

                // Preserve original bit depth (1,2,4,8,16)
                BitDepth = 8
            };

            // Save the image using the configured PNG options
            image.Save(outputPath, pngOptions);
        }
    }
}