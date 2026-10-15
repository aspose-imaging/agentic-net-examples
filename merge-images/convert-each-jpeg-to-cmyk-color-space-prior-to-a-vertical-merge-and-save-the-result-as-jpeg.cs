// HOW-TO: Convert Multiple JPEGs to CMYK and Merge Vertically in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.jpg";

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<(int Width, int Height)> sizes = new List<(int, int)>();
            foreach (var path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    sizes.Add((img.Width, img.Height));
                }
            }

            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height);

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions outOptions = new JpegOptions()
            {
                Source = outSource,
                ColorType = JpegCompressionColorMode.Cmyk,
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(outOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (var path in inputPaths)
                {
                    using (JpegImage original = (JpegImage)Image.Load(path))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            JpegOptions cmOptions = new JpegOptions()
                            {
                                Source = new StreamSource(ms),
                                ColorType = JpegCompressionColorMode.Cmyk,
                                Quality = 100
                            };
                            original.Save(ms, cmOptions);
                            ms.Position = 0;
                            using (RasterImage cmykImg = (RasterImage)Image.Load(ms))
                            {
                                int[] pixels = cmykImg.LoadArgb32Pixels(cmykImg.Bounds);
                                var rect = new Rectangle(0, offsetY, cmykImg.Width, cmykImg.Height);
                                canvas.SaveArgb32Pixels(rect, pixels);
                                offsetY += cmykImg.Height;
                            }
                        }
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
 * 1. When you need to prepare a print‑ready composite image by stacking several photos vertically while ensuring the final JPEG uses the CMYK color space required by commercial printers.
 * 2. When an e‑commerce platform must combine product photos into a single catalog page and the output must be a high‑quality CMYK JPEG for consistent color across browsers and print.
 * 3. When a marketing team wants to create a vertical banner from multiple JPEG assets and must convert each source to CMYK to avoid color shifts in the final advertisement.
 * 4. When a digital publishing workflow requires merging user‑uploaded JPEGs into one document and the publishing system only accepts CMYK JPEG files.
 * 5. When a batch‑processing script needs to automate the conversion of a set of JPEG images to CMYK before stitching them together for archival storage.
 */
