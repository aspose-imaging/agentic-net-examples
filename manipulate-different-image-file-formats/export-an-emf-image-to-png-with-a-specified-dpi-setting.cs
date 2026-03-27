using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output\\converted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired DPI settings
        int dpiX = 300;
        int dpiY = 300;

        // Load EMF image and convert to PNG with specified DPI
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options
            EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure PNG options with DPI and vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions,
                ResolutionSettings = new Aspose.Imaging.ResolutionSetting(dpiX, dpiY)
            };

            // Save the PNG file
            image.Save(outputPath, pngOptions);
        }
    }
}