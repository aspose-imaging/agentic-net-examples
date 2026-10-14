// HOW-TO: How To Save JPEG As PSD With Error Handling In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                try
                {
                    image.Save(outputPath, psdOptions);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error saving PSD: {ex.Message}");
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
 * 1. When you need to convert user‑uploaded JPEG images to Photoshop PSD files while ensuring any file‑system or format errors are logged.
 * 2. When an automated image‑processing pipeline must create editable PSD layers from JPEG sources and gracefully handle missing input files.
 * 3. When building a desktop application that lets users export pictures to PSD format and you want to capture save‑operation exceptions for troubleshooting.
 * 4. When integrating Aspose.Imaging into a server‑side service that generates PSD previews from JPEG thumbnails and must avoid crashes on invalid paths.
 * 5. When performing batch conversion of JPEG assets to PSD in a scheduled job and you require reliable error reporting for each conversion step.
 */
