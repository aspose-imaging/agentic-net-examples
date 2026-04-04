using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Input\sample.pdf";
        string outputPath = @"C:\Output\sample.pdf.svg";

        // Verify that the input PDF exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                // Render all text as vector shapes to keep editability
                TextAsShapes = true,
                // Set rasterization options; page size matches the source PDF size
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the PDF as an SVG file, preserving vector layers
            image.Save(outputPath, svgOptions);
        }
    }
}