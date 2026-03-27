using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\result.png";

        // Verify input file exists
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
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions();
            rasterOptions.PageSize = image.Size;               // Preserve original size
            rasterOptions.BackgroundColor = Color.White;       // Optional background

            // Configure PNG save options
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;
            pngOptions.ResolutionSettings = new ResolutionSetting(300, 300); // Set DPI

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}