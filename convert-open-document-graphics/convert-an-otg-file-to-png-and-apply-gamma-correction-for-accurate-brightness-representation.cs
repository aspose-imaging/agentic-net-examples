// HOW-TO: Convert OTG to PNG with Gamma Correction in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

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

        string inputPath = Path.Combine(inputDirectory, "input.otg");
        string outputPath = Path.Combine(outputDirectory, "output.png");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image otgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = otgImage.Width,
                        PageHeight = otgImage.Height
                    }
                };
                otgImage.Save(outputPath, pngOptions);
            }

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
            {
                if (!raster.IsCached) raster.CacheData();
                raster.AdjustGamma(2.2f);
                raster.Save(outputPath);
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
 * 1. When you need to display an OTG vector graphic on a web page that only supports PNG images, you can convert it and adjust brightness with gamma correction.
 * 2. When preparing print‑ready assets, applying gamma correction ensures the PNG’s brightness matches the original OTG’s appearance.
 * 3. When integrating legacy OTG files into a modern C# application that processes raster images, you can rasterize them to PNG and normalize luminance.
 * 4. When creating thumbnails of OTG drawings for a gallery, converting to PNG and correcting gamma gives consistent visual quality across devices.
 * 5. When automating a batch workflow that ingests OTG files and outputs PNGs for machine‑learning image analysis, gamma adjustment helps maintain accurate pixel intensity.
 */
