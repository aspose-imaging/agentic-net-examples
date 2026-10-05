// HOW-TO: Add Light Gray Background to Raster Image and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/output.svg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.LightGray,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a JPEG photograph into an SVG document with a uniform light‑gray canvas for consistent web rendering.
 * 2. When generating printable graphics where the original raster image must be converted to vector‑friendly SVG while ensuring a background color for PDF export.
 * 3. When creating thumbnails for a UI that require SVG format with a neutral background to match the application theme.
 * 4. When preprocessing images for responsive web design, converting them to scalable SVG with a light‑gray backdrop to avoid transparent gaps.
 * 5. When automating batch conversion of product photos to SVG for an e‑commerce catalog, adding a light gray background to maintain visual consistency.
 */
