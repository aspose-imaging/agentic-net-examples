// HOW-TO: Convert EMF Metafile To SVG With External Image References In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var svgOptions = new SvgOptions())
                {
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
 * 1. When a developer needs to embed vector graphics from a Windows Metafile (EMF) into a web page as scalable SVG while keeping linked raster images separate for faster loading.
 * 2. When converting legacy design assets stored as EMF into SVG format for use in modern UI frameworks that require external image files.
 * 3. When generating SVG reports from EMF charts and want the raster components to be stored as separate image files to reduce SVG file size.
 * 4. When automating a batch process that transforms EMF icons into SVG icons while preserving external image references for easier asset management.
 * 5. When integrating Aspose.Imaging into a C# application to programmatically convert EMF drawings to SVG for cross‑platform compatibility without embedding large bitmap data.
 */
