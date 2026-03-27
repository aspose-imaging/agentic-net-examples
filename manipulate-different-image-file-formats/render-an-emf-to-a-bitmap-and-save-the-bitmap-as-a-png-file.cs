using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for EMF to bitmap conversion
            var rasterizationOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rendered bitmap as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}