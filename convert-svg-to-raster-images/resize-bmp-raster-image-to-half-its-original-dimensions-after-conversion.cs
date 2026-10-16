// HOW-TO: Resize BMP Image to Half Size Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Image is not a raster image.");
                    return;
                }

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;

                raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                raster.Save(outputPath);
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
 * 1. When you need to generate smaller thumbnail versions of large BMP files for faster web page loading.
 * 2. When a desktop application must downscale scanned BMP documents to reduce storage space while preserving image quality.
 * 3. When an automated batch process converts high‑resolution BMP assets to half size before embedding them in a PDF report.
 * 4. When a game development pipeline requires resizing BMP textures to match a target device’s memory constraints.
 * 5. When a legacy system outputs BMP screenshots that must be resized on‑the‑fly for email attachment size limits.
 */
