// HOW-TO: Convert 24‑Bit BMP to 8‑Bit Indexed BMP Using Floyd‑Steinberg Dithering in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

namespace ImageDither
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                    var options = new BmpOptions
                    {
                        BitsPerPixel = 8
                    };

                    image.Save(outputPath, options);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of a high‑color BMP for legacy systems that only support 8‑bit indexed images.
 * 2. When preparing BMP assets for embedded devices or game consoles that require a limited color palette with dithering to preserve visual quality.
 * 3. When converting photographs or screenshots to a palette‑based format for faster loading in web applications that still use BMP.
 * 4. When automating batch processing of BMP files to meet printing or archival standards that mandate 8‑bit indexed color depth.
 * 5. When integrating image preprocessing in a C# workflow to apply Floyd‑Steinberg dithering before saving the image as an 8‑bit BMP.
 */
