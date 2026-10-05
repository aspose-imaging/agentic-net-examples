// HOW-TO: Resize JPEG2000 Image to Half Size and Save as Interlaced PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.jp2";
        string outputPath = "Output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                PngOptions options = new PngOptions();

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
 * 1. When you need to generate smaller preview thumbnails from high‑resolution JPEG2000 files for web galleries.
 * 2. When a medical imaging system must convert large JP2 scans into interlaced PNGs to stream progressively in a browser.
 * 3. When a document processing pipeline requires downsampling JP2 images before embedding them into PDF reports.
 * 4. When an e‑commerce site wants to reduce bandwidth by resizing product JP2 photos and delivering them as PNGs with interlacing.
 * 5. When a mobile app needs to load JP2 assets, shrink them to fit screen dimensions, and store them as PNGs for fast rendering.
 */
