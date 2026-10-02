// HOW-TO: Set SVG Resolution to 300 DPI When Converting to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.svg";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;

                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };

                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to generate high‑resolution PNG thumbnails from SVG logos for print‑ready marketing materials.
 * 2. When a web service must deliver PNG images with a consistent 300 DPI for PDF embedding.
 * 3. When an automated build pipeline converts SVG icons to PNG assets while preserving exact dimensions and DPI.
 * 4. When a desktop application rasterizes user‑uploaded SVG diagrams to PNG for accurate on‑screen display at a specific resolution.
 * 5. When batch processing a folder of SVG files to produce PNGs that match a predefined printing resolution.
 */
