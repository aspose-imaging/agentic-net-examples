using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png; // for PngFilterType

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output_filtered.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG save options, including a PNG filter type
            var saveOptions = new ApngOptions
            {
                // Apply the Sub filter during PNG compression
                FilterType = PngFilterType.Sub,
                // Set default frame duration (in milliseconds)
                DefaultFrameTime = 200,
                // Loop infinitely (0 means infinite)
                NumPlays = 0
            };

            // Save the image with the specified options
            image.Save(outputPath, saveOptions);
        }
    }
}