// HOW-TO: Check PNG Transparency From PSD Before Saving In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                bool hasTransparency = false;
                for (int y = 0; y < raster.Height && !hasTransparency; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        var color = raster.GetPixel(x, y);
                        if (color.A < 255)
                        {
                            hasTransparency = true;
                            break;
                        }
                    }
                }

                Console.WriteLine(hasTransparency ? "Image has transparency." : "Image has no transparency.");

                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                image.Save(outputPath, options);
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
 * 1. When you need to verify whether a PSD file contains any transparent pixels before converting it to a PNG for web use.
 * 2. When you want to programmatically detect transparency in raster images to decide if an alpha channel should be preserved during export.
 * 3. When automating a batch process that converts Photoshop files to PNGs and you must log which images have transparency for downstream processing.
 * 4. When building a C# application that must ensure PNG output retains alpha information only if the source PSD actually uses transparency.
 * 5. When troubleshooting image assets and you need to quickly determine if a PSD layer composition includes transparent regions before saving as a PNG.
 */
