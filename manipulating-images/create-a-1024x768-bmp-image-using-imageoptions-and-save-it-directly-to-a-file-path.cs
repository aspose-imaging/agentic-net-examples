// HOW-TO: Create 1024x768 BMP Image With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(options, 1024, 768))
            {
                canvas.Save();
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
 * 1. When you need to generate a blank BMP canvas of a specific size for a reporting tool that later overlays charts or text.
 * 2. When an automated batch process must create placeholder bitmap files for testing image‑processing pipelines.
 * 3. When a desktop application requires programmatic creation of a BMP file to be used as a texture in a game engine.
 * 4. When a server‑side service must produce a BMP image on the fly to embed in a PDF generated with Aspose.PDF.
 * 5. When you want to initialize a BMP file at a known path before populating it with pixel data from a camera feed.
 */
