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
            string inputPath = "Input\\input.svg";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.BackgroundColor = Aspose.Imaging.Color.Transparent;
                rasterOptions.PageSize = svgImage.Size;
                rasterOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;
                pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web developer needs to convert scalable SVG icons into high‑resolution 300 DPI PNG files with a transparent background for retina‑ready UI assets.
 * 2. When a desktop application must render vector logos from SVG files into lossless PNG images for printing brochures at 300 DPI while preserving transparency.
 * 3. When an e‑learning platform generates thumbnail previews of SVG diagrams as PNGs at 300 DPI to embed in course materials without background artifacts.
 * 4. When a mobile game pipeline requires converting SVG sprites into 300 DPI PNG textures with anti‑aliased edges and transparent backgrounds for optimal rendering.
 * 5. When an automated reporting tool rasterizes SVG charts into high‑resolution PNG images at 300 DPI to include in PDF reports while keeping the background transparent.
 */