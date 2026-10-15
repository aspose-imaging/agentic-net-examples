// HOW-TO: Rotate JPEG Images 90 Degrees Clockwise and Merge Vertically in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var files = Directory.GetFiles(inputDirectory)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found.");
                return;
            }

            List<Size> sizes = new List<Size>();

            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (Image img = Image.Load(file))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    RasterImage rImg = (RasterImage)img;
                    sizes.Add(new Size(rImg.Width, rImg.Height));
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var file in files)
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        return;
                    }

                    using (Image img = Image.Load(file))
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        RasterImage rImg = (RasterImage)img;
                        Rectangle bounds = new Rectangle(0, offsetY, rImg.Width, rImg.Height);
                        canvas.SaveArgb32Pixels(bounds, rImg.LoadArgb32Pixels(rImg.Bounds));
                        offsetY += rImg.Height;
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
 * 1. When you need to correct the orientation of a batch of portrait photos taken sideways and combine them into a single scrolling image for a web gallery.
 * 2. When you want to create a tall composite JPEG from multiple scanned receipts that were scanned in landscape mode.
 * 3. When an e‑commerce site must display a series of product photos as one continuous vertical banner after rotating them to match the site layout.
 * 4. When a reporting tool has to generate a single JPEG report by stacking rotated screenshots taken from a mobile device.
 * 5. When a digital signage system requires a vertical strip of rotated advertisement images merged into one high‑quality JPEG file.
 */
