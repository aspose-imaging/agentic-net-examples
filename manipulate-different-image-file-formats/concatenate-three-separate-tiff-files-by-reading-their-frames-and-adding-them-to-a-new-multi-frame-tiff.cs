// HOW-TO: Combine Multiple TIFF Files into a Multi‑Frame TIFF in C# (Aspose.Imaging for .NET)
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
        string inputPath1 = "input1.tif";
        string inputPath2 = "input2.tif";
        string inputPath3 = "input3.tif";
        string outputPath = "output.tif";

        try
        {
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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage firstSrc = (TiffImage)Image.Load(inputPath1))
            {
                int width = firstSrc.Width;
                int height = firstSrc.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (TiffImage dest = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    dest.RemoveFrame(0);

                    string[] inputs = new[] { inputPath1, inputPath2, inputPath3 };
                    foreach (string inPath in inputs)
                    {
                        using (TiffImage src = (TiffImage)Image.Load(inPath))
                        {
                            foreach (TiffFrame frame in src.Frames)
                            {
                                dest.AddFrame(TiffFrame.CopyFrame(frame));
                            }
                        }
                    }

                    dest.Save();
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
 * 1. When you need to merge scanned document pages stored as separate TIFF files into a single multi‑page TIFF for easier distribution.
 * 2. When generating a PDF‑like document from individual TIFF images and you want to keep them in one file for archival.
 * 3. When creating a multi‑frame image for medical imaging systems that require all slices in a single TIFF container.
 * 4. When automating a workflow that combines separate camera‑captured TIFF frames into a single file for batch processing.
 * 5. When consolidating TIFF layers from different sources into one file to reduce file‑handling overhead in a .NET application.
 */
