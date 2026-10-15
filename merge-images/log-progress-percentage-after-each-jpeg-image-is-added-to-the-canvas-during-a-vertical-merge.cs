// HOW-TO: Log Progress While Vertically Merging Multiple JPEG Images in C# (Aspose.Imaging for .NET)
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
using System.Collections.Generic;
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
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            var imagePaths = jpgFiles.Concat(jpegFiles).ToArray();

            if (imagePaths.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            foreach (var path in imagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int canvasWidth = widths.Max();
            int canvasHeight = heights.Sum();

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                for (int i = 0; i < imagePaths.Length; i++)
                {
                    string path = imagePaths[i];
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }

                    int percent = (i + 1) * 100 / imagePaths.Length;
                    Console.WriteLine($"Progress: {percent}% ({i + 1}/{imagePaths.Length})");
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
 * 1. When you need to combine a series of JPEG photos into a single tall image for a catalog or report and want to display the merge percentage in the console using Aspose.Imaging for .NET.
 * 2. When building an automated tool that creates a vertical banner from multiple JPEG advertisements and requires progress logging to monitor each image addition.
 * 3. When generating a vertical sprite sheet from game asset JPEG files and need to track how far the merging process has progressed.
 * 4. When stitching together sequential security‑camera JPEG snapshots into one timeline image and want real‑time feedback on the merging status.
 * 5. When developing a batch image processor that assembles scanned JPEG pages into a single document‑style image and needs to report the percentage completed after each page is added.
 */
