// HOW-TO: Merge Multiple JPEGs Vertically and Strip Metadata in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.jpg";

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int newWidth = sizes.Max(s => s.Width);
            int newHeight = sizes.Sum(s => s.Height);

            JpegOptions options = new JpegOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (JpegImage canvas = (JpegImage)Image.Create(options, newWidth, newHeight))
            {
                int offsetY = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                canvas.ExifData = null;
                canvas.Jfif = null;
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
 * 1. When you need to combine several JPEG photos into a single vertical strip for a web gallery while minimizing file size by removing EXIF and JFIF data.
 * 2. When preparing product images for an e‑commerce site, you can merge variant shots and strip metadata to comply with privacy policies and improve page load speed.
 * 3. When generating printable photo collages in a desktop application, removing metadata ensures the final JPEG contains only the pixel data needed for printing.
 * 4. When sending merged screenshots via email, stripping metadata reduces the attachment size and prevents accidental leakage of device information.
 * 5. When creating image assets for a mobile app, merging JPEGs and clearing metadata helps meet app store size limits and protects user privacy.
 */
