// HOW-TO: Blend PNG Overlay onto JPEG Background and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string backgroundPath = "background.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "Output/result.png";

            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }

            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                background.Blend(new Point(0, 0), overlay, 255);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                background.Save(outputPath, pngOptions);
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
 * 1. When you need to add a transparent PNG logo or watermark onto a photographic JPEG and output a combined PNG for web use.
 * 2. When you want to create product mock‑ups by overlaying design assets onto background photos in a .NET application.
 * 3. When you must generate composite images for email newsletters, merging a PNG badge onto a JPEG banner before sending.
 * 4. When you are building a reporting tool that combines chart PNGs with scanned JPEG documents into a single PNG file.
 * 5. When you need to programmatically apply a PNG overlay to a JPEG for a mobile app’s splash screen while preserving transparency.
 */
