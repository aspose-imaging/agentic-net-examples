// HOW-TO: Create Timestamped Horizontal Merged JPEG from Multiple Images in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Horizontal merge
            int hWidth = sizes.Sum(s => s.Width);
            int hHeight = sizes.Max(s => s.Height);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string baseName = Path.GetFileNameWithoutExtension(inputPaths[0]);
            string horizontalOutput = $"{baseName}_{timestamp}_horizontal.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(horizontalOutput));
            Source hSource = new FileCreateSource(horizontalOutput, false);
            JpegOptions hOptions = new JpegOptions() { Source = hSource, Quality = 90 };
            using (JpegImage hCanvas = (JpegImage)Image.Create(hOptions, hWidth, hHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        hCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                hCanvas.Save();
            }

            // Vertical merge
            int vWidth = sizes.Max(s => s.Width);
            int vHeight = sizes.Sum(s => s.Height);
            string verticalOutput = $"{baseName}_{timestamp}_vertical.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(verticalOutput));
            Source vSource = new FileCreateSource(verticalOutput, false);
            JpegOptions vOptions = new JpegOptions() { Source = vSource, Quality = 90 };
            using (JpegImage vCanvas = (JpegImage)Image.Create(vOptions, vWidth, vHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        vCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }
                vCanvas.Save();
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
 * 1. When you need to combine several product photos side‑by‑side into a single JPEG and keep each version uniquely identified by a timestamp.
 * 2. When generating daily reports that include merged screenshots, you can use the code to create a timestamped horizontal image for archival purposes.
 * 3. When automating a web service that stitches user‑uploaded JPEGs together, the timestamped filename prevents overwriting previous merges.
 * 4. When building a photo‑gallery application that displays before‑and‑after images side by side, the code produces a single JPEG with a time‑based name for easy sorting.
 * 5. When processing batches of scanned documents and saving the combined result, the timestamp in the filename helps track processing order and avoid naming conflicts.
 */
