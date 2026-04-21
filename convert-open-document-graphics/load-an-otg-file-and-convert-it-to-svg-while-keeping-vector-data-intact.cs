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
            // Configure OTG rasterization options – keep original page size
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG export options and attach the rasterization options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = otgRasterOptions,
                // Preserve vector data (default behavior); TextAsShapes left as false
                TextAsShapes = false
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}