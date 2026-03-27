using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

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
            var svgOptions = new SvgOptions
            {
                // Preserve original metadata (including layer names)
                KeepMetadata = true,
                // Render text as text (not shapes) to keep original naming where possible
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