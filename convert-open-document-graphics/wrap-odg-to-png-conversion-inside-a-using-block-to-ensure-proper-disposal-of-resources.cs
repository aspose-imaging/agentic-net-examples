using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.odg";
        string outputPath = @"C:\output\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG image and convert to PNG
        using (Image image = Image.Load(inputPath))
        {
            // Set rasterization options for ODG
            var rasterOptions = new OdgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size
            };

            // Configure PNG save options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}