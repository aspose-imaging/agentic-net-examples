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
            // Prepare SVG export options
            var svgOptions = new SvgOptions();

            // Configure OTG rasterization options to preserve page size (sets viewBox correctly)
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size // ensures viewBox matches the original dimensions
            };

            // Assign rasterization options to SVG options
            svgOptions.VectorRasterizationOptions = otgRasterOptions;

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}