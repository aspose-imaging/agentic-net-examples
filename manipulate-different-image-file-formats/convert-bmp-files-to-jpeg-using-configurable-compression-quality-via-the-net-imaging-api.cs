// HOW-TO: Convert BMP to JPEG with Adjustable Quality in C# (Aspose.Imaging for .NET)
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

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output.jpg";
                int quality = 75;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = quality
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of high‑resolution BMP screenshots for web publishing by saving them as JPEG with a specific compression level.
 * 2. When a batch process must transform legacy BMP assets into JPEG format while preserving visual quality by setting the desired quality factor.
 * 3. When integrating image conversion into a C# desktop application that receives BMP uploads and stores them as compressed JPEGs for storage optimization.
 * 4. When preparing product catalog images originally in BMP for e‑commerce platforms that require JPEG files with controlled compression to meet size limits.
 * 5. When automating a migration of a document management system that stores BMP scans, converting them to JPEG with configurable quality to balance clarity and bandwidth.
 */
