using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (any supported format)
        string inputPath = "input.jpg";

        // Output PNG path
        string outputPath = "output.png";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG options with the desired bit depth
            PngOptions pngOptions = new PngOptions
            {
                // Set bit depth (allowed values: 1, 2, 4, 8, 16)
                BitDepth = 8,

                // Example color type that supports the chosen bit depth
                ColorType = PngColorType.TruecolorWithAlpha,

                // Optional: set compression level (0-9)
                CompressionLevel = 9
            };

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}