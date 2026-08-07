using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.jpg";
            string canvasPath = "canvas.html";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image jpegImage = Image.Load(inputPath))
            {
                // Save as HTML5 Canvas
                jpegImage.Save(canvasPath, new Html5CanvasOptions
                {
                    // Export full HTML page (default)
                    FullHtmlPage = true,
                    // No special vector rasterization needed for raster source
                });
            }

            // Load the generated HTML5 Canvas file
            using (Image canvasImage = Image.Load(canvasPath))
            {
                // Save back to JPEG
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Preserve quality for size comparison
                };
                canvasImage.Save(outputPath, jpegOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long canvasSize = new FileInfo(canvasPath).Length;
            long finalSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original JPEG size: {originalSize} bytes");
            Console.WriteLine($"HTML5 Canvas file size: {canvasSize} bytes");
            Console.WriteLine($"Re‑exported JPEG size: {finalSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to generate an interactive web preview of a JPEG photo by converting it to an HTML5 Canvas page and then verify that re‑exporting it back to JPEG does not increase the file size.
 * 2. When a C# application needs to embed raster images in a self‑contained HTML5 Canvas document for email newsletters and must ensure the final JPEG remains within the original bandwidth budget.
 * 3. When performing automated image‑pipeline testing, a developer can use this code to compare the size of the original JPEG with the size after a round‑trip through HTML5 Canvas to detect any unwanted bloat.
 * 4. When building a web‑based photo editor that saves edits as HTML5 Canvas files, the code helps confirm that exporting the canvas back to JPEG preserves quality while keeping the file size comparable to the source.
 * 5. When creating a documentation generator that shows sample images as HTML5 Canvas snippets, the developer can use this routine to validate that the generated canvas HTML does not cause the JPEG output to exceed storage limits.
 */