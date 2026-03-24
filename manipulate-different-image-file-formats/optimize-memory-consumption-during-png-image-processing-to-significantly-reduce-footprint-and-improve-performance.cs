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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_optimized.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Example processing: convert to grayscale (optional)
            if (image is PngImage pngImage)
            {
                pngImage.Grayscale();
            }

            // Prepare PNG save options with memory limit
            PngOptions saveOptions = new PngOptions
            {
                // Limit internal buffers to 30 MB to reduce memory consumption
                BufferSizeHint = 30,
                // Enable progressive loading (optional, does not increase memory)
                Progressive = true,
                // Use maximum compression (may increase CPU but not memory)
                CompressionLevel = 9
            };

            // Save the processed image using the options
            image.Save(outputPath, saveOptions);
        }
    }
}