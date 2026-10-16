// HOW-TO: Invert Colors of EPS and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/output.jpg";
            string tempPngPath = "temp/temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            var rasterOptions = new EpsRasterizationOptions();

            using (Aspose.Imaging.Image epsImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                epsImage.Save(tempPngPath, pngOptions);
            }

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                var rect = new Aspose.Imaging.Rectangle(0, 0, width, height);
                int[] pixels = raster.LoadArgb32Pixels(rect);

                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }

                raster.SaveArgb32Pixels(rect, pixels);

                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };
                raster.Save(outputPath, jpegOptions);
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to generate a negative version of a vector logo stored as an EPS file for printing proofs.
 * 2. When a web service must convert client‑uploaded EPS artwork into an inverted JPEG thumbnail for preview.
 * 3. When an automated workflow requires rasterizing EPS files, applying a color‑negative effect, and storing the result as a high‑resolution JPEG for archival.
 * 4. When building a C# desktop application that lets users apply a photographic negative filter to EPS drawings before exporting them.
 * 5. When creating marketing assets that need a color‑inverted JPEG version of EPS illustrations for dark‑theme designs.
 */
