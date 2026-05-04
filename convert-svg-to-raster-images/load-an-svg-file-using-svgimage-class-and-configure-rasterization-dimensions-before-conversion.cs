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
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image from file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options (e.g., use original size)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set the page size to the SVG's original dimensions
                    PageSize = svgImage.Size,
                    // Optional: set background color, smoothing, scaling, etc.
                    // BackgroundColor = Color.White,
                    // ScaleX = 1.0f,
                    // ScaleY = 1.0f
                };

                // Prepare PNG save options and attach rasterization settings
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image to PNG
                svgImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}