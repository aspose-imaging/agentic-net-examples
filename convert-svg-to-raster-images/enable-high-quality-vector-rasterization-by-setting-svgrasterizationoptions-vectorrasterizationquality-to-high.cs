// HOW-TO: Convert SVG to PNG with High Quality Vector Rasterization in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a web application must generate pixel‑perfect PNG thumbnails from user‑uploaded SVG logos for display on high‑resolution screens.
 * 2. When an e‑commerce platform needs to convert scalable product illustrations into PNG assets while preserving fine line details for print‑ready catalogs.
 * 3. When a reporting tool creates PDF reports that embed PNG images derived from SVG charts, requiring high‑quality rasterization to avoid visual artifacts.
 * 4. When a desktop utility batch‑processes a folder of SVG icons into PNG files for use in a Windows application that does not support SVG natively.
 * 5. When a mobile app pre‑renders SVG assets to PNG at runtime to improve rendering performance on devices with limited vector support.
 */
