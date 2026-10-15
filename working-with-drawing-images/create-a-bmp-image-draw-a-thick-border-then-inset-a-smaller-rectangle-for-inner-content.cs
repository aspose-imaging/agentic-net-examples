// HOW-TO: Create BMP Image with Thick Border and Inset Rectangle in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 400;
            int height = 300;
            int borderThickness = 20;
            int inset = 30;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen borderPen = new Pen(Color.Black, borderThickness);
                int halfThickness = borderThickness / 2;
                graphics.DrawRectangle(borderPen,
                    halfThickness,
                    halfThickness,
                    width - borderThickness,
                    height - borderThickness);

                using (SolidBrush innerBrush = new SolidBrush(Color.LightGray))
                {
                    int innerX = inset;
                    int innerY = inset;
                    int innerWidth = width - 2 * inset;
                    int innerHeight = height - 2 * inset;
                    graphics.FillRectangle(innerBrush, innerX, innerY, innerWidth, innerHeight);
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
 * 1. When you need to generate a BMP file with a thick black border for a report thumbnail or document preview.
 * 2. When you want to programmatically draw a rectangular frame around a canvas before adding other graphics in C#.
 * 3. When you require a placeholder image that has a light‑gray inner rectangle for UI mock‑ups or layout testing.
 * 4. When you are creating a batch of uniformly sized BMP assets with consistent margins and background colors.
 * 5. When you need a simple method to draw a bordered rectangle and fill its interior for printable forms or labels.
 */
