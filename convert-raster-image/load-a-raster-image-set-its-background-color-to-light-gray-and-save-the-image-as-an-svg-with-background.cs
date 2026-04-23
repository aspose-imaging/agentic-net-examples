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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG save options with a light‑gray background
            var svgOptions = new SvgOptions();

            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set background color for the SVG canvas
                BackgroundColor = Aspose.Imaging.Color.LightGray,
                // Use the original image size as the page size
                PageSize = image.Size
            };

            svgOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the image as SVG with the specified background
            image.Save(outputPath, svgOptions);
        }
    }
}