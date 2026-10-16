// HOW-TO: Invert BMP Colors and Save as SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                if (raster != null)
                {
                    var rect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);
                    int[] pixels = raster.LoadArgb32Pixels(rect);
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;

                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }
                    raster.SaveArgb32Pixels(rect, pixels);
                }

                using (Aspose.Imaging.ImageOptions.SvgOptions svgOptions = new Aspose.Imaging.ImageOptions.SvgOptions())
                {
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a negative‑style SVG preview of a legacy BMP asset for web display.
 * 2. When converting scanned BMP diagrams into SVG format while applying a color‑invert filter to improve contrast for printing.
 * 3. When creating an SVG version of a BMP logo with inverted colors for dark‑theme UI elements.
 * 4. When automating batch processing to invert colors of BMP textures and export them as scalable SVG files for game development.
 * 5. When integrating Aspose.Imaging in a C# service that transforms user‑uploaded BMP images into inverted SVG graphics for email newsletters.
 */
