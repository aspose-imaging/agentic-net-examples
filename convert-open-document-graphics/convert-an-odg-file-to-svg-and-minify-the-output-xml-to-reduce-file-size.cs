using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options (no compression to keep XML text)
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Compress = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Minify the resulting SVG by removing whitespace between tags
            string svgContent = File.ReadAllText(outputPath);
            string minified = Regex.Replace(svgContent, @">\s+<", "><").Trim();
            File.WriteAllText(outputPath, minified);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}