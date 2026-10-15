// HOW-TO: Shift Drawing Origin with TranslateTransform and Draw Shapes on BMP in C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
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

                graphics.TranslateTransform(50, 30);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, 0, 0, 200, 100);
                graphics.DrawEllipse(pen, 0, 0, 200, 100);

                using (SolidBrush brush = new SolidBrush(Color.LightGreen))
                {
                    graphics.FillRectangle(brush, 0, 0, 200, 100);
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
 * 1. When you need to create a BMP report thumbnail and offset all graphics by a margin without manually adjusting each shape’s coordinates.
 * 2. When generating a printable form where the logo and decorative elements must start at a specific offset from the page edge using Aspose.Imaging.
 * 3. When building a game asset pipeline that requires drawing multiple sprites on a bitmap canvas with a common origin shift for consistent alignment.
 * 4. When creating a custom watermark that should appear 50 pixels right and 30 pixels down from the top‑left corner of a BMP image.
 * 5. When programmatically producing diagrammatic illustrations (rectangles, ellipses, filled areas) on a bitmap and you want to simplify positioning by translating the coordinate system once.
 */
