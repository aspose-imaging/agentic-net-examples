// HOW-TO: Convert APNG Animation to Animated GIF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

namespace ApngToGifConverter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            try
            {
                using (ApngImage apng = (ApngImage)Image.Load(inputPath))
                {
                    GifOptions options = new GifOptions();
                    apng.Save(outputPath, options);
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert the APNG to an animated GIF while preserving the original frame sequence using C# and Aspose.Imaging.
 * 2. When a web application must generate lightweight GIF previews from user‑uploaded APNG files, this code provides a simple way to perform the conversion on the server side.
 * 3. When a game developer wants to reuse existing APNG sprite animations in a legacy engine that only reads GIF frames, the sample shows how to keep the animation timing intact.
 * 4. When an email marketing system requires animated content in GIF format but receives assets as APNG, the snippet converts them automatically in a .NET workflow.
 * 5. When a desktop utility needs to batch‑process APNG files into GIFs for archival or sharing purposes, this example demonstrates the core conversion logic you can loop over multiple files.
 */
