// HOW-TO: Create BMP with Ten Evenly Spaced Vertical Lines in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;
            int lineCount = 10;
            int spacing = width / (lineCount + 1);

            BmpOptions options = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 1);

                for (int i = 1; i <= lineCount; i++)
                {
                    int x = i * spacing;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

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
 * 1. When you need to generate a simple grid overlay on a BMP for a UI mockup.
 * 2. When you want to programmatically add ruler marks to a bitmap for a printing preview.
 * 3. When creating test images with known line patterns to validate image analysis algorithms.
 * 4. When producing a barcode‑like background by drawing evenly spaced vertical lines on a BMP file.
 * 5. When automating the creation of placeholder graphics for documentation or reports using Aspose.Imaging in C#.
 */
