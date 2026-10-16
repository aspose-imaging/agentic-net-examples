// HOW-TO: Export EMF to PNG with Custom DPI Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.emf");
            string outputPath = Path.Combine("Output", "image.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                const int dpiX = 300;
                const int dpiY = 300;

                PngOptions options = new PngOptions();
                options.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);
                options.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
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
 * 1. When you need to convert vector EMF diagrams to high‑resolution PNG files for inclusion in print‑ready PDFs.
 * 2. When a reporting tool generates charts as EMF and you must rasterize them at 300 dpi for web display.
 * 3. When an automated batch process must standardize legacy EMF assets to PNG with a specific DPI for a digital asset management system.
 * 4. When a desktop application requires exporting user‑drawn EMF graphics to PNG while preserving size and setting a white background.
 * 5. When migrating a Windows Forms application’s icons from EMF to PNG with consistent resolution for high‑DPI monitors.
 */
