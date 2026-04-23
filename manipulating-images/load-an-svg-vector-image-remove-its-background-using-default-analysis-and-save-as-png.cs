using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the SVG image from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(stream))
            {
                // Remove the background using default analysis
                svgImage.RemoveBackground();

                // Set up rasterization options for PNG output
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size as the page size
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}