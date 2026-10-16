// HOW-TO: Increase Brightness of Multiple PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = new string[]
            {
                "C:\\Images\\input1.psd",
                "C:\\Images\\input2.psd",
                "C:\\Images\\input3.psd"
            };

            // Desired brightness increase (range -255 to 255)
            int brightnessIncrease = 50;

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output PNG path (same folder, same name, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access AdjustBrightness
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.AdjustBrightness(brightnessIncrease);
                        rasterImage.Save(outputPath, new PngOptions());
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type for file: {inputPath}");
                        return;
                    }
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
 * 1. When you need to batch‑process a series of Photoshop PSD layers to make them uniformly brighter before publishing them as web‑ready PNGs.
 * 2. When an automated build script must adjust the exposure of product mockup PSDs and output PNG thumbnails for a catalog.
 * 3. When a digital asset pipeline requires converting legacy PSD assets to PNG while applying a consistent brightness boost for better visibility on mobile devices.
 * 4. When a photo‑editing application wants to let users increase the brightness of multiple PSD files at once and instantly save the results in PNG format.
 * 5. When a content management system imports PSD artwork, needs to standardize its lighting, and stores the processed images as PNGs for faster delivery.
 */
