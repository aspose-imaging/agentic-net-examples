using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.pdf";
        string outputPath = @"C:\Temp\output.svg";

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
            // Configure rasterization options with the source image size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG save options; keep text as selectable (TextAsShapes = false)
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                TextAsShapes = false
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}