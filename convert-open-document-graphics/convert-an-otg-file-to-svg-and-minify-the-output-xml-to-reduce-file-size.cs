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
        string inputPath = @"C:\Temp\input.otg";
        string outputPath = @"C:\Temp\output.svg";

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
            // Prepare SVG export options
            var svgOptions = new SvgOptions();
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }

        // Minify the saved SVG by removing whitespace between tags
        string svgContent = File.ReadAllText(outputPath);
        string minified = Regex.Replace(svgContent, @">\s+<", "><").Trim();
        File.WriteAllText(outputPath, minified);
    }
}