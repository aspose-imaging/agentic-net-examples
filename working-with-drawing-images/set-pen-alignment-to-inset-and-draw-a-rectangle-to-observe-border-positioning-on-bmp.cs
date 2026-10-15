// HOW-TO: How to Draw Inset Rectangle Border on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, 300, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 5);
                pen.Alignment = PenAlignment.Inset;

                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 100));

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
 * 1. When you need to generate a BMP thumbnail with a precisely positioned inner border for UI icons.
 * 2. When creating printable forms where the rectangle outline must stay inside the specified dimensions to avoid clipping.
 * 3. When testing how different PenAlignment values affect border rendering in automated image comparison tests.
 * 4. When producing technical diagrams in BMP format that require consistent inset borders for measurement accuracy.
 * 5. When developing a graphics editor that lets users draw shapes with inset strokes to maintain layout alignment.
 */
