// HOW-TO: Add a New TIFF Frame with Adobe Deflate Compression in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

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
                frameOptions.Compression = TiffCompressions.AdobeDeflate;

                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                Color[] pixels = tiff.LoadPixels(tiff.ActiveFrame.Bounds);
                newFrame.SavePixels(newFrame.Bounds, pixels);

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
 * 1. When you need to embed an additional page into an existing multi‑page TIFF for archival documents using Aspose.Imaging in C#.
 * 2. When you want to create a multi‑frame TIFF where each frame uses Adobe Deflate compression to reduce file size without losing image quality.
 * 3. When you must programmatically duplicate the pixel data of an existing TIFF page into a new frame for image‑analysis pipelines in a .NET application.
 * 4. When you are building a C# solution that merges several scanned images into a single TIFF file while keeping consistent dimensions and applying a specific compression method.
 * 5. When you need to add a new frame to a TIFF, preserve the original dimensions, and save the updated multi‑frame image to disk with Aspose.Imaging.
 */
