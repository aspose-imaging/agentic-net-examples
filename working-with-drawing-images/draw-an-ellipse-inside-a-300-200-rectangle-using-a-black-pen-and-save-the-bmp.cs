// HOW-TO: Create BMP Image With Black Ellipse Inside 300x200 Rectangle In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/ellipse.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, 300, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black);
                Rectangle rect = new Rectangle(0, 0, 300, 200);
                graphics.DrawEllipse(pen, rect);

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
 * 1. When you need to generate a simple BMP graphic containing a centered ellipse for a report or UI element.
 * 2. When automating the creation of placeholder images with a specific size and shape for testing image pipelines.
 * 3. When producing black‑on‑white vector shapes in BMP format for legacy systems that only accept bitmap files.
 * 4. When dynamically drawing geometric shapes like ellipses in a server‑side C# application without using GDI+.
 * 5. When creating custom icons or stamps that require a fixed 300 × 200 pixel canvas with an ellipse outline.
 */
