// HOW-TO: Resize JPEG to 800x600 and Apply Magic Wand Selection in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(800, 600, ResizeType.NearestNeighbourResample);

                int pointX = image.Width / 2;
                int pointY = image.Height / 2;

                MagicWandTool.Select(image, new MagicWandSettings(pointX, pointY) { Threshold = 40 })
                    .Apply();

                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to downscale high‑resolution photos to a standard 800×600 size before extracting a region with a magic‑wand tool for further editing.
 * 2. When an automated batch process must prepare user‑uploaded JPEGs for web thumbnails and then isolate a specific area based on color similarity using a threshold of 40.
 * 3. When building a C# application that selects the central object of an image after resizing it to reduce memory usage and improve selection speed.
 * 4. When creating a server‑side service that receives large JPEG files, resizes them, applies a magic‑wand selection for background removal, and returns the edited JPEG.
 * 5. When integrating Aspose.Imaging into a workflow that requires consistent image dimensions and precise region selection for downstream computer‑vision or reporting tasks.
 */
