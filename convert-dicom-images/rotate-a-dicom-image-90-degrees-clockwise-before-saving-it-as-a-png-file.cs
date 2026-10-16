// HOW-TO: Rotate DICOM Image 90 Degrees Clockwise and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                dicom.RotateFlip(RotateFlipType.Rotate90FlipNone);
                dicom.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to display a DICOM scan in the correct orientation on a web page, developers can rotate the image 90° clockwise and convert it to PNG for browser compatibility.
 * 2. When integrating PACS data into a reporting tool that only accepts PNG files, developers can use this code to reorient and export DICOM images without losing diagnostic details.
 * 3. When building a mobile health app that requires thumbnails of DICOM studies, developers can rotate the original image and save it as a lightweight PNG for faster loading.
 * 4. When automating a batch process that corrects orientation errors caused by scanner settings, developers can apply the rotation and convert each DICOM file to PNG for archival.
 * 5. When creating a documentation workflow that embeds medical images into PDFs, developers can first rotate the DICOM image and save it as PNG to ensure proper alignment and format compatibility.
 */
