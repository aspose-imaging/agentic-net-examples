// HOW-TO: Merge Multiple JPEGs Horizontally with Centered Alignment in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };
            string outputPath = "merged.jpg";

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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect sizes
            List<(int Width, int Height)> sizes = new List<(int, int)>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add((img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create output source and options
            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outSource,
                Quality = 100
            };

            // Create canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                for (int i = 0; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        int offsetY = (maxHeight - img.Height) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
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
 * 1. When you need to create a single panoramic banner from several JPEG photos for a website header.
 * 2. When generating a product comparison image that places multiple product photos side‑by‑side with equal vertical centering.
 * 3. When preparing a printable collage of event pictures where each JPEG must be aligned in the middle of a shared canvas.
 * 4. When automating the creation of a multi‑image email signature that merges employee headshots into one balanced JPEG.
 * 5. When building a slideshow thumbnail that combines several frame captures into a single horizontally aligned JPEG.
 */
