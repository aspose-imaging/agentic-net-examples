using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\map.pdf";
        string outputPath = @"C:\Data\map.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options to match source size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG save options, preserving metadata (including geographic coordinates)
            var svgOptions = new SvgOptions
            {
                KeepMetadata = true,
                VectorRasterizationOptions = rasterOptions
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}