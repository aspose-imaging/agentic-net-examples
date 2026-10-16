// HOW-TO: Create BMP Image with Dark Gray Background and Yellow Diagonal Line in C# (Aspose.Imaging for .NET)
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

            int width = 200;
            int height = 200;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (RasterImage image = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                Aspose.Imaging.Color darkGray = Aspose.Imaging.Color.FromArgb(255, 64, 64, 64);
                graphics.Clear(darkGray);
                Aspose.Imaging.Color brightYellow = Aspose.Imaging.Color.FromArgb(255, 255, 255, 0);
                Pen pen = new Pen(brightYellow);
                graphics.DrawLine(pen, 0, 0, width - 1, height - 1);
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
 * 1. When you need to generate a simple placeholder BMP file with a custom background color and a visible diagonal marker for testing image pipelines.
 * 2. When you want to programmatically create a bitmap logo or watermark that consists of a solid color canvas and a bright line to indicate orientation.
 * 3. When building automated UI screenshots that require a consistent dark gray background and a contrasting yellow guide line for alignment verification.
 * 4. When preparing sample BMP assets for a graphics library demo that shows how to clear a raster image and draw primitive shapes using Aspose.Imaging in C#.
 * 5. When creating diagnostic images for hardware devices that expect a BMP file with a known background and a diagonal line to confirm proper rendering.
 */
