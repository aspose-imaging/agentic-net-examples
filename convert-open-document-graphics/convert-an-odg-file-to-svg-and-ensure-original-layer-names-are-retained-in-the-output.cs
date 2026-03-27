using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageOptions; // For SvgOptions and OdgRasterizationOptions

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions
            {
                // Preserve original metadata (including layer names) in the SVG
                KeepMetadata = true,
                // Use ODG-specific rasterization options
                VectorRasterizationOptions = new OdgRasterizationOptions()
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}