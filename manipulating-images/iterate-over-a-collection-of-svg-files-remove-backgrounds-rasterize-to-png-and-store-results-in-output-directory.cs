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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputSvgs";
            string outputDir = @"C:\OutputPngs";

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (var inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (SvgImage svgImage = new SvgImage(inputPath))
                {
                    // Remove any background from the SVG
                    svgImage.RemoveBackground();

                    // Configure rasterization options
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Configure PNG save options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the rasterized PNG
                    svgImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}