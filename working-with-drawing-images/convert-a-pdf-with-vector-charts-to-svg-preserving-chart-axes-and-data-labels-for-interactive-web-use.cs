using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.pdf";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG rasterization options to match the source size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set SVG save options; render text as shapes to preserve labels and axes
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                TextAsShapes = true
            };

            // Save the PDF as an SVG file
            image.Save(outputPath, svgOptions);
        }
    }
}