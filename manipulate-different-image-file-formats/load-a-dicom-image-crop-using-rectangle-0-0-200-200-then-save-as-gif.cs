// HOW-TO: Crop DICOM Image to 200x200 and Save as GIF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/cropped.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.Crop(new Rectangle(0, 0, 200, 200));
                image.Save(outputPath, new GifOptions());
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
 * 1. When you need to generate a small GIF thumbnail from a large DICOM radiology scan for quick preview in a web portal.
 * 2. When converting DICOM files to a web‑friendly format while extracting a specific region of interest for a diagnostic report.
 * 3. When creating static GIFs from medical images to embed in electronic health record (EHR) documentation.
 * 4. When preprocessing DICOM images by cropping to a fixed 200 × 200 pixel area before applying further image analysis in C#.
 * 5. When automating batch processing of DICOM studies to produce uniformly sized GIFs for mobile device display.
 */
