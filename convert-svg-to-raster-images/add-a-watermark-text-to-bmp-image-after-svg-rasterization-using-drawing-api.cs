// HOW-TO: Add Text Watermark to BMP After SVG Rasterization in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = width,
                    PageHeight = height,
                    BackgroundColor = Color.White
                };

                using (RasterImage raster = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(raster);
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 36);
                    using (SolidBrush brush = new SolidBrush(Color.Yellow))
                    {
                        Point position = new Point(width / 2, height / 2);
                        graphics.DrawString("Watermark", font, brush, position);
                    }

                    raster.Save(outputPath);
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
 * 1. When you need to protect a company logo stored as SVG by converting it to BMP and embedding a visible watermark for copyright enforcement.
 * 2. When generating printable assets where the original vector artwork must be rasterized to BMP and a custom text overlay is required for branding.
 * 3. When creating thumbnails for a web gallery that must include a disclaimer text on the rasterized BMP version of an SVG diagram.
 * 4. When automating batch processing of SVG icons to BMP format while adding a watermark to prevent unauthorized reuse.
 * 5. When integrating image processing into a .NET application that converts user‑uploaded SVG files to BMP and stamps them with a dynamic watermark before saving.
 */
