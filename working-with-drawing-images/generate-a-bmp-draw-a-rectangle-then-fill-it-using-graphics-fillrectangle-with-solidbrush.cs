// HOW-TO: Create BMP Image with Filled Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
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
            int width = 200;
            int height = 200;
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 100, 100);
                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawRectangle(pen, rect);
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
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
 * 1. When you need to generate a BMP thumbnail that highlights a specific area with a colored rectangle for a reporting dashboard.
 * 2. When you want to programmatically add a red‑filled annotation box to a BMP map image in a Windows desktop application.
 * 3. When you are creating test images for computer‑vision algorithms that require a known shape and color inside a BMP file.
 * 4. When you need to produce a BMP placeholder graphic with a blue border and red interior for UI mock‑ups.
 * 5. When you automate the production of printable BMP assets that include a solid‑filled rectangle for branding or watermark purposes.
 */
