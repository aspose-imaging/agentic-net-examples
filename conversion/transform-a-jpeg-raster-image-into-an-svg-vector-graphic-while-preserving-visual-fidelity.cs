using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.jpg";
        string outputPath = @"C:\temp\sample_converted.svg";

        // Verify that the input JPEG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG rasterization options to match the source image size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the image as an SVG file
            image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = rasterizationOptions });
        }
    }
}