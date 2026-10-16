// HOW-TO: Convert ODG to BMP With 150 DPI Resolution In C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new BmpOptions
                {
                    ResolutionSettings = new ResolutionSetting(150, 150)
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

/*
 * Real-World Use Cases:
 * 1. When you need to embed a LibreOffice Draw diagram into a Windows application that only accepts BMP images at a specific print quality.
 * 2. When generating thumbnails for archival documents and must ensure each BMP is rendered at 150 DPI for consistent sizing.
 * 3. When automating a batch process that converts ODG vector files to raster BMPs for legacy systems that cannot read ODG.
 * 4. When preparing graphics for a printing workflow that requires BMP files with a defined 150 DPI resolution to match other assets.
 * 5. When creating a server‑side service that receives ODG uploads and returns BMP files with a set DPI for downstream image analysis.
 */
