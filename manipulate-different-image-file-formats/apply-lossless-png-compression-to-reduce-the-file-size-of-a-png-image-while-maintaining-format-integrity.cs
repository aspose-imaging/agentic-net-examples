using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PNG image
        string inputPath = "input.png";

        // Path where the compressed PNG will be saved
        string outputPath = "output_compressed.png";

        // Load the existing PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure lossless PNG compression options
            var options = new PngOptions
            {
                // Maximum compression level (0-9)
                CompressionLevel = 9,

                // Adaptive filtering provides the best compression for lossless PNG
                FilterType = PngFilterType.Adaptive,

                // Enable progressive loading (optional, does not affect losslessness)
                Progressive = true
            };

            // Save the image with the specified compression options
            image.Save(outputPath, options);
        }
    }
}