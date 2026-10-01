// HOW-TO: Convert ODG to PNG with Watermark Text Overlay in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");
            string inputPath = Path.Combine(inputDirectory, "sample.odg");
            string outputPath = Path.Combine(outputDirectory, "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
                image.Save(outputPath, pngOptions);
            }

            using (Aspose.Imaging.Image pngImage = Aspose.Imaging.Image.Load(outputPath))
            {
                var graphics = new Aspose.Imaging.Graphics(pngImage);
                var font = new Aspose.Imaging.Font("Arial", 48);
                using (var brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.DrawString("Watermark", font, brush, new Aspose.Imaging.Point(10, 10));
                }
                pngImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a PNG preview of an OpenDocument graphic and brand it with a custom watermark before publishing online.
 * 2. When an automated report system must convert ODG diagrams to PNG thumbnails and embed a copyright notice directly onto the image.
 * 3. When a document management workflow requires batch processing of ODG files into watermarked PNGs for secure distribution to clients.
 * 4. When a C# application has to rasterize vector ODG artwork into a raster PNG while adding promotional text for marketing materials.
 * 5. When you want to programmatically add a visible identifier to ODG‑derived PNGs to prevent unauthorized reuse.
 */
