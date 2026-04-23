using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary file for intermediate rasterization
        string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load SVG and rasterize to PNG (color)
        using (Image svgImage = Image.Load(inputPath))
        {
            // Set rasterization options based on SVG size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // PNG save options with rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized PNG to temporary file
            svgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply grayscale, and save to final output
        using (PngImage pngImage = new PngImage(tempPngPath))
        {
            pngImage.Grayscale();
            pngImage.Save(outputPath);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}