// HOW-TO: Convert DNG to 256-Color GIF with Floyd Steinberg Dithering in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "input.dng";
        string outputPath = "output/output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                GifOptions options = new GifOptions();
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
 * 1. When a developer needs to display raw camera (DNG) photos on a website using a small GIF file with a limited 256‑color palette.
 * 2. When an application must generate static GIF previews of high‑resolution DNG images for email attachments where file size is critical.
 * 3. When a workflow requires converting raw images to a GIF format that legacy systems accept, which only supports indexed colors.
 * 4. When a developer wants to apply Floyd‑Steinberg dithering to preserve visual detail while reducing colors for low‑bandwidth mobile apps.
 * 5. When batch processing raw photos into GIFs is needed to create thumbnails in a digital asset management system.
 */
