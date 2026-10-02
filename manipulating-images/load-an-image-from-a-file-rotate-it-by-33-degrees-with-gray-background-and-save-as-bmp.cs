// HOW-TO: Rotate JPEG By 33 Degrees With Gray Background And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.bmp";

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

                image.Rotate(33f, true, Color.FromArgb(255, 128, 128, 128));

                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to display a rotated version of a photo in a desktop application that only supports BMP files.
 * 2. When preparing images for a legacy printing system that requires BMP format and a specific background color after rotation.
 * 3. When generating thumbnails for a catalog where each image must be rotated by a custom angle and saved with a uniform gray canvas.
 * 4. When converting user‑uploaded JPEGs to BMP for a game engine that cannot handle JPEG metadata and needs a solid background.
 * 5. When automating batch processing of scanned documents that must be rotated to correct orientation and stored as BMP for OCR tools.
 */
