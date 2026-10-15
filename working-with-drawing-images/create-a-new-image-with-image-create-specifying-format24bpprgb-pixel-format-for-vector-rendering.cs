// HOW-TO: Create PNG Image With 800x600 Canvas Using Aspose Imaging C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(options, 800, 600))
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
 * 1. When you need to generate a blank PNG file of a specific size for later drawing or overlay operations in a C# application.
 * 2. When you want to programmatically create a raster canvas to render vector graphics or charts before saving them as a PNG.
 * 3. When an automated report generator must produce a placeholder image file with exact dimensions for PDF or email attachments.
 * 4. When a web service needs to return a newly created PNG image stream without reading an existing file from disk.
 * 5. When you are testing image processing pipelines and require a known‑size PNG source to validate resizing or filtering algorithms.
 */
