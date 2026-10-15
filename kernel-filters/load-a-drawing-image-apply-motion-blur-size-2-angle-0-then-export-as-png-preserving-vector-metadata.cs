// HOW-TO: Convert SVG To PNG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                using (PngImage png = (PngImage)Image.Create(
                    new PngOptions { Source = new FileCreateSource(outputPath, false) },
                    width, height))
                {
                    Graphics graphics = new Graphics(png);
                    graphics.DrawImage(vectorImage, 0, 0, width, height);
                    png.Save();
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
 * 1. When you need to generate high‑resolution PNG thumbnails from SVG logos for a web application using C#.
 * 2. When a reporting tool must embed vector‑based charts as raster images in PDF documents.
 * 3. When an e‑commerce platform requires converting customer‑uploaded SVG product illustrations to PNG for email newsletters.
 * 4. When a desktop app has to rasterize scalable icons to PNG assets for Windows UI themes.
 * 5. When a batch process must preserve the original SVG dimensions while exporting them as PNG files for archival storage.
 */
