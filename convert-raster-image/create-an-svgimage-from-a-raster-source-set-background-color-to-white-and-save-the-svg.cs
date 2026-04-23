using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG conversion
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White // Set background to white
            };

            // Set up SVG save options with the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as SVG
            rasterImage.Save(outputPath, svgOptions);
        }
    }
}