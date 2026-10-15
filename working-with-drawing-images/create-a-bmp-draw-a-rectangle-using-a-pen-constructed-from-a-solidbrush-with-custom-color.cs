// HOW-TO: Create BMP Image and Draw Colored Rectangle with Pen in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 0, 0)))
                {
                    Pen pen = new Pen(brush, 5);
                    Rectangle rect = new Rectangle(20, 20, 160, 160);
                    graphics.DrawRectangle(pen, rect);
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
 * 1. When you need to generate a BMP file with a solid‑color rectangle border for a UI thumbnail.
 * 2. When you want to add a custom‑colored frame around a scanned document before saving it as a BMP image.
 * 3. When creating test images for computer‑vision models that require a known rectangle shape drawn with a Pen and SolidBrush.
 * 4. When producing graphics for a Windows Forms application that loads BMP resources with a specific size and colored rectangle overlay.
 * 5. When automating batch processing to overlay a red rectangle on multiple images for watermarking or annotation using Aspose.Imaging in C#.
 */
