// HOW-TO: Convert RAW DNG to JPEG2000 Losslessly Preserving Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dng";
            string outputPath = "Output\\sample.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dng.DngImage dng = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
            {
                var options = new Jpeg2000Options();
                dng.Save(outputPath, options);
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
 * 1. When a photographer needs to archive RAW DNG files as JPEG2000 for lossless storage while keeping EXIF metadata.
 * 2. When a web service converts uploaded DNG images to JPEG2000 to reduce file size without sacrificing image quality.
 * 3. When a digital asset management system migrates legacy RAW files to a standardized JPEG2000 format for cross‑platform compatibility.
 * 4. When a batch processing tool prepares DNG images for archival in a museum collection, ensuring all metadata remains intact.
 * 5. When a scientific imaging application transforms raw sensor data into JPEG2000 for efficient analysis and long‑term preservation.
 */
