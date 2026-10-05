// HOW-TO: Split a BigTIFF image into four PNG quadrants using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "Output";
            string outputPath1 = Path.Combine(outputDir, "quadrant1.png");
            string outputPath2 = Path.Combine(outputDir, "quadrant2.png");
            string outputPath3 = Path.Combine(outputDir, "quadrant3.png");
            string outputPath4 = Path.Combine(outputDir, "quadrant4.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath4));

            using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
            {
                int width = bigTiff.Width;
                int height = bigTiff.Height;
                int halfWidth = width / 2;
                int halfHeight = height / 2;

                var quadrants = new[]
                {
                    new { Rect = new Rectangle(0, 0, halfWidth, halfHeight), Output = outputPath1 },
                    new { Rect = new Rectangle(halfWidth, 0, width - halfWidth, halfHeight), Output = outputPath2 },
                    new { Rect = new Rectangle(0, halfHeight, halfWidth, height - halfHeight), Output = outputPath3 },
                    new { Rect = new Rectangle(halfWidth, halfHeight, width - halfWidth, height - halfHeight), Output = outputPath4 }
                };

                foreach (var q in quadrants)
                {
                    int[] pixels = bigTiff.LoadArgb32Pixels(q.Rect);

                    PngOptions pngOptions = new PngOptions();
                    pngOptions.Source = new FileCreateSource(q.Output, false);

                    using (Image pngImage = Image.Create(pngOptions, q.Rect.Width, q.Rect.Height))
                    {
                        ((RasterImage)pngImage).SaveArgb32Pixels(new Rectangle(0, 0, q.Rect.Width, q.Rect.Height), pixels);
                        pngImage.Save();
                    }
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
 * 1. When processing massive satellite or aerial BigTIFF files you need to break them into smaller PNG tiles for faster web map rendering.
 * 2. When converting high‑resolution medical scans stored as BigTIFF into manageable PNG sections for analysis or display on limited‑memory devices.
 * 3. When generating preview thumbnails of each quadrant of a large engineering drawing saved as BigTIFF for quick visual inspection.
 * 4. When preparing separate image assets from a giant scanned map to feed into a GIS application that only accepts PNG inputs.
 * 5. When creating four equal‑sized PNG segments from a BigTIFF to parallelize image processing tasks across multiple threads or services.
 */
