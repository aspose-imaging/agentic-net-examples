// HOW-TO: Split Multi‑Page TIFF into Separate Files with Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDirectory);

        try
        {
            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                TiffOptions originalOptions = tiff.GetOriginalOptions() as TiffOptions ?? new TiffOptions(TiffExpectedFormat.Default);
                int frameIndex = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    string outputPath = Path.Combine(outputDirectory, $"frame_{frameIndex}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (TiffImage outImage = (TiffImage)Aspose.Imaging.Image.Create(originalOptions, frame.Width, frame.Height))
                    {
                        Aspose.Imaging.Color[] pixels = tiff.LoadPixels(frame.Bounds);
                        outImage.SavePixels(outImage.Bounds, pixels);
                        outImage.Save(outputPath);
                    }

                    frameIndex++;
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
 * 1. When you need to extract each page of a scanned document stored as a multi‑page TIFF for individual processing or archiving.
 * 2. When a web service must deliver separate TIFF images for each frame of a multi‑page file while preserving original EXIF and resolution metadata.
 * 3. When a batch job converts multi‑page medical imaging TIFFs into single‑page files for compatibility with legacy analysis tools.
 * 4. When an automated workflow separates animation frames stored in a TIFF stack to create independent images for further editing in C#.
 * 5. When a document management system splits large TIFF archives into per‑page files to improve indexing and search performance.
 */
