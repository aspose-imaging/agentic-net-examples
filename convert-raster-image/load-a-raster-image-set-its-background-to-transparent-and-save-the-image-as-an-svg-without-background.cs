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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

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
            // Prepare SVG rasterization options with a transparent background
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set background to transparent
                BackgroundColor = Aspose.Imaging.Color.Transparent,
                // Use the original image size for the SVG page
                PageSize = image.Size
            };

            // Prepare SVG save options and attach rasterization options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as SVG without a background
            image.Save(outputPath, svgOptions);
        }
    }
}