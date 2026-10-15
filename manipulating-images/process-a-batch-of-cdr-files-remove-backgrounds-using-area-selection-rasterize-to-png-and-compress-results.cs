// HOW-TO: Batch Convert CDR to Transparent PNG with Background Removal in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.cdr");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    VectorImage vector = cdr as VectorImage;
                    if (vector != null)
                    {
                        vector.RemoveBackground(new RemoveBackgroundSettings());
                    }

                    var pngOptions = new PngOptions()
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        PngCompressionLevel = PngCompressionLevel.ZipLevel6,
                        VectorRasterizationOptions = new VectorRasterizationOptions()
                        {
                            BackgroundColor = Color.Transparent,
                            PageSize = cdr.Size
                        }
                    };

                    cdr.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a collection of CorelDRAW (CDR) logos to web‑ready PNGs, automatically stripping the background and applying lossless compression.
 * 2. When migrating legacy design assets to a modern UI library that requires transparent PNG images with consistent compression levels.
 * 3. When generating product catalog thumbnails from CDR illustrations, removing unwanted backgrounds and reducing file size for faster page loads.
 * 4. When preparing print‑ready artwork that originates as CDR vectors but must be delivered to a vendor that only accepts PNG files with no background.
 * 5. When building an automated batch tool in C# to rasterize multiple CDR files into compressed PNGs while preserving alpha transparency.
 */
