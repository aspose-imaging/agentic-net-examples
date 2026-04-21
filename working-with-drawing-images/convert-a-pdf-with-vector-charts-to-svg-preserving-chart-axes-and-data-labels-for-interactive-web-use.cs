using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Data\chart.pdf";
        string outputPath = @"C:\Data\chart.svg";

        // Verify that the input PDF exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document (vector image)
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization to match the source page size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set SVG export options – render text as shapes to keep labels
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