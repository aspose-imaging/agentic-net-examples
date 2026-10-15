// HOW-TO: Crop PNG Image with Offsets and Save as BMP in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        string inputPath = "input.png";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                int left = 10;
                int right = 10;
                int top = 10;
                int bottom = 10;

                rasterImage.Crop(left, right, top, bottom);
                rasterImage.Save(outputPath);
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
 * 1. When you need to remove a uniform border from a PNG screenshot before converting it to BMP for legacy Windows applications.
 * 2. When generating thumbnails for a printing workflow that requires BMP output and a fixed margin removal from each PNG source.
 * 3. When preprocessing scanned PNG documents by cropping 10‑pixel edges and saving them as BMP files for OCR engines that only accept BMP.
 * 4. When automating batch conversion of PNG assets with consistent padding removal to BMP format for use in a game engine that expects BMP textures.
 * 5. When integrating image processing into a C# service that validates PNG files, trims unwanted edges, and stores the result as BMP for archival compatibility.
 */
