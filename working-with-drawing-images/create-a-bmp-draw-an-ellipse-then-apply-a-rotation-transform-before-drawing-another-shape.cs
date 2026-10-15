// HOW-TO: Create BMP With Rotated Rectangle And Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "Output\\result.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (BmpOptions options = new BmpOptions())
            {
                options.Source = new FileCreateSource(outputPath, false);
                using (Image image = Image.Create(options, 400, 300))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen pen1 = new Pen(Color.Blue, 3);
                    Rectangle ellipseRect = new Rectangle(50, 50, 200, 150);
                    graphics.DrawEllipse(pen1, ellipseRect);

                    graphics.RotateTransform(45f);

                    Pen pen2 = new Pen(Color.Red, 3);
                    Rectangle rect = new Rectangle(100, 100, 150, 100);
                    graphics.DrawRectangle(pen2, rect);

                    image.Save();
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
 * 1. When you need to generate a BMP report image that includes a highlighted ellipse and a rotated rectangle for a dashboard.
 * 2. When creating custom icons or UI assets where shapes must be drawn at specific angles using Aspose.Imaging in C#.
 * 3. When programmatically adding geometric annotations to a bitmap, such as marking regions with an ellipse and a rotated rectangle for medical imaging.
 * 4. When automating the production of printable graphics that require precise shape placement and rotation without using GDI+ directly.
 * 5. When building a server‑side service that returns BMP thumbnails with overlaid rotated shapes for document preview.
 */
