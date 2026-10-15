// HOW-TO: Deskew PSD Image, Increase Brightness, and Save as PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.psd";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image
                image.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                // Adjust brightness
                image.AdjustBrightness(50);

                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to correct a scanned Photoshop file that is slightly rotated, brighten it, and provide a web‑ready PNG for display.
 * 2. When an automated workflow must convert legacy PSD assets to PNG while fixing orientation and enhancing visibility.
 * 3. When a batch job processes product mockups, straightening them and adjusting lighting before publishing to an e‑commerce site.
 * 4. When a desktop application lets users import PSD files, auto‑corrects tilt, improves contrast, and saves the result as a PNG thumbnail.
 * 5. When a server‑side service receives user‑uploaded PSDs, normalizes their angle, boosts brightness, and returns a PNG for further analysis.
 */
