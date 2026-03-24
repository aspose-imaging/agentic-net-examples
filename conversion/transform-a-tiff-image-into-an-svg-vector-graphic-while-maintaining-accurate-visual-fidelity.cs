using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare vector rasterization options matching the source image size
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions,
                // Preserve original metadata if needed
                KeepMetadata = true
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}