// HOW-TO: Convert SVG to 16‑Bit PNG with Anti‑Aliasing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions()
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                var pngOptions = new PngOptions()
                {
                    BitDepth = 16,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to render an SVG logo at its original size into a lossless 16‑bit PNG for print‑ready graphics while preserving smooth edges.
 * 2. When a web application must generate high‑color‑depth PNG thumbnails from user‑uploaded vector illustrations with anti‑aliasing to avoid jagged lines.
 * 3. When a desktop tool converts technical diagrams stored as SVG into true‑color PNG files with alpha channel for inclusion in documentation PDFs.
 * 4. When an automated build pipeline creates asset bundles, converting vector UI assets to 16‑bit PNGs to ensure consistent visual quality across devices.
 * 5. When a reporting service transforms SVG charts into high‑resolution PNG images for archival storage, requiring precise color depth and smoothing.
 */
