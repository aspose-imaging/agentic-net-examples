// HOW-TO: Convert JPEG2000 to JPEG with Color Inversion and 85% Quality in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
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
            string inputPath = "Input/input.jp2";
            string outputPath = "Output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image image = (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1048576 }))
            {
                RasterImage raster = image;
                var rect = new Rectangle(0, 0, raster.Width, raster.Height);
                int[] pixels = raster.LoadArgb32Pixels(rect);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    int alpha = argb & unchecked((int)0xFF000000);
                    int rgb = argb & 0x00FFFFFF;
                    int invertedRgb = (~rgb) & 0x00FFFFFF;
                    pixels[i] = alpha | invertedRgb;
                }
                raster.SaveArgb32Pixels(rect, pixels);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to read a large JPEG2000 file into memory, invert its colors, and output a standard JPEG for web display with controlled compression.
 * 2. When a medical imaging application must transform high‑resolution JP2 scans into JPEGs while applying a negative filter for diagnostic review.
 * 3. When an archival system requires batch conversion of JP2 assets to JPEG with a specific 85 % quality setting to balance file size and visual fidelity.
 * 4. When a photo‑editing tool wants to load a JP2 image using a 1 MB buffer hint, manipulate pixel ARGB values, and save the result as a JPEG for compatibility with consumer devices.
 * 5. When a .NET service processes incoming JP2 uploads, applies a color‑inversion effect, and stores the processed image as a JPEG with predefined quality for downstream analytics.
 */
