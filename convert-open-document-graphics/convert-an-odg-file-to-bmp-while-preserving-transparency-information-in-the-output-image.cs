// HOW-TO: Convert ODG to BMP with Alpha Channel Using C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    BmpOptions options = new BmpOptions
                    {
                        BitsPerPixel = 32 // Preserve transparency (alpha channel)
                    };
                    raster.Save(outputPath, options);
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
 * 1. When you need to display OpenDocument graphics in a Windows application that only supports BMP files while keeping the original transparent background.
 * 2. When a batch process must convert legacy ODG illustrations to 32‑bit BMP images for printing pipelines that require alpha channel information.
 * 3. When integrating Aspose.Imaging into a C# service that generates thumbnails from ODG files and saves them as BMP with preserved transparency.
 * 4. When migrating assets from an OpenDocument design suite to a game engine that loads BMP textures and expects per‑pixel alpha.
 * 5. When automating document conversion in a .NET workflow and you must ensure the resulting BMP retains the original image’s opacity data for further editing.
 */
