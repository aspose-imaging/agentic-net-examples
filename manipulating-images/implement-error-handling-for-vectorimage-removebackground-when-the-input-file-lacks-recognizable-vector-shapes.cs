// HOW-TO: Remove Background From SVG And Save As Transparent PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The provided file is not a vector image.");
                    return;
                }

                try
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Background removal failed: {ex.Message}");
                    return;
                }

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = vectorImage.Size
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically strip the background from an SVG file that may contain only raster elements and convert it to a PNG with transparency in a .NET application.
 * 2. When your web service must validate that an uploaded image is a vector format before attempting background removal to avoid processing errors.
 * 3. When you want to generate PNG thumbnails from user‑provided SVG logos while ensuring any unsupported shapes are gracefully handled.
 * 4. When building a batch conversion tool that processes a folder of SVG files, removes their backgrounds, and saves the results as PNGs without crashing on invalid files.
 * 5. When integrating Aspose.Imaging into a C# workflow to detect missing vector data, report the issue, and continue processing other images.
 */
