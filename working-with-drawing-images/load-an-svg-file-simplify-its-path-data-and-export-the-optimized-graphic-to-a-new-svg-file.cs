using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options (required for SVG export)
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Prepare SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
                // Additional options (e.g., compression) could be set here if needed
            };

            // Save the (potentially simplified) SVG to the output path
            image.Save(outputPath, svgOptions);
        }
    }
}