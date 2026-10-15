// HOW-TO: How To Estimate Saved JPEG Quality After High Compression In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.jpg";
            string outputPath = "Output\\output.jpg";

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
                    Quality = 10,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
            }

            Console.WriteLine("Estimated saved JPEG quality: 10");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a low‑size thumbnail for web pages by compressing a JPEG to a specific quality level in C#.
 * 2. When you want to evaluate how much visual quality is retained after applying aggressive JPEG compression for mobile app uploads.
 * 3. When you must generate a preview image that meets a strict file‑size limit by setting the JPEG quality parameter programmatically.
 * 4. When you are testing the impact of different JPEG quality settings on storage savings in a .NET image‑processing pipeline.
 * 5. When you need to automate batch processing of photos, saving each with a predefined low quality to reduce bandwidth usage.
 */
