using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options
            var rasterOptions = new VectorRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.Transparent,
                SmoothingMode = SmoothingMode.AntiAlias
            };

            // Configure PNG save options with 300 DPI resolution
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Save as lossless PNG with transparent background
            image.Save(outputPath, pngOptions);
        }
    }
}