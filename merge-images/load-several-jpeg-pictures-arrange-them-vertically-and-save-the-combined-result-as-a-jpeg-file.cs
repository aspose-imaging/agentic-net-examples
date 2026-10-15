// HOW-TO: Combine Multiple JPEG Images Vertically Into a Single JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "output/combined.jpg";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            foreach (string inputPath in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int maxWidth = widths.Max();
            int totalHeight = heights.Sum();

            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
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
 * 1. When you need to create a photo strip or collage by stacking several JPEG photos one on top of another for printing or web display.
 * 2. When generating a single image that contains sequential screenshots or scanned pages saved as JPEGs for documentation or reporting.
 * 3. When building a thumbnail strip for a product gallery where each product photo is a separate JPEG that must appear in a vertical list.
 * 4. When preprocessing images for a machine‑learning pipeline that expects one tall JPEG containing all training samples stacked vertically.
 * 5. When merging daily camera snapshots taken throughout the day into one continuous JPEG timeline for archival or monitoring purposes.
 */
