using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Example visual effect: convert to grayscale
            pngImage.Grayscale();

            // Configure PNG save options with a specific filter type
            PngOptions saveOptions = new PngOptions
            {
                // Adaptive filtering chooses the best filter per row (best compression, slower)
                FilterType = PngFilterType.Adaptive,
                // Preserve progressive loading flag (optional)
                Progressive = true,
                // Keep other defaults (bit depth, color type, etc.)
            };

            // Save the processed image using the configured options
            pngImage.Save(outputPath, saveOptions);
        }
    }
}