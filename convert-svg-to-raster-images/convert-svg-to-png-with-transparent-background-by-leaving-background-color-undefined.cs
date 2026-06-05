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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options with a transparent background
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageSize = svgImage.Size
                };

                // Set PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized PNG image
                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}