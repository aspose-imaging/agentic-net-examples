// HOW-TO: Apply Grayscale Color Matrix to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
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

            // Temporary file for intermediate PNG rasterization
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG and rasterize to temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions(); // default rasterization options
                var pngSaveOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPngPath, pngSaveOptions);
            }

            // Load the rasterized PNG, apply grayscale, and save to final output
            using (PngImage pngImage = (PngImage)Image.Load(tempPngPath))
            {
                pngImage.Grayscale(); // Convert to grayscale
                pngImage.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a black‑and‑white version of a vector logo by converting an SVG file to a grayscale PNG for printing or web display.
 * 2. When you must transform user‑uploaded SVG icons into grayscale PNG thumbnails to match a dark UI theme in a C# application.
 * 3. When a reporting tool requires all chart images to be grayscale, so you convert the source SVG charts to grayscale PNGs using Aspose.Imaging.
 * 4. When you want to preprocess SVG diagrams for OCR or image‑analysis pipelines that accept only grayscale raster images, converting them to PNG first.
 * 5. When you need to store vector graphics as compact grayscale PNG files for mobile apps that cannot render SVG directly.
 */
