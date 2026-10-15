// HOW-TO: Create BMP with Outlined Diagonal Line Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen blackPen = new Pen(Aspose.Imaging.Color.Black, 10);
                graphics.DrawLine(blackPen, new Aspose.Imaging.Point(20, 20), new Aspose.Imaging.Point(180, 180));

                Pen whitePen = new Pen(Aspose.Imaging.Color.White, 4);
                graphics.DrawLine(whitePen, new Aspose.Imaging.Point(20, 20), new Aspose.Imaging.Point(180, 180));

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
 * 1. When you need to generate a BMP file with a highlighted diagonal line for a simple diagram or placeholder image in a .NET application.
 * 2. When you want to programmatically add an outlined line to a bitmap to emphasize edges in a UI component or report.
 * 3. When creating test images that require a thick black stroke with a contrasting white border to verify rendering pipelines.
 * 4. When automating the production of icons or markers that need a clear outline for visibility against varying backgrounds.
 * 5. When building a graphics utility that draws custom shapes on raster images and saves them directly as BMP without using external editors.
 */
