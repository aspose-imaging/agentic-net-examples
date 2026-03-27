using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options to keep transparency
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.Transparent
            };

            // Set up PNG save options with the vector rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save as PNG preserving transparent background
            image.Save(outputPath, pngOptions);
        }
    }
}