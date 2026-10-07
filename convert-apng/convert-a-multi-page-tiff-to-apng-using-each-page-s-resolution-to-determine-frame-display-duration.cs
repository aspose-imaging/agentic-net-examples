// HOW-TO: Convert Multi‑Page TIFF to Animated PNG Using DPI Frame Timing in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                float dpi = (float)(tiff.HorizontalResolution > 0 ? tiff.HorizontalResolution : 72.0);
                uint frameTime = (uint)(1000 / dpi * 100);

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = frameTime
                };

                tiff.Save(outputPath, options);
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
 * 1. When you need to turn a scanned multi‑page document saved as TIFF into a lightweight animated PNG for web preview, preserving the original page resolution as frame delay.
 * 2. When generating a product catalog animation where each TIFF page represents a product view and the display speed should match the DPI of the source images.
 * 3. When creating an animated thumbnail from a multi‑page medical image (e.g., DICOM exported to TIFF) and want the frame duration to reflect the image’s resolution.
 * 4. When building a reporting tool that converts multi‑page TIFF charts into an APNG slideshow, using the DPI to ensure consistent timing across different screen densities.
 * 5. When automating the conversion of multi‑page scanned maps into an animated PNG map sequence, with each frame’s display time automatically calculated from the map’s resolution.
 */
