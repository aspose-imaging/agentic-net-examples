using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with anti‑aliasing
            var rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set up PNG save options and attach the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as PNG with the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}