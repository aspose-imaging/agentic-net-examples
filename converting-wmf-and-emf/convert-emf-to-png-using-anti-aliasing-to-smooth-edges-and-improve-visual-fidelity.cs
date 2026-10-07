// HOW-TO: Convert EMF to PNG with Anti‑Aliasing Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.emf";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PngOptions options = new PngOptions();
                    options.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                    };

                    image.Save(outputPath, options);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Windows desktop application needs to export vector‑based EMF diagrams as high‑quality PNG thumbnails for UI previews.
 * 2. When a reporting tool must embed EMF charts into web pages and requires anti‑aliased PNG images to avoid jagged edges on different browsers.
 * 3. When a batch conversion service processes legacy EMF assets and wants smooth, white‑background PNG files for use in mobile apps.
 * 4. When a document generation pipeline converts EMF logos to PNG with text rendering hints to maintain readability at small sizes.
 * 5. When an automated build script creates PNG assets from EMF source files and needs anti‑aliasing to improve visual fidelity in marketing materials.
 */
