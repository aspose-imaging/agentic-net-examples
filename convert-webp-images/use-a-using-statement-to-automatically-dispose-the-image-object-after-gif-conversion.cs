// HOW-TO: Convert PNG to GIF in C# with Automatic Image Disposal (Aspose.Imaging for .NET)
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

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.png";
                string outputPath = "output/output.gif";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new GifOptions();
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
 * 1. When you need to generate animated or static GIF thumbnails from user‑uploaded PNG files in a web application while ensuring the Image object is released promptly.
 * 2. When a batch job must convert a folder of PNG assets to GIF format for email newsletters, using Aspose.Imaging to handle the conversion and a using block to manage resources.
 * 3. When integrating image processing into a Windows service that reads PNG configuration icons and saves them as GIFs for legacy systems, and you want automatic disposal to avoid memory leaks.
 * 4. When building a console utility that validates the existence of source PNG files, creates the output directory, and converts them to GIFs with minimal code and safe resource handling.
 * 5. When troubleshooting image conversion errors, you need a try‑catch wrapper around the PNG‑to‑GIF conversion that logs failures and guarantees the Image instance is disposed even on exceptions.
 */
