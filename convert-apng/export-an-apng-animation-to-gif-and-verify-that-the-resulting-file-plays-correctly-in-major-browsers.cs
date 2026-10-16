// HOW-TO: Convert APNG Animation to GIF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace ApngToGifConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.apng";
                string outputPath = "output.gif";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Load the APNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as GIF using appropriate options
                    var gifOptions = new GifOptions
                    {
                        // Preserve animation frames if needed (default behavior)
                    };
                    image.Save(outputPath, gifOptions);
                }

                Console.WriteLine($"Successfully converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When you need to serve animated images on browsers that only support GIF, you can convert APNG files to GIF using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform stores product animations as APNG but the email marketing system only accepts GIF, this code enables batch conversion.
 * 3. When a game developer wants to reuse existing APNG sprite animations in a legacy UI that only renders GIF, the snippet provides a quick conversion.
 * 4. When a content management system must generate thumbnail previews of animated assets and store them as GIF for compatibility, this approach automates the process.
 * 5. When a mobile app backend receives user‑uploaded APNG files and must deliver them as GIF to ensure playback across all major browsers, the code handles the conversion safely.
 */
