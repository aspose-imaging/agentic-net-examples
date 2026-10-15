// HOW-TO: Merge multiple JPEGs horizontally with 5 pixel border in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input image paths
            string[] inputPaths = new string[]
            {
                "Input/image1.jpg",
                "Input/image2.jpg",
                "Input/image3.jpg"
            };

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output path
            string outputPath = "Output/merged_with_border.jpg";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect sizes of all images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size for horizontal merge
            int mergedWidth = sizes.Sum(s => s.Width);
            int mergedHeight = sizes.Max(s => s.Height);

            // Add border of 5 pixels on each side
            int border = 5;
            int canvasWidth = mergedWidth + border * 2;
            int canvasHeight = mergedHeight + border * 2;

            // Create output source and options
            var source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            // Create canvas
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = border;
                foreach (string path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, border, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image
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
 * 1. When you need to create a single panoramic view from several JPEG photos and want a consistent 5‑pixel frame around the combined image.
 * 2. When generating product catalogs where each product image is placed side‑by‑side and a uniform border is required for visual separation.
 * 3. When preparing social‑media graphics that stitch multiple screenshots together and need a thin border to match branding guidelines.
 * 4. When automating the creation of printable banners that combine several JPEG panels and must include a margin for trimming.
 * 5. When building a web service that receives multiple JPEG uploads, merges them horizontally, and returns the result with a fixed border for consistent UI layout.
 */
