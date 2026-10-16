// HOW-TO: Convert Multi‑Page TIFF to Lossless APNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image tiffImage = Image.Load(inputPath))
            {
                if (tiffImage is IMultipageImage multiPage)
                {
                    // Prepare APNG options with lossless compression
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha,
                        PngCompressionLevel = PngCompressionLevel.ZipLevel0
                    };

                    // Use the dimensions of the first frame for the canvas
                    using (RasterImage firstFrame = (RasterImage)multiPage.Pages[0])
                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, firstFrame.Width, firstFrame.Height))
                    {
                        apng.RemoveAllFrames();

                        foreach (Image frame in multiPage.Pages)
                        {
                            apng.AddFrame((RasterImage)frame);
                        }

                        // Since the source is already bound, just call Save()
                        apng.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The input file is not a multi-page TIFF.");
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
 * 1. When you need to display a high‑resolution scanned document as an animated PNG on a website without losing image quality.
 * 2. When converting a multi‑page medical imaging TIFF series into a single APNG for easy sharing in diagnostic reports.
 * 3. When creating an animated product catalog from TIFF frames while preserving transparency and lossless compression in a C# application.
 * 4. When generating a lightweight, lossless animation from TIFF‑based satellite imagery for GIS visualization tools.
 * 5. When automating the batch conversion of archival TIFF files to APNG for archival storage while keeping original color fidelity.
 */
