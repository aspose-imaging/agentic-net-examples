using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.svg";

        // Verify that the input file exists
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
            // Configure rasterization options for OTG → SVG conversion
            var otgRasterOptions = new OtgRasterizationOptions
            {
                // Preserve the original page size
                PageSize = image.Size
            };

            // Set up SVG save options
            var svgOptions = new SvgOptions
            {
                // Use the OTG rasterization options
                VectorRasterizationOptions = otgRasterOptions,
                // Render all text as shapes to keep appearance consistent across viewers
                TextAsShapes = true,
                // Optional: disable compression to keep the SVG human‑readable
                Compress = false
            };

            // Save the image as SVG with the specified options
            image.Save(outputPath, svgOptions);
        }
    }
}