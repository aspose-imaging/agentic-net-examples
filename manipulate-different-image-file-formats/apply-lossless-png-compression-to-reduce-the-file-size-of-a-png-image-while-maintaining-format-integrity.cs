using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PNG image
        string sourcePath = "input.png";

        // Path where the compressed PNG will be saved
        string outputPath = "output.png";

        // Load the PNG image
        using (Image image = Image.Load(sourcePath))
        {
            // Configure lossless PNG compression options
            PngOptions options = new PngOptions
            {
                CompressionLevel = 9,                 // Maximum compression (0-9)
                FilterType = PngFilterType.Adaptive, // Adaptive filter for best results
                Progressive = true                    // Enable progressive loading (optional)
            };

            // Save the image with the specified options
            image.Save(outputPath, options);
        }
    }
}