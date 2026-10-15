// HOW-TO: Merge Multiple JPEG Images Horizontally into a MemoryStream in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            var dimensions = new List<(int width, int height)>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    dimensions.Add((img.Width, img.Height));
                }
            }

            int totalWidth = dimensions.Sum(d => d.width);
            int maxHeight = dimensions.Max(d => d.height);

            JpegOptions jpegOptions = new JpegOptions() { Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
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

                using (MemoryStream ms = new MemoryStream())
                {
                    canvas.Save(ms, jpegOptions);
                    Console.WriteLine($"Merged image saved to memory stream, size: {ms.Length} bytes.");
                }
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
 * 1. When you need to combine product photos side‑by‑side for a web catalog without writing intermediate files.
 * 2. When generating a single JPEG banner from several ad images to embed directly into an email attachment.
 * 3. When creating a panoramic thumbnail from multiple camera shots and sending it over a network stream.
 * 4. When building a server‑side image composition service that returns the merged JPEG as a byte array.
 * 5. When preparing a printable strip of scanned receipts for archival storage using only in‑memory operations.
 */
