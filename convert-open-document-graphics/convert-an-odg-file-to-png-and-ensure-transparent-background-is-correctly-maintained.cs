using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
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
            // Configure rasterization to keep transparency
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.Transparent
            };

            // Set PNG save options and attach rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as PNG with transparent background
            image.Save(outputPath, pngOptions);
        }
    }
}