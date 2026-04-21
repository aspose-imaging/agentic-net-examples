using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG save options
            var svgOptions = new SvgOptions
            {
                // Preserve original metadata (including layer names if present)
                KeepMetadata = true,
                // Do not convert text to shapes; keep original text representation
                TextAsShapes = false
            };

            // Configure OTG rasterization options
            var otgRasterOptions = new OtgRasterizationOptions
            {
                // Use the original image size for the SVG page
                PageSize = image.Size
            };

            svgOptions.VectorRasterizationOptions = otgRasterOptions;

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}