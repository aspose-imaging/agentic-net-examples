using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image from the specified file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options (use the SVG's original size)
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Set up PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}