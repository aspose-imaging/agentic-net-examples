using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\MapDocument.pdf";
        string outputPath = @"C:\Data\MapDocument.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document (vector image)
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options – keep the original page size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Prepare SVG save options, preserving metadata (e.g., geographic coordinates)
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                KeepMetadata = true
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}