using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.pdf";
        string outputPath = @"C:\Output\sample.svg";

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
            // Configure rasterization options (page size matches source)
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                TextAsShapes = true,          // Preserve text as editable shapes
                KeepMetadata = true           // Retain original metadata
            };

            // Save as SVG, preserving layer hierarchy where supported
            image.Save(outputPath, svgOptions);
        }
    }
}