// HOW-TO: Split Multi‑Page TIFF Into Individual Files Named By Frame Index In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int frameCount = tiffImage.Frames.Count();
                for (int i = 0; i < frameCount; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    using (TiffImage outImage = (TiffImage)Image.Create(tiffOptions, frame.Width, frame.Height))
                    {
                        outImage.SavePixels(outImage.Bounds, ((RasterImage)frame).LoadPixels(frame.Bounds));
                        outImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract each page of a multi‑page TIFF scan into separate files for downstream OCR processing.
 * 2. When a web service must deliver individual TIFF frames as separate assets for a digital archive.
 * 3. When a printing workflow requires separating a multi‑frame TIFF into single‑page TIFFs to feed a printer that only accepts one page per file.
 * 4. When you want to generate thumbnail previews for each frame by first saving each frame as its own TIFF file.
 * 5. When a medical imaging application must isolate each slice of a multi‑frame TIFF (e.g., DICOM‑converted) for analysis or storage.
 */
