// HOW-TO: Resize WebP Image From Byte Array To 1024x768 Losslessly In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] imageData = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(ms))
                {
                    image.Resize(1024, 768);
                    WebPOptions options = new WebPOptions
                    {
                        Lossless = true
                    };
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
 * 1. When you need to downscale user‑uploaded WebP photos stored in memory before displaying them on a 1024×768 web page while keeping them lossless.
 * 2. When a server‑side service processes WebP thumbnails received as byte streams and must output high‑quality resized images for PDF generation.
 * 3. When an image‑processing pipeline converts raw WebP data from a database into a standardized 1024×768 size for consistent UI layout without introducing compression artifacts.
 * 4. When you want to batch‑resize WebP assets stored in memory for a mobile app’s asset bundle, ensuring lossless quality for later editing.
 * 5. When integrating Aspose.Imaging into a C# microservice that receives WebP payloads via API, resizes them to a fixed resolution, and saves them losslessly for archival.
 */
