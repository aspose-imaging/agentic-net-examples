// HOW-TO: Convert ODG to PNG with Anti‑Aliasing Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
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
 * 1. When you need to generate high‑quality PNG thumbnails from OpenDocument graphics (ODG) for web previews, ensuring smooth edges with anti‑aliasing.
 * 2. When converting ODG diagrams to PNG for inclusion in PDF reports, and you want the rasterized output to retain visual fidelity.
 * 3. When automating batch processing of ODG files in a C# application and require consistent background color and anti‑aliased rendering.
 * 4. When integrating Aspose.Imaging into a document management system to display ODG content as PNG images without jagged lines.
 * 5. When preparing ODG artwork for mobile apps where PNG assets must be anti‑aliased to look crisp on high‑resolution screens.
 */
