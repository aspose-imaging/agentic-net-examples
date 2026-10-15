// HOW-TO: Create a Blank 800x600 WebP Image and Save in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.webp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Source source = new FileCreateSource(outputPath, false);
            WebPOptions options = new WebPOptions() { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(options, 800, 600))
            {
                canvas.Save();
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
 * 1. When you need to generate a placeholder WebP file of a specific size for testing image pipelines in a C# application.
 * 2. When an automated report generator must create a blank WebP canvas to overlay dynamic graphics before saving.
 * 3. When a web service creates thumbnails on the fly and requires an empty 800×600 WebP base to compose custom images.
 * 4. When a CI/CD build script validates that the Aspose.Imaging library can produce WebP files with default settings.
 * 5. When a desktop utility needs to initialize a new WebP image file to store user‑drawn sketches programmatically.
 */
