// HOW-TO: Draw Diagonal Orange Line on 600x600 BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(bmpOptions, 600, 600))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Pen orangePen = new Pen(Color.Orange, 5);
                graphics.DrawLine(orangePen, 0, 0, 599, 599);
                image.Save();
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
 * 1. When you need to generate a simple 600 × 600 BMP placeholder image with a visible diagonal orange line for testing image pipelines in a C# application.
 * 2. When adding a custom orange watermark line to BMP assets before converting them to PNG or JPEG using Aspose.Imaging.
 * 3. When creating diagnostic graphics that highlight the image’s diagonal axis by drawing a line with the Graphics.DrawLine overload.
 * 4. When automating thumbnail sketches that require a solid colored line to indicate direction or progress on a bitmap canvas.
 * 5. When building a quick visual cue for UI components that need an orange line across a BMP without manually editing the file.
 */
