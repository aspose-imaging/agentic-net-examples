// HOW-TO: Create BMP with Filled Ellipse and Red Outline in C# (Aspose.Imaging for .NET)
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
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(20, 20, 160, 160);
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.LightBlue))
                {
                    graphics.FillEllipse(brush, rect);
                }
                Pen pen = new Pen(Aspose.Imaging.Color.Red, 3);
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
 * 1. When you need to generate a BMP thumbnail that highlights a region with a colored ellipse for a desktop reporting tool.
 * 2. When creating custom icons or UI assets where a solid‑filled shape and a contrasting border are required in a BMP file.
 * 3. When programmatically adding a visual cue, such as a selection highlight, to a bitmap image in a Windows Forms application.
 * 4. When exporting diagram elements to BMP format for legacy systems that only support uncompressed bitmap files.
 * 5. When automating the production of test images that contain both fill and stroke styles to verify image‑processing pipelines.
 */
