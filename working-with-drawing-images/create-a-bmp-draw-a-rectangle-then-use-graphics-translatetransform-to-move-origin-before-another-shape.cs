// HOW-TO: Create BMP with Translated Rectangle Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            int width = 400;
            int height = 300;
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 100));
                graphics.TranslateTransform(100, 100);
                graphics.DrawRectangle(pen, new Rectangle(0, 0, 150, 80));
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
 * 1. Use this code to programmatically generate a BMP file and draw multiple rectangles with precise positioning using Aspose.Imaging in C#.
 * 2. Apply the TranslateTransform method to shift the drawing origin, allowing you to add additional shapes without manually adjusting each coordinate.
 * 3. Create annotated graphics for reports or dashboards by drawing shapes on a bitmap and saving the result as a BMP image.
 * 4. Build simple diagrams or UI mock‑ups by layering rectangles at different offsets within a fixed‑size BMP canvas.
 * 5. Export design layouts to BMP format for legacy applications that require static bitmap assets generated from C# code.
 */
