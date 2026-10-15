// HOW-TO: Resize BMP Image to Fit Specific Dimensions While Preserving Aspect Ratio in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\source.bmp";
            string outputPath = "output\\resized.bmp";
            int targetWidth = 800;
            int targetHeight = 600;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double widthRatio = (double)targetWidth / image.Width;
                double heightRatio = (double)targetHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);
                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to generate thumbnail previews of large BMP files for a web gallery without distorting the original proportions.
 * 2. When an application must batch‑process scanned documents, scaling them to fit a printable page size while keeping the aspect ratio intact.
 * 3. When a game engine requires BMP textures resized to a target resolution for performance, and you want to avoid stretching the image.
 * 4. When converting user‑uploaded BMP images to a standard size for a reporting tool that expects consistent dimensions.
 * 5. When preparing BMP assets for a mobile app, you need to downsize them to fit screen constraints while preserving visual quality.
 */
