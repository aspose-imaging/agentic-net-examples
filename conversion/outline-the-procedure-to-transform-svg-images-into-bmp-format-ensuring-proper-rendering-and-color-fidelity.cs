using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\sample.bmp";

        // Verify that the SVG source file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image using Aspose.Imaging unified loader
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options so the vector SVG is rendered at its native size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options and attach the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP, preserving color fidelity
            image.Save(outputPath, bmpOptions);
        }
    }
}