// HOW-TO: Convert EPS Files to PNG with 1.5x Scaling in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(epsPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
                {
                    int newWidth = (int)Math.Round(epsImage.Width * 1.5);
                    int newHeight = (int)Math.Round(epsImage.Height * 1.5);

                    var rasterOptions = new EpsRasterizationOptions
                    {
                        PageWidth = newWidth,
                        PageHeight = newHeight
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    epsImage.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to batch‑export EPS logos to high‑resolution PNGs for web use while enlarging them by 150 % and keeping the transparent background.
 * 2. When an e‑commerce platform must automatically generate product thumbnails from EPS vector assets, scaling them up for retina displays and preserving transparency for overlay.
 * 3. When a publishing workflow requires converting printer‑ready EPS illustrations to PNG images for preview pages, applying a uniform 1.5 scaling factor to match layout dimensions.
 * 4. When a software tool processes a folder of EPS icons and needs to create larger PNG versions for UI themes, ensuring the icons remain crisp and transparent.
 * 5. When a migration script moves legacy EPS assets into a modern asset library, converting each file to PNG with consistent scaling and alpha channel support using C# and Aspose.Imaging.
 */
