// HOW-TO: Combine Multiple TIFF Files Preserving Original Compression in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string outputPath = "output.tif";

            // Validate input files
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

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List of input TIFF files
            List<string> inputFiles = new List<string> { inputPath1, inputPath2 };

            TiffImage destinationImage = null;

            foreach (string inputFile in inputFiles)
            {
                using (TiffImage sourceImage = (TiffImage)Image.Load(inputFile))
                {
                    // Initialize destination image on first iteration
                    if (destinationImage == null)
                    {
                        // Use dimensions of the first frame of the first source image
                        TiffFrame firstFrame = sourceImage.Frames[0];
                        int width = firstFrame.Width;
                        int height = firstFrame.Height;

                        Source fileSource = new FileCreateSource(outputPath, false);
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = fileSource };

                        destinationImage = (TiffImage)Image.Create(tiffOptions, width, height);
                        // Remove the initially created empty frame
                        destinationImage.RemoveFrame(0);
                    }

                    // Copy all frames from source to destination, preserving compression
                    foreach (TiffFrame frame in sourceImage.Frames)
                    {
                        destinationImage.AddFrame(TiffFrame.CopyFrame(frame));
                    }
                }
            }

            // Save the concatenated TIFF
            if (destinationImage != null)
            {
                destinationImage.Save();
                destinationImage.Dispose();
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
 * 1. When you need to archive scanned documents from different sources into a single multi‑page TIFF while keeping each page’s original LZW or CCITT compression.
 * 2. When a medical imaging system must merge patient X‑ray TIFF files into one file without re‑encoding to maintain diagnostic quality.
 * 3. When a legal firm wants to concatenate case‑related TIFF evidence files into a single archive while preserving the original compression for court admissibility.
 * 4. When a batch processing tool combines satellite imagery TIFF tiles into a composite file without losing the original compression to reduce storage size.
 * 5. When a digital preservation workflow consolidates historic TIFF photographs into one archive file while ensuring each frame’s compression remains unchanged.
 */
