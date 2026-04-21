using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.pdf";
        string outputPath = @"C:\Temp\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF (vector image) and convert it to SVG
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options to preserve original size (and line widths)
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                // Disable smoothing to keep line widths exact
                SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
            };

            // Configure SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}