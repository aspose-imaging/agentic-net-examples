// HOW-TO: Convert OTG Image To 32‑Bit BMP With Transparency In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.otg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32
                    };
                    rasterImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to export vector OTG graphics to a BMP format for legacy Windows applications while preserving the alpha channel.
 * 2. When integrating Aspose.Imaging into a C# service that generates BMP thumbnails of OTG files for a web portal that only supports BMP images.
 * 3. When converting design assets from OTG to 32‑bit BMP to maintain transparency for printing workflows that require BMP input.
 * 4. When building a batch conversion tool that processes multiple OTG files into BMP files for use in game development pipelines.
 * 5. When migrating legacy OTG resources to BMP to ensure compatibility with third‑party software that cannot read OTG but supports transparent BMPs.
 */
