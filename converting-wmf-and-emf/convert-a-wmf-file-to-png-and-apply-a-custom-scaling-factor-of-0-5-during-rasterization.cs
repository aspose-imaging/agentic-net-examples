// HOW-TO: Convert WMF to PNG with 50% Scaling in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                // Get original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Apply scaling factor of 0.5
                int scaledWidth = (int)(originalWidth * 0.5);
                int scaledHeight = (int)(originalHeight * 0.5);

                var rasterizationOptions = new WmfRasterizationOptions
                {
                    PageWidth = scaledWidth,
                    PageHeight = scaledHeight,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to embed a vector WMF logo into a web page as a smaller PNG thumbnail.
 * 2. When generating printable reports that require WMF diagrams resized to half their original size for PDF inclusion.
 * 3. When creating email attachments that must be PNG images with reduced dimensions to meet size limits.
 * 4. When migrating legacy WMF assets to a modern image format while automatically scaling them for mobile app displays.
 * 5. When processing batch conversions of WMF icons to PNG sprites with a consistent 0.5 scaling factor for UI design.
 */
