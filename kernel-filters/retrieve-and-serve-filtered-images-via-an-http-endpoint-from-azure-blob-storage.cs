// HOW-TO: Convert PNG to Grayscale JPEG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                rasterImage.Grayscale();

                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a web application must display user‑uploaded PNG photos as smaller grayscale JPEGs to save bandwidth and ensure consistent styling.
 * 2. When an e‑commerce platform needs to generate product preview images in JPEG format with a grayscale filter for a “black‑and‑white” promotional theme.
 * 3. When a machine‑learning pipeline requires converting colored PNG datasets to grayscale JPEGs before feeding them into a model that expects single‑channel images.
 * 4. When a legacy system only accepts JPEG files, and you must programmatically transform incoming PNG assets to grayscale JPEGs using C#.
 * 5. When an automated nightly job processes a folder of PNG graphics, applies a grayscale effect, and stores the results as JPEGs for archival or reporting purposes.
 */
