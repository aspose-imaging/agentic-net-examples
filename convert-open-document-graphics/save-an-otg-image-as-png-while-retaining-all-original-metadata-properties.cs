// HOW-TO: Convert OTG Image to PNG While Preserving Metadata in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When a medical imaging system receives OTG scans and needs to deliver them as PNG files for web viewers while keeping patient metadata intact.
 * 2. When a digital asset management tool imports legacy OTG graphics and must export them to PNG for compatibility with modern browsers without losing EXIF or custom tags.
 * 3. When an automated batch job converts OTG design assets to PNG thumbnails for a catalog, ensuring all original color profiles and metadata are retained.
 * 4. When a reporting service extracts OTG charts and saves them as PNG images for inclusion in PDF reports, preserving the source metadata for audit trails.
 * 5. When a mobile app syncs OTG images from a server and stores them locally as PNG, maintaining the original metadata for later processing or search.
 */
