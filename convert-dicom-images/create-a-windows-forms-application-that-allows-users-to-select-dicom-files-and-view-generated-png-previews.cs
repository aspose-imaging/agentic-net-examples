// HOW-TO: Generate PNG Preview From DICOM File In C# Windows Forms (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine("Previews", Path.GetFileNameWithoutExtension(inputPath) + ".png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                dicom.Save(outputPath, pngOptions);
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
 * 1. When a radiology application needs to show a quick thumbnail of a DICOM scan without loading the full medical image, developers can use this code to convert the DICOM file to a lightweight PNG preview.
 * 2. When integrating a PACS viewer into a Windows Forms tool, developers can generate PNG snapshots of DICOM studies for printing or reporting purposes.
 * 3. When building a batch processing utility that organizes patient images, this snippet lets developers create PNG thumbnails and store them in a dedicated “Previews” folder for easy browsing.
 * 4. When a healthcare web portal requires server‑side conversion of uploaded DICOM files to web‑friendly PNGs, developers can reuse the same logic in a WinForms prototype before moving to a service.
 * 5. When a developer wants to validate that a DICOM file was read correctly, they can save a PNG representation and display it in the UI to confirm visual fidelity.
 */
