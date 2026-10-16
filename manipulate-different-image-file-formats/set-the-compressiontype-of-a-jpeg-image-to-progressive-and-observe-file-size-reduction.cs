// HOW-TO: How to Convert JPEG to Progressive JPEG for Smaller File Size in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

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
 * 1. When you need to serve JPEG images on a website that load progressively, reducing perceived load time and bandwidth usage.
 * 2. When you are building a photo‑gallery app that must shrink image file size without sacrificing quality by switching to progressive JPEG compression.
 * 3. When you want to batch‑process existing JPEG files to create progressive versions for faster preview in mobile apps.
 * 4. When you need to comply with a content‑delivery network’s requirement for progressive JPEGs to improve caching efficiency.
 * 5. When you are integrating Aspose.Imaging in a C# backend to automatically optimize uploaded user photos for storage savings.
 */
