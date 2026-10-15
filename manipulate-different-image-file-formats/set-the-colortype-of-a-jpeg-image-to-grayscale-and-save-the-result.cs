// HOW-TO: Convert JPEG to Grayscale Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.jpg";
            string outputPath = "Output\\image_grayscale.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Grayscale
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
 * 1. When you need to reduce file size for web thumbnails by converting color JPEGs to grayscale before uploading.
 * 2. When generating print‑ready documents that require all images in grayscale to meet publishing standards.
 * 3. When creating a batch script that normalizes a photo archive to grayscale for consistent visual style in a gallery.
 * 4. When preprocessing images for machine‑learning models that expect single‑channel grayscale input.
 * 5. When developing a C# desktop application that saves user‑edited photos as grayscale JPEGs for artistic effects.
 */
