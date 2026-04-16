using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image and ensure proper disposal
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Create SVG options and ensure proper disposal
            using (SvgOptions options = new SvgOptions())
            {
                // Configure rasterization options (optional)
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };
                options.VectorRasterizationOptions = rasterOptions;

                // Example: enable compression
                options.Compress = true;

                // Save the SVG image with the specified options
                svgImage.Save(outputPath, options);
            }
        }
    }
}