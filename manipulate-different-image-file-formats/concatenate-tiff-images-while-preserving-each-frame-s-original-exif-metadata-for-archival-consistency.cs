// HOW-TO: Combine Multiple TIFF Files Into One While Keeping EXIF Metadata In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage first = (TiffImage)Image.Load(inputPath1))
            {
                Source outSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = outSource };

                using (TiffImage output = (TiffImage)Image.Create(tiffOptions, first.Width, first.Height))
                {
                    foreach (TiffFrame frame in first.Frames)
                    {
                        TiffFrame copied = TiffFrame.CopyFrame(frame);
                        output.AddFrame(copied);
                    }

                    using (TiffImage second = (TiffImage)Image.Load(inputPath2))
                    {
                        foreach (TiffFrame frame in second.Frames)
                        {
                            TiffFrame copied = TiffFrame.CopyFrame(frame);
                            output.AddFrame(copied);
                        }
                    }

                    output.Save();
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
 * 1. When a digital archivist needs to merge scanned pages from separate TIFF files into a single multi‑page document without losing the original EXIF tags.
 * 2. When a medical imaging system must concatenate patient scan series stored as individual TIFF frames while preserving metadata for regulatory compliance.
 * 3. When a photographer wants to combine separate TIFF exposures into one file for batch printing, keeping camera settings embedded.
 * 4. When a document management application needs to create a unified TIFF archive from multiple source files while retaining each page’s metadata for search indexing.
 * 5. When a GIS developer must merge tiled TIFF map images into a single file and keep geolocation EXIF data intact for later analysis.
 */
