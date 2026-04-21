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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                // Preserve original metadata
                KeepMetadata = true,
                // Do not compress; keep plain SVG
                Compress = false
            };

            // Set vector rasterization options to retain vector data and page size
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = vectorOptions;

            // Save as SVG, preserving vector layers and attributes
            image.Save(outputPath, svgOptions);
        }
    }
}