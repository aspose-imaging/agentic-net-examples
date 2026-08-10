// HOW-TO: Convert WMF to PNG with Metadata Preservation in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.wmf";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
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
 * 1. When you need to generate high‑resolution PNG thumbnails from legacy WMF vector drawings while keeping the original author and creation date information.
 * 2. When a document‑management system must convert uploaded WMF files to web‑friendly PNGs without losing embedded metadata for audit trails.
 * 3. When automating batch processing of engineering schematics stored as WMF and exporting them as PNGs for inclusion in reports, preserving source metadata.
 * 4. When integrating a C# application with Aspose.Imaging to replace WMF icons with PNG assets while retaining their original metadata for branding consistency.
 * 5. When migrating legacy WMF assets to a modern asset pipeline and require programmatic conversion to PNG that maintains author and timestamp metadata for compliance.
 */
