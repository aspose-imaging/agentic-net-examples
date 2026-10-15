// HOW-TO: Flip DICOM Image Vertically and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.dcm";
        string outputPath = "Output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipY);
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When a radiology application needs to correct the orientation of a DICOM scan before displaying it on a web portal, developers can flip the image vertically and export it as a PNG for fast browser rendering.
 * 2. When integrating a PACS system with a reporting tool, developers may convert DICOM files to PNG thumbnails and apply a vertical flip to match the viewer’s coordinate system.
 * 3. When creating patient education materials, a developer can take a DICOM X‑ray, flip it vertically to align with anatomical orientation, and save it as a PNG for inclusion in PDFs.
 * 4. When building a mobile health app that only supports PNG, developers can load the DICOM image, flip it vertically to correct upside‑down scans, and save the result as a PNG for efficient transmission.
 * 5. When automating quality‑control scripts, a developer can programmatically flip DICOM images vertically and convert them to PNG to compare against reference images using standard image‑diff tools.
 */
