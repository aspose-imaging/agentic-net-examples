using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Create rasterization options for ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                // Set background color if needed
                BackgroundColor = Color.White,
                // Use the original image size as page size
                PageSize = image.Size
            };

            // Configure PNG save options
            PngOptions pngOptions = new PngOptions
            {
                // Set desired resolution (e.g., 300 DPI)
                ResolutionSettings = new ResolutionSetting(300, 300),
                // Assign the rasterization options
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}