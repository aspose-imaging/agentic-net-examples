using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(inputPath))
            {
                PngOptions overlayOptions = new PngOptions();
                using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, 100, 100))
                {
                    Color[] redPixels = new Color[100 * 100];
                    for (int i = 0; i < redPixels.Length; i++)
                    {
                        redPixels[i] = Color.Red;
                    }
                    overlay.SavePixels(overlay.Bounds, redPixels);

                    background.Blend(new Point(0, 0), overlay, 128);
                }

                background.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to overlay a semi‑transparent logo onto a PNG background image loaded from a stream and save the composited result to another stream for web delivery.
 * 2. When an application must programmatically generate a colored watermark (e.g., a red square) and blend it with an existing raster image using an alpha value of 128 before exporting to PNG.
 * 3. When a service processes uploaded user images, applies an alpha‑blended overlay to indicate a status badge, and writes the final image to a response stream without touching the file system.
 * 4. When a desktop tool creates a preview thumbnail by loading a source PNG into a RasterImage, blending a custom overlay, and streaming the output PNG to a memory buffer for further processing.
 * 5. When a batch job reads PNG files, adds a semi‑transparent overlay for branding, and writes the blended images directly to a network stream for storage in a cloud bucket.
 */