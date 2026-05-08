using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.svg";

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

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options (no compression, we will minify manually)
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = svgRasterOptions,
                    Compress = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Minify the saved SVG XML
            string svgContent = File.ReadAllText(outputPath);
            // Remove line breaks, tabs, and unnecessary spaces between tags
            string minified = Regex.Replace(svgContent, @">\s+<", "><");
            minified = Regex.Replace(minified, @"\s+", " ");
            minified = minified.Trim();

            File.WriteAllText(outputPath, minified);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}