// HOW-TO: Convert BMP Image to Lossless WebP in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
                string outputPath = "output/output.webp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new WebPOptions
                    {
                        Lossless = true
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
 * 1. When you need to reduce the file size of legacy BMP assets while preserving exact pixel data for web delivery, you can convert them to lossless WebP using C# and Aspose.Imaging.
 * 2. When a game developer wants to batch‑process sprite sheets stored as BMP and store them as WebP to improve loading speed without visual degradation, this code provides the conversion.
 * 3. When an e‑commerce platform must generate high‑quality product thumbnails from BMP source files for browsers that support WebP, the snippet shows how to perform the lossless conversion in .NET.
 * 4. When a document‑management system archives scanned BMP images and wants to store them in a more efficient WebP format while keeping the original quality intact, the example demonstrates the required steps.
 * 5. When a mobile app backend receives BMP uploads and needs to serve them as WebP to reduce bandwidth, this C# routine converts and saves the images losslessly to an output folder.
 */
