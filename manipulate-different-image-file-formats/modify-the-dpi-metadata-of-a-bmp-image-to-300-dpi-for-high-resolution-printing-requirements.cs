// HOW-TO: Set BMP Image DPI to 300 for High Resolution Printing in C# (Aspose.Imaging for .NET)
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

namespace DpiModifier
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output\\output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.HorizontalResolution = 300;
                        rasterImage.VerticalResolution = 300;
                    }

                    BmpOptions saveOptions = new BmpOptions();
                    image.Save(outputPath, saveOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to prepare BMP files for a commercial printer that requires 300 DPI metadata to ensure sharp output.
 * 2. When converting scanned BMP images to meet the DPI specifications of a publishing workflow without altering pixel dimensions.
 * 3. When generating BMP assets for a CAD application that expects high‑resolution DPI settings for accurate scaling on screen and paper.
 * 4. When updating legacy BMP graphics in a Windows desktop application to comply with modern print standards that demand 300 DPI.
 * 5. When batch‑processing BMP images in an automated C# service to embed 300 DPI metadata before archiving them for future print jobs.
 */
