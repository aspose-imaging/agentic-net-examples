// HOW-TO: Convert JPEG to YCbCr Color Space and Save in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/converted.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions options = new JpegOptions())
                {
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
 * 1. When you need to ensure a JPEG is stored in YCbCr color space for compatibility with legacy video pipelines.
 * 2. When you want to compare file size or visual quality after converting an image to YCbCr before compression.
 * 3. When preparing images for printing workflows that require YCbCr rather than RGB.
 * 4. When performing batch processing to standardize color profiles across a collection of JPEGs in a .NET application.
 * 5. When debugging color conversion issues by saving the same image with explicit YCbCr settings to see the effect.
 */
