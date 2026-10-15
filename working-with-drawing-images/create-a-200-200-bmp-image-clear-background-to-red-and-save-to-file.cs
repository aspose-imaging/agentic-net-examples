// HOW-TO: Create a 200x200 Red BMP Image and Save in C# (Aspose.Imaging for .NET)
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

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "output/output.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                BmpOptions options = new BmpOptions();
                options.Source = new FileCreateSource(outputPath, false);
                using (Image image = Image.Create(options, 200, 200))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.FromArgb(255, 255, 0, 0));
                    image.Save();
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
 * 1. When you need to generate a solid‑color placeholder BMP file for testing image‑processing pipelines in a C# application.
 * 2. When a desktop utility must programmatically create a red thumbnail bitmap to indicate error status in a UI.
 * 3. When an automated report generator requires a fixed‑size red BMP watermark to overlay on scanned documents.
 * 4. When a game engine needs a simple red texture file to use as a fallback asset during development.
 * 5. When a batch script creates a red background BMP as a base layer before compositing other graphics with Aspose.Imaging.
 */
