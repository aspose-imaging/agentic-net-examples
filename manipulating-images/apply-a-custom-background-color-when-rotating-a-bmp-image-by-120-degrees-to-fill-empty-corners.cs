// HOW-TO: Rotate BMP Image 120 Degrees with Custom Background Color in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Rotate(120f, true, Aspose.Imaging.Color.FromArgb(255, 200, 200, 200));

                FileCreateSource source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

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
 * 1. When you need to display a BMP graphic at a non‑standard angle and want the empty corners filled with a specific color to match your UI theme.
 * 2. When generating thumbnails for a game asset pipeline where BMP sprites are rotated and the background must remain consistent.
 * 3. When processing scanned documents saved as BMP files that require a 120° rotation and a neutral background to avoid black corners in printed output.
 * 4. When creating custom map tiles in a GIS application that rotate BMP layers and need a defined background color to blend with adjacent tiles.
 * 5. When automating batch image preparation for a legacy system that only accepts BMP files, and each image must be rotated and padded with a chosen color before upload.
 */
