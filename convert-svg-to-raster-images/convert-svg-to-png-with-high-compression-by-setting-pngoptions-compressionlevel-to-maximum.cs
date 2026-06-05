using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input SVG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9 // Maximum compression (range 0-9)
                };

                // Configure rasterization options for the SVG
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original SVG dimensions
                };
                pngOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the rasterized image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}