// HOW-TO: Create Indexed PSD with Red Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Black,
                Aspose.Imaging.Color.White,
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue
            };
            var palette = new ColorPalette(paletteColors);

            var psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.Palette = palette;

            int width = 200;
            int height = 200;

            using (var image = Image.Create(psdOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                var pen = new Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));
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
 * 1. When you need to generate a PSD file with a limited color palette and overlay a rectangle shape for a design mockup.
 * 2. When creating thumbnails for a Photoshop workflow that require indexed colors and simple vector graphics drawn programmatically.
 * 3. When automating the production of printable assets that must conform to a specific palette and include guide markings such as rectangles.
 * 4. When building a web service that returns PSD files with annotated regions for image analysis or review.
 * 5. When testing Photoshop compatibility by programmatically adding shapes to an indexed PSD file.
 */
