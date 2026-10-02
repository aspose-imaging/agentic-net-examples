// HOW-TO: Render SVG to Transparent PNG at 300 DPI Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/vector.svg";
        string outputPath = "Output/rendered.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When you need to display scalable vector graphics on a website that only supports raster PNG images with a transparent background.
 * 2. When generating high‑resolution product thumbnails from SVG logos for print‑ready catalogs that require 300 DPI images.
 * 3. When converting user‑uploaded SVG icons into lossless PNG assets for a mobile app that demands a fixed DPI and alpha channel.
 * 4. When preparing transparent PNG overlays from vector diagrams for video compositing or slide presentations.
 * 5. When automating batch processing of SVG assets to create consistent 300 DPI PNG files for a digital asset management system.
 */
