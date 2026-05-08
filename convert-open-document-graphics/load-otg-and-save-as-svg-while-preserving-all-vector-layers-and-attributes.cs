using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify that the input OTG file exists
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
                // Prepare SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve original metadata (optional but keeps attributes)
                    KeepMetadata = true
                };

                // Configure vector rasterization for SVG output
                var vectorOptions = new SvgRasterizationOptions
                {
                    // Use the source image size to keep original dimensions
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = vectorOptions;

                // Save as SVG, preserving vector layers and attributes
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}