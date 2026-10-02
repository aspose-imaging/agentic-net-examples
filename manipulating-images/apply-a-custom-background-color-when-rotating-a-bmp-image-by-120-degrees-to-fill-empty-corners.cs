// HOW-TO: Rotate BMP Image 120 Degrees with Custom Background Color in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Color backgroundColor = Color.FromArgb(255, 255, 0, 0);
                image.Rotate(120f, true, backgroundColor);

                BmpOptions saveOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to rotate a BMP graphic by a non‑right‑angle and fill the empty corners with a specific color, such as red, to maintain a consistent background.
 * 2. When preparing legacy BMP assets for a game UI that requires a 120° orientation while preserving a solid background to avoid transparent gaps.
 * 3. When converting scanned BMP documents that must be displayed at an angle and need a uniform background color for printing or PDF generation.
 * 4. When creating custom thumbnails for a photo‑gallery where BMP images are rotated and the empty space must match the site’s branding color.
 * 5. When processing BMP files in an automated pipeline that applies a fixed rotation and ensures the resulting image has a defined background for downstream image‑analysis tools.
 */
