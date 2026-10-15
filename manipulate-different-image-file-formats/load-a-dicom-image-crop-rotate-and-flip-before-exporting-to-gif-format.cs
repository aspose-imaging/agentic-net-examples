// HOW-TO: Crop Rotate Flip DICOM Image and Save as GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var cropRect = new Aspose.Imaging.Rectangle(100, 100, 200, 200);
                dicom.Crop(cropRect);

                dicom.Rotate(90f, true, Aspose.Imaging.Color.White);

                dicom.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipX);

                var gifOptions = new GifOptions();
                dicom.Save(outputPath, gifOptions);
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
 * 1. When a medical imaging application needs to extract a specific region from a DICOM scan, reorient it, and deliver the result as a lightweight GIF for web preview.
 * 2. When a radiology workflow requires converting a DICOM slice into a GIF after applying a 90‑degree rotation and a horizontal flip to match patient positioning.
 * 3. When a healthcare portal wants to display a cropped and correctly oriented DICOM image in browsers that only support GIF, using C# and Aspose.Imaging.
 * 4. When a developer must preprocess DICOM files—crop to a region of interest, rotate, and flip—and store them as GIF files for inclusion in reports or documentation.
 * 5. When integrating a PACS system with a .NET service that needs to transform DICOM images into GIF thumbnails with specific orientation and size adjustments.
 */
