// HOW-TO: Export High Resolution Photo to HTML5 Canvas Scaled for 1920x1080 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\HighResPhoto.jpg";
            string outputPath = @"C:\Images\ExportedCanvas.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate scaling factor to fit within 1920x1080 while preserving aspect ratio
                double widthScale = 1920.0 / image.Width;
                double heightScale = 1080.0 / image.Height;
                double scale = Math.Min(widthScale, heightScale);
                if (scale < 1.0) // Downscale only if larger than viewport
                {
                    int newWidth = (int)(image.Width * scale);
                    int newHeight = (int)(image.Height * scale);
                    image.Resize(newWidth, newHeight);
                }

                // Prepare HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true,
                    // For raster images a default rasterization option is sufficient
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                // Save as HTML5 Canvas
                image.Save(outputPath, canvasOptions);
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
 * 1. When you need to embed a large JPEG photograph in a web page using an HTML5 canvas that fits a standard 1920x1080 screen without distortion.
 * 2. When you want to automatically downscale high‑resolution images on the server before sending them to browsers to reduce bandwidth and improve load times.
 * 3. When you are building a C# application that converts raster photos to a self‑contained HTML file with canvas rendering for offline viewing.
 * 4. When you must preserve the original aspect ratio while resizing images to match a specific viewport size for responsive design.
 * 5. When you require a simple way to generate HTML5 canvas markup from images using Aspose.Imaging without manually handling rasterization settings.
 */
