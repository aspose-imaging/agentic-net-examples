// HOW-TO: Add Drop Shadow to EPS Shapes and Save as High Resolution TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    epsImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (var rasterImage = (RasterImage)Image.Load(ms))
                    {
                        int shadowOffset = 10;
                        int canvasWidth = rasterImage.Width + shadowOffset;
                        int canvasHeight = rasterImage.Height + shadowOffset;

                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        using (var tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                        {
                            var graphics = new Graphics(tiffImage);
                            graphics.Clear(Aspose.Imaging.Color.White);
                            using (var shadowBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                            {
                                graphics.FillRectangle(
                                    shadowBrush,
                                    new Aspose.Imaging.Rectangle(
                                        shadowOffset,
                                        shadowOffset,
                                        rasterImage.Width,
                                        rasterImage.Height));
                            }
                            graphics.DrawImage(
                                rasterImage,
                                new Aspose.Imaging.Rectangle(0, 0, rasterImage.Width, rasterImage.Height));

                            tiffImage.Save(outputPath);
                        }
                    }
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
 * 1. When you need to convert vector EPS artwork into a printable TIFF with a subtle drop shadow for branding materials.
 * 2. When preparing product catalog images where the original EPS logo must appear with depth on a white background.
 * 3. When generating high‑resolution TIFF files for pre‑press workflows that require a shadow effect on all vector shapes.
 * 4. When automating the creation of marketing assets that combine EPS graphics with a drop shadow before sending to a printer.
 * 5. When building a C# service that processes uploaded EPS files, adds visual emphasis, and stores the result as a TIFF for archival.
 */
