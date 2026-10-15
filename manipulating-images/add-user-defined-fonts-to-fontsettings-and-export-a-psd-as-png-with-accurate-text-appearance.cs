// HOW-TO: Export PSD to PNG with Custom Fonts Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\sample.png";
            string fontsFolder = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (Directory.Exists(fontsFolder))
            {
                FontSettings.SetFontsFolders(new string[] { fontsFolder }, true);
            }

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a web service needs to generate thumbnail PNGs from user‑uploaded PSD files that contain text using fonts not installed on the server.
 * 2. When an automated build pipeline converts design assets to PNG for documentation while preserving the exact typography defined in the original PSD.
 * 3. When a desktop application batch‑processes PSD mockups and must embed corporate brand fonts that reside in a custom folder to keep branding consistent.
 * 4. When a cloud function creates preview images for a digital asset management system and must load external font files to render text accurately.
 * 5. When a migration script moves Photoshop layers to PNG format and requires specifying font directories to avoid missing‑glyph errors during conversion.
 */
