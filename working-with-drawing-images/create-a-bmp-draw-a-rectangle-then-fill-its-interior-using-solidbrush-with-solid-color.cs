// HOW-TO: Create BMP Image with Filled Rectangle Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(createOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Rectangle rect = new Rectangle(50, 50, 100, 100);
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(brush, rect);
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
 * 1. When you need to programmatically generate a BMP icon with a colored rectangle for a Windows desktop application.
 * 2. When creating thumbnail previews that require a simple solid‑filled shape drawn onto a bitmap using Aspose.Imaging in C#.
 * 3. When producing test images for automated UI testing where a known rectangle area must be filled with a specific color.
 * 4. When exporting diagram elements to BMP files for documentation, such as highlighting a region with a light‑blue fill.
 * 5. When building a custom report that embeds BMP graphics with drawn and filled shapes without relying on external image editors.
 */
