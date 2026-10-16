// HOW-TO: Remove Watermark From PNG With Telea Or ContentAwareFill In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                float x = (float)(rasterImage.Width * 0.25);
                float y = (float)(rasterImage.Height * 0.25);
                float width = (float)(rasterImage.Width * 0.5);
                float height = (float)(rasterImage.Height * 0.5);
                figure.AddShape(new EllipseShape(new RectangleF(x, y, width, height)));
                mask.AddFigure(figure);

                Console.WriteLine("Select watermark removal algorithm:");
                Console.WriteLine("1 - Telea");
                Console.WriteLine("2 - ContentAwareFill");
                Console.Write("Enter choice (1 or 2): ");
                string choice = Console.ReadLine();

                if (choice == "2")
                {
                    var caOptions = new ContentAwareFillWatermarkOptions(mask);
                    using (RasterImage result = WatermarkRemover.PaintOver(rasterImage, caOptions))
                    {
                        result.Save(outputPath, new PngOptions());
                    }
                }
                else
                {
                    var teleaOptions = new TeleaWatermarkOptions(mask);
                    using (RasterImage result = WatermarkRemover.PaintOver(rasterImage, teleaOptions))
                    {
                        result.Save(outputPath, new PngOptions());
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
 * 1. Use this code to automatically erase a logo or text watermark from a PNG image in a .NET application.
 * 2. Use it when you want to give end‑users a choice between the fast Telea inpainting algorithm and the higher‑quality ContentAwareFill method for watermark removal.
 * 3. Use it to process scanned documents and preserve surrounding pixels while removing a semi‑transparent stamp.
 * 4. Use it to integrate a UI that lets users select the inpainting algorithm before cleaning up product photos for e‑commerce.
 * 5. Use it to programmatically generate a clean PNG output after masking a specific elliptical region.
 */
