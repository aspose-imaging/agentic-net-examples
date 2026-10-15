// HOW-TO: Create Larger Canvas and Center JPEG Images Vertically in C# (Aspose.Imaging for .NET)
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
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
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

            // Collect sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int totalHeight = sizes.Sum(s => s.Height);
            int maxWidth = sizes.Max(s => s.Width);

            // Add padding to create a larger canvas
            int padding = 50;
            int canvasWidth = maxWidth + padding * 2;
            int canvasHeight = totalHeight + padding * 2;

            // Create output source and options
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 100 };

            // Create canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Fill canvas with white background
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                int offsetY = padding;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetX = (canvasWidth - img.Width) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the final image
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
 * 1. When you need to generate a single photo collage that stacks multiple JPEGs vertically with equal white borders around the combined image.
 * 2. When preparing product catalog pages where each product photo must be centered on a uniform background before being merged into one tall image.
 * 3. When creating printable banners that require all source JPEGs aligned in the center of a larger canvas with consistent padding.
 * 4. When automating the generation of email newsletters that embed several JPEGs in a single vertically merged image with a white margin.
 * 5. When developing a reporting tool that combines scanned JPEG documents into one continuous image while maintaining a centered layout and extra whitespace.
 */
