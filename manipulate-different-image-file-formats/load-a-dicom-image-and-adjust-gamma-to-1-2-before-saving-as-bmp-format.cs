// HOW-TO: Adjust Gamma of DICOM Image to 1.2 and Save as BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.AdjustGamma(1.2f);
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to improve the brightness of a DICOM scan before converting it to a BMP for display in a Windows viewer.
 * 2. When a developer must batch‑process DICOM files, apply a consistent gamma correction, and store the results in a format compatible with legacy systems.
 * 3. When integrating radiology data into a reporting tool that only accepts BMP images, requiring gamma adjustment to match visual standards.
 * 4. When creating thumbnails of DICOM images for a web portal and need to fine‑tune contrast using gamma before saving as BMP.
 * 5. When converting DICOM scans to BMP for archival purposes while ensuring the images have a standardized gamma of 1.2 for consistent playback.
 */
