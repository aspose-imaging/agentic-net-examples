// HOW-TO: Verify Pixel Data Consistency When Converting DICOM To PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine("Output", "sample.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image dicomImage = Image.Load(inputPath))
            {
                using (var pngOptions = new PngOptions())
                {
                    dicomImage.Save(outputPath, pngOptions);
                }

                using (Image pngImage = Image.Load(outputPath))
                {
                    var dicomRaster = (RasterImage)dicomImage;
                    var pngRaster = (RasterImage)pngImage;

                    if (!dicomRaster.IsCached) dicomRaster.CacheData();
                    if (!pngRaster.IsCached) pngRaster.CacheData();

                    var rectDicom = new Rectangle(0, 0, dicomRaster.Width, dicomRaster.Height);
                    var rectPng = new Rectangle(0, 0, pngRaster.Width, pngRaster.Height);

                    int[] dicomPixels = dicomRaster.LoadArgb32Pixels(rectDicom);
                    int[] pngPixels = pngRaster.LoadArgb32Pixels(rectPng);

                    bool identical = dicomPixels.Length == pngPixels.Length && dicomPixels.SequenceEqual(pngPixels);
                    Console.WriteLine(identical ? "Pixel data unchanged." : "Pixel data differs.");
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
 * 1. When a medical imaging application needs to ensure that converting DICOM scans to PNG for web display does not alter the original pixel values.
 * 2. When performing automated quality‑control tests on a batch of DICOM files before archiving them as lossless PNG thumbnails.
 * 3. When validating that a custom image‑processing pipeline preserves diagnostic information after format conversion in C# using Aspose.Imaging.
 * 4. When comparing pixel‑by‑pixel results of a DICOM‑to‑PNG conversion to detect any unintended compression or data loss.
 * 5. When developing a diagnostic tool that loads DICOM images, saves them as PNG, and verifies the saved image matches the source for regulatory compliance.
 */
