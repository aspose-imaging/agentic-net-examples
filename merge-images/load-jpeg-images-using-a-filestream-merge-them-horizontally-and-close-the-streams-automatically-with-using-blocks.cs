// HOW-TO: Merge Multiple JPEG Images Horizontally Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load images, collect sizes
            List<JpegImage> images = new List<JpegImage>();
            int totalWidth = 0;
            int maxHeight = 0;

            foreach (string inputPath in inputPaths)
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    JpegImage img = (JpegImage)Image.Load(fs);
                    images.Add(img);
                    totalWidth += img.Width;
                    if (img.Height > maxHeight)
                        maxHeight = img.Height;
                }
            }

            // Create output canvas
            JpegOptions options = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(options, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (JpegImage img in images)
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                // Save the merged image
                canvas.Save();
            }

            // Dispose loaded images
            foreach (JpegImage img in images)
            {
                img.Dispose();
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
 * 1. When you need to create a single panoramic JPEG by stitching multiple product photos side‑by‑side using Aspose.Imaging in C#.
 * 2. When you want to combine several scanned receipt JPEGs into one horizontal image for easier archival or email attachment.
 * 3. When generating a side‑by‑side comparison of before‑and‑after JPEG images in a medical imaging workflow with automatic stream handling.
 * 4. When assembling multiple screenshot JPEGs into one composite image for a bug report or documentation without manual editing.
 * 5. When preparing a wide‑format printable banner by merging several JPEG sections horizontally in a .NET application.
 */
