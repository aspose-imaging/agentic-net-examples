// HOW-TO: Convert PNG to Scalable SVG with Custom Viewbox in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            string inputPath = Path.Combine(inputDirectory, "sample.png");
            string outputPath = Path.Combine(outputDirectory, "output.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = 800,
                        PageHeight = 600,
                        BackgroundColor = Color.White
                    };
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a high‑resolution PNG into a web page as a scalable SVG with a defined 800×600 viewbox.
 * 2. When generating printable graphics from raster assets and you require a white background in the resulting SVG.
 * 3. When automating batch conversion of product photos to vector format for responsive UI layouts in a C# application.
 * 4. When creating SVG placeholders from existing bitmap logos while preserving exact dimensions for design tools.
 * 5. When integrating Aspose.Imaging into a .NET service that transforms uploaded images into SVG files with custom page size settings.
 */
