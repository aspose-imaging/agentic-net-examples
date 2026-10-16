// HOW-TO: Adjust Gamma of DNG Image to 2.2 and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dng";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.AdjustGamma(2.2f);
                using (var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                })
                {
                    raster.Save(outputPath, pngOptions);
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
 * 1. When a photographer needs to correct the brightness of a raw DNG file for web display by applying a 2.2 gamma curve and converting it to PNG using C#.
 * 2. When a digital asset management system must batch‑process raw camera files, adjust their gamma for consistent viewing, and store the results as lossless PNGs with Aspose.Imaging.
 * 3. When a mobile app backend receives DNG uploads, needs to perform gamma correction to match sRGB standards, and returns PNG thumbnails to the client.
 * 4. When a scientific imaging pipeline requires normalizing raw sensor data by applying a gamma of 2.2 before exporting the images as PNG for analysis or reporting.
 * 5. When an e‑commerce platform wants to ensure product photos captured in DNG format appear with correct contrast on browsers by adjusting gamma and converting them to PNG on the server.
 */
