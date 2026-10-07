// HOW-TO: Resize PNG Image with High Quality Bicubic Scaling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage src = (RasterImage)Image.Load(inputPath))
            {
                int targetWidth = src.Width * 2;
                int targetHeight = src.Height * 2;

                using (Image dest = Image.Create(new PngOptions(), targetWidth, targetHeight))
                {
                    Graphics graphics = new Graphics(dest);
                    graphics.Clear(Color.White);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(src, new Rectangle(0, 0, targetWidth, targetHeight));

                    dest.Save(outputPath, new PngOptions());
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
 * 1. When you need to double the dimensions of a PNG while preserving visual quality for print‑ready graphics.
 * 2. When generating high‑resolution thumbnails from source images for a web gallery using Aspose.Imaging in C#.
 * 3. When preparing images for machine‑learning training sets that require consistent upscale without pixelation.
 * 4. When converting low‑resolution product photos to larger sizes for e‑commerce catalogs while maintaining smooth edges.
 * 5. When programmatically enlarging scanned documents before applying OCR to improve character recognition accuracy.
 */
