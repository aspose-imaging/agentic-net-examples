// HOW-TO: Resize SVG to 300x300 PNG with Lanczos Resampling in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input\\image.svg";
            string outputPath = "Output\\image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 300,
                    PageHeight = 300
                };

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
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
 * 1. When you need to generate a thumbnail PNG of a scalable SVG logo for a web page, preserving quality with Lanczos resampling.
 * 2. When an application must convert user‑uploaded SVG icons into fixed‑size PNG assets for email templates that only support raster images.
 * 3. When a reporting tool requires SVG charts to be embedded as 300 × 300 PNG images in PDF documents.
 * 4. When a mobile app needs to pre‑process vector illustrations into uniformly sized PNG files to reduce runtime rendering overhead.
 * 5. When an e‑commerce platform wants to create product preview images from SVG designs at a specific pixel dimension while maintaining sharpness.
 */
