// HOW-TO: Merge Multiple Images Horizontally Into a JPEG With Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = { "input1.jpg", "input2.png", "input3.bmp" };
        string outputPath = "output/merged.jpg";

        try
        {
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int totalWidth = 0;
            int maxHeight = 0;

            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    totalWidth += img.Width;
                    if (img.Height > maxHeight)
                        maxHeight = img.Height;
                }
            }

            Source src = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = src, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(options, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
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
 * 1. When you need to combine several photos of different formats into a single side‑by‑side JPEG for a web gallery.
 * 2. When an application must generate a composite image from user‑uploaded pictures while ensuring the output folder exists.
 * 3. When you want to create a high‑quality JPEG collage from PNG and BMP files and handle missing files gracefully.
 * 4. When a batch process has to stitch product images together for a catalog and must catch file‑access errors.
 * 5. When you are building a reporting tool that merges chart images into one JPEG and needs robust exception handling.
 */
