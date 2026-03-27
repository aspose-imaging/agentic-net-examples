using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization to keep transparency
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            // Set PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as PNG preserving transparency
            image.Save(outputPath, pngOptions);
        }
    }
}