// HOW-TO: Convert OTG Vector Image to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.Transparent,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

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
 * 1. When you need to display an OTG logo on a website without a background, you can convert it to a PNG with transparency using Aspose.Imaging in C#.
 * 2. When generating printable PDFs that require overlaying vector graphics, you may first convert OTG files to transparent PNGs for easy raster handling.
 * 3. When building a desktop application that imports OTG icons and saves them as PNG assets for UI themes, preserving the transparent background is essential.
 * 4. When automating a batch process that extracts OTG diagrams from a repository and converts them to PNGs for inclusion in documentation, maintaining transparency ensures the diagrams blend with various background colors.
 * 5. When creating a game asset pipeline that needs vector artwork in OTG format converted to PNG sprites with an alpha channel intact, this code provides a reliable C# solution.
 */
