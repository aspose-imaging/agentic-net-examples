// HOW-TO: Add a Border Frame to EPS and Export as PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image epsImage = Image.Load(inputPath))
            {
                int borderThickness = 10;
                int newWidth = epsImage.Width + borderThickness * 2;
                int newHeight = epsImage.Height + borderThickness * 2;

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image canvas = Image.Create(pngOptions, newWidth, newHeight))
                {
                    var graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(epsImage, new Rectangle(borderThickness, borderThickness, epsImage.Width, epsImage.Height));

                    Pen pen = new Pen(Color.Black, borderThickness);
                    graphics.DrawRectangle(pen, new Rectangle(borderThickness / 2, borderThickness / 2, epsImage.Width + borderThickness, epsImage.Height + borderThickness));

                    canvas.Save();
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
 * 1. When you need to convert an EPS vector file to a lossless PNG with a uniform black border for web thumbnails using Aspose.Imaging in C#.
 * 2. When preparing print‑ready EPS artwork for a PDF report and require a surrounding frame before exporting as PNG.
 * 3. When generating product catalog images where each EPS logo must have a consistent margin and be saved as a high‑quality PNG.
 * 4. When automating batch processing of EPS diagrams to add a visual border before uploading the PNGs to a content‑management system.
 * 5. When creating email attachments that need EPS graphics displayed with a white background and a black outline in PNG format.
 */
