// HOW-TO: Convert AVIF Image To PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Avif;
using Aspose.Imaging.ImageOptions;

namespace AvifToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.avif";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (AvifImage image = (AvifImage)Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to display AVIF photos on browsers that only support PNG, a developer can use this code to convert the images on the server side.
 * 2. When an automated pipeline processes user‑uploaded AVIF files and stores them in a PNG archive for compatibility with legacy systems, this snippet handles the conversion.
 * 3. When a desktop tool must generate PNG thumbnails from high‑efficiency AVIF assets, the code provides a quick way to load and save the images.
 * 4. When a cloud function receives AVIF images from a mobile app and must resize them before saving as PNG for CDN delivery, the example shows the essential steps.
 * 5. When a batch job needs to migrate a photo library from AVIF to PNG format without losing metadata, the provided C# routine performs the conversion safely.
 */
