// HOW-TO: Convert TGA Image To PNG With Alpha Transparency In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    CompressionLevel = 9,
                    ColorType = PngColorType.TruecolorWithAlpha
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
 * 1. When a game developer needs to export legacy TGA textures with transparency to PNG for use in modern engines.
 * 2. When a UI designer wants to batch‑convert TGA assets to lossless PNG files while keeping the alpha channel for web deployment.
 * 3. When a photo‑processing service must compress TGA screenshots into PNG with maximum compression without losing transparent backgrounds.
 * 4. When an automation script has to verify the existence of a TGA file and safely generate a PNG version with Aspose.Imaging in a .NET application.
 * 5. When a cross‑platform tool requires converting raster images from TGA to PNG while preserving true‑color with alpha for further image analysis.
 */
