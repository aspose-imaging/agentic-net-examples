// HOW-TO: Create 200x200 JPEG Thumbnail From Large Image Using Memory‑Efficient Loading In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\large.jpg";
            string outputPath = "Output\\thumbnail.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1024 * 1024 }))
            {
                if (!image.IsCached) image.CacheData();

                image.Resize(200, 200, ResizeType.NearestNeighbourResample);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate small preview images for a web gallery without loading the entire high‑resolution JPEG into memory.
 * 2. When processing user‑uploaded photos on a server and want to create low‑size thumbnails while controlling memory usage.
 * 3. When building a desktop application that displays image thumbnails and must handle very large JPEG files efficiently.
 * 4. When creating product catalog thumbnails from high‑resolution product photos while preserving JPEG quality.
 * 5. When automating batch image processing to produce consistent 200×200 thumbnails for mobile app assets.
 */
