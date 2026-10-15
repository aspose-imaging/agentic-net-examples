// HOW-TO: Compress TIFF Image to JPEG with 80% Quality in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/compressed.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80
                };

                // Save the first frame with JPEG compression
                tiffImage.ActiveFrame.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce the file size of large multi‑page TIFF scans for web upload by converting them to JPEG with a specific quality setting.
 * 2. When a document management system stores images as TIFF but downstream applications require compressed JPEGs for faster rendering.
 * 3. When automating a batch process that extracts the first frame of a TIFF and saves it as a JPEG with 80 % quality to meet storage quotas.
 * 4. When integrating Aspose.Imaging into a C# service that must deliver preview thumbnails from high‑resolution TIFF files while preserving acceptable visual fidelity.
 * 5. When converting medical or engineering TIFF images to JPEG for inclusion in reports where a balance between compression and image clarity is required.
 */
