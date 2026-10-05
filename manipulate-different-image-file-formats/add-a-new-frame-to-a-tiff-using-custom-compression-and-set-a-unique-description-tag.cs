// HOW-TO: Add a New LZW Compressed Frame to an Existing TIFF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int width = tiff.Width;
                int height = tiff.Height;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Lzw;

                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);
                tiff.AddFrame(newFrame);
                tiff.Save(outputPath);
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
 * 1. When you need to create a multi‑page TIFF by appending an extra page with LZW compression to an existing document in a C# application.
 * 2. When a scanning workflow requires adding a new high‑resolution image as a separate frame to a TIFF archive without re‑encoding the original pages.
 * 3. When you want to programmatically expand a TIFF file for archival purposes while keeping file size low by using LZW compression.
 * 4. When a medical imaging system must insert additional diagnostic images into a patient’s TIFF series on the server using Aspose.Imaging for .NET.
 * 5. When an automated reporting tool generates a summary page and needs to attach it as a new frame with custom compression to an existing TIFF report.
 */
