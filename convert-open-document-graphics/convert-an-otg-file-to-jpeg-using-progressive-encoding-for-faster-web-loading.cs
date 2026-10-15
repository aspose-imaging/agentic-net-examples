// HOW-TO: Convert OTG to Progressive JPEG for Faster Web Loading in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive
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
 * 1. When you need to display high‑resolution OTG graphics on a website and want the images to load progressively for a better user experience.
 * 2. When a content management system stores artwork in OTG format and you must generate web‑friendly JPEGs on the fly using C#.
 * 3. When you are building an e‑commerce platform that requires product images converted from OTG to JPEG with progressive compression to reduce bandwidth.
 * 4. When automating a batch process that converts legacy OTG files to progressive JPEGs for mobile app delivery using Aspose.Imaging.
 * 5. When you need to integrate OTG‑to‑JPEG conversion into a .NET service that creates thumbnails with fast loading characteristics for SEO.
 */
