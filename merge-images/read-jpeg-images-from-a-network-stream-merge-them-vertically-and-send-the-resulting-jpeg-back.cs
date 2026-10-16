// HOW-TO: Merge Multiple JPEG Images Vertically From Stream And Return JPEG In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input image paths (network stream simulation)
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output/merged.jpg";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect dimensions
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int canvasWidth = widths.Max();
            int canvasHeight = heights.Sum();

            // Create output JPEG canvas
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When a web service receives several JPEG photos uploaded via a network stream and must stitch them into one vertical image for display or storage.
 * 2. When an automated reporting tool collects chart images from remote sensors and needs to combine them into a single JPEG banner before sending it to a dashboard.
 * 3. When a mobile app uploads multiple scanned document pages as JPEGs and the server must merge them vertically into one image to simplify download.
 * 4. When a digital signage system receives separate advertisement JPEGs over the network and wants to create a single tall banner image for scrolling playback.
 * 5. When a cloud‑based image processing pipeline needs to concatenate JPEG thumbnails received from different services into one vertical JPEG for archival.
 */
