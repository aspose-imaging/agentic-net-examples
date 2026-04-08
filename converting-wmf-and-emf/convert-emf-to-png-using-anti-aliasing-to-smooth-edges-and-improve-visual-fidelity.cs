using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with anti‑aliasing
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAliasGridFit
            };

            // Set PNG save options to use the vector rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the rasterized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}