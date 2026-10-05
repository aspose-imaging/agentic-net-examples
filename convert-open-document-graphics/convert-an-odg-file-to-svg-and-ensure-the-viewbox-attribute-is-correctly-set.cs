// HOW-TO: Convert ODG to SVG with Proper ViewBox in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new SvgOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
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

/*
 * Real-World Use Cases:
 * 1. When you need to embed an OpenDocument graphic into a web page and require the SVG’s viewBox to match the original ODG dimensions.
 * 2. When automating a batch process that converts legacy ODG illustrations to scalable SVG files for responsive design.
 * 3. When generating SVG assets from ODG drawings in a C# application while preserving background color and exact page size.
 * 4. When integrating Aspose.Imaging into a .NET service that transforms user‑uploaded ODG files into web‑ready SVG with correct scaling.
 * 5. When creating a build pipeline that validates ODG files and outputs SVGs with accurate viewBox attributes for downstream vector editing tools.
 */
