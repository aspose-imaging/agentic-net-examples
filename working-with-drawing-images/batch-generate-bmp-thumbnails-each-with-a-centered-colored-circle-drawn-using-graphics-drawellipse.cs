// HOW-TO: Create BMP Thumbnails with Centered Circle Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            var imageFiles = Directory.GetFiles(inputFolder)
                .Where(f => new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff", ".webp" }
                .Contains(Path.GetExtension(f).ToLowerInvariant()))
                .ToArray();

            foreach (var inputPath in imageFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached) image.CacheData();

                    const int maxWidth = 150;
                    const int maxHeight = 150;
                    float scale = Math.Min((float)maxWidth / image.Width, (float)maxHeight / image.Height);
                    int thumbWidth = (int)(image.Width * scale);
                    int thumbHeight = (int)(image.Height * scale);

                    image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    Graphics graphics = new Graphics(image);
                    int radius = Math.Min(thumbWidth, thumbHeight) / 4;
                    int ellipseX = (thumbWidth - radius * 2) / 2;
                    int ellipseY = (thumbHeight - radius * 2) / 2;
                    Pen pen = new Pen(Color.Red, 3);
                    graphics.DrawEllipse(pen, ellipseX, ellipseY, radius * 2, radius * 2);

                    BmpOptions bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a set of small BMP preview images from a mixed collection of JPEG, PNG, GIF, or TIFF files for a gallery view, this code resizes each file to a 150 × 150 thumbnail.
 * 2. When an application must add a visual marker, such as a colored circle, to every thumbnail for branding or status indication, the Graphics.DrawEllipse call draws the circle at the center of each image.
 * 3. When processing large batches of images on a server, the code caches image data and uses Aspose.Imaging’s raster handling to avoid memory leaks while creating BMP outputs.
 * 4. When you want to automate conversion of user‑uploaded images to a uniform BMP format for legacy systems that only accept BMP files, the routine handles all common input formats automatically.
 * 5. When a desktop or web tool requires consistent thumbnail dimensions and a decorative overlay for each picture, this solution provides a single C# method to resize, draw, and save the results in one pass.
 */
