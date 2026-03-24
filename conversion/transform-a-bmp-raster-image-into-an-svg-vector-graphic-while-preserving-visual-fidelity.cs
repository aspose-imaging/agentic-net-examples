using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP raster image
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Configure SVG rasterization options to match the source size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = bmpImage.Size
            };

            // Set up SVG save options with the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as an SVG file
            bmpImage.Save(outputPath, svgOptions);
        }
    }
}