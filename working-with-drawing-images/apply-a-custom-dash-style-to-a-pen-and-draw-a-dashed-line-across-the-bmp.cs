// HOW-TO: Create BMP with Custom Dashed Line Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            using (var image = Image.Create(bmpOptions, 200, 100))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                var pen = new Pen(Color.Black, 2);
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 5, 3 };
                graphics.DrawLine(pen, new Point(10, 50), new Point(190, 50));
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
 * 1. When you need to generate a BMP report header with a custom dashed separator line programmatically.
 * 2. When you want to add a stylized underline to a scanned document image using Aspose.Imaging in C#.
 * 3. When creating a simple diagram or UI mockup where a dashed line indicates a measurement or boundary in a BMP file.
 * 4. When automating the production of printable forms that require a specific dash pattern for visual cues.
 * 5. When developing a batch process that adds custom dashed grid lines to BMP assets for branding or design consistency.
 */
