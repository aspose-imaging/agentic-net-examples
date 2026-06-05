using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image and ensure proper disposal
            using (SvgImage svgImage = (SvgImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Create rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Set page size based on the loaded image dimensions
                    PageSize = new Aspose.Imaging.SizeF(svgImage.Width, svgImage.Height)
                };

                // Create SVG options and ensure disposal
                using (SvgOptions options = new SvgOptions())
                {
                    options.VectorRasterizationOptions = rasterOptions;
                    // Save the SVG image using the specified options
                    svgImage.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}