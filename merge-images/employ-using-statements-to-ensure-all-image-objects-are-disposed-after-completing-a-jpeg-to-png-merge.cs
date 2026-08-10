// HOW-TO: Merge JPEG and PNG Horizontally into a PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string jpegPath = "input.jpg";
        string pngPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Validate input files
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }
            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of input images
            List<Size> sizes = new List<Size>();
            using (RasterImage img = (RasterImage)Image.Load(jpegPath))
            {
                sizes.Add(img.Size);
            }
            using (RasterImage img = (RasterImage)Image.Load(pngPath))
            {
                sizes.Add(img.Size);
            }

            // Calculate canvas dimensions (horizontal merge)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create PNG canvas bound to the output file
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;

                // Draw JPEG onto canvas
                using (RasterImage img = (RasterImage)Image.Load(jpegPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                // Draw PNG onto canvas
                using (RasterImage img = (RasterImage)Image.Load(pngPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                }

                // Save the merged image (bound canvas)
                canvas.Save();
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
 * 1. When you need to combine a product photo in JPEG format with a transparent logo in PNG format into a single image for web display.
 * 2. When generating side‑by‑side before‑after comparisons by merging a JPEG screenshot with a PNG overlay.
 * 3. When creating composite marketing banners that stitch a high‑resolution JPEG background with a PNG watermark.
 * 4. When automating batch processing to convert mixed‑format assets into a unified PNG canvas for consistent downstream pipelines.
 * 5. When building a reporting tool that places a JPEG chart next to a PNG icon and saves the result as a PNG file.
 */
