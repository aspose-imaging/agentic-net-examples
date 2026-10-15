// HOW-TO: Merge Multiple JPEG Images Vertically with 10 Pixel Padding in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files
            string[] imagePaths = Directory.GetFiles(inputDirectory, "*.jpg");

            if (imagePaths.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Validate each input file
            foreach (string path in imagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            const int padding = 10;
            List<Size> sizes = new List<Size>();

            // Collect sizes
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height) + padding * (sizes.Count - 1);

            // Create output JPEG canvas
            FileCreateSource src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (string path in imagePaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height + padding;
                    }
                }

                // Save the merged image
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
 * 1. When you need to create a single tall photo strip from a series of JPEG screenshots for a product brochure.
 * 2. When generating a continuous scrolling banner where each JPEG segment must be separated by a visible gap to improve readability.
 * 3. When assembling scanned receipts into one image while keeping a consistent 10‑pixel space between each receipt.
 * 4. When preparing a composite image for a mobile app that displays user‑uploaded JPEGs stacked vertically with uniform padding.
 * 5. When automating the creation of a timeline graphic where each event’s JPEG icon is placed below the previous one with a small separator.
 */
