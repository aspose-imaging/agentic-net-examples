using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Prepare SVG save options with a light blue background
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    // Set the background color to light blue
                    BackgroundColor = Aspose.Imaging.Color.LightBlue,
                    // Use the original image size for the SVG page
                    PageSize = rasterImage.Size
                }
            };

            // Save the image as SVG
            rasterImage.Save(outputPath, svgOptions);
        }
    }
}