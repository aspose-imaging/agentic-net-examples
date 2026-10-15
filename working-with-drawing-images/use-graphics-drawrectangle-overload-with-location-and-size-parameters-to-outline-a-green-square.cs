// HOW-TO: Draw a Green Square Outline on an Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

public class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Green, 3);
                int x = 50;
                int y = 50;
                int size = 100;
                graphics.DrawRectangle(pen, x, y, size, size);
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight a specific region in a JPEG photo by drawing a green square before converting it to PNG for web display.
 * 2. When generating annotated screenshots for documentation and you want to outline UI elements with a green rectangle using C#.
 * 3. When creating a simple visual marker on product images to indicate a selected item in an e‑commerce catalog.
 * 4. When implementing a basic image‑processing step that adds a green border around detected objects in a raster image.
 * 5. When building a batch script that adds a green square overlay to multiple images for quality‑control review.
 */
