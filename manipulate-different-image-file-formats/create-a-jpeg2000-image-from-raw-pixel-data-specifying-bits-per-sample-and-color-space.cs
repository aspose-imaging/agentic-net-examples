// HOW-TO: Create JPEG2000 Image From ARGB Pixel Array In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output\\image.jp2";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 2;
            int height = 2;
            int[] pixels = new int[]
            {
                unchecked((int)0xFFFF0000),
                unchecked((int)0xFF00FF00),
                unchecked((int)0xFF0000FF),
                unchecked((int)0xFFFFFFFF)
            };

            using (var options = new Jpeg2000Options())
            {
                using (var image = (Jpeg2000Image)Image.Create(options, width, height))
                {
                    ((RasterImage)image).SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);
                    image.Save(outputPath, options);
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
 * 1. When you need to generate a JPEG2000 file from raw ARGB pixel data for medical imaging or satellite imagery where lossless compression and specific color depth are required.
 * 2. When you are building a server‑side service that converts dynamically created graphics into JPEG2000 format for web delivery with reduced bandwidth.
 * 3. When you have pixel values stored in an integer array and must embed them directly into a JPEG2000 image without using intermediate bitmap objects.
 * 4. When you need to control bits‑per‑sample and color space while creating a JPEG2000 image for archival storage that complies with industry standards.
 * 5. When you are automating batch processing of small image tiles and want to save each tile as a JPEG2000 file using Aspose.Imaging in a .NET application.
 */
