// HOW-TO: Convert DICOM File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
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
 * 1. When a hospital IT system needs to display radiology images in a web viewer that only supports PNG, developers can use this code to convert DICOM scans to PNG on the fly.
 * 2. When a research project requires extracting image data from DICOM files for machine‑learning preprocessing, the tool can batch‑convert the files to PNG for easier handling in Python or other libraries.
 * 3. When a mobile health app must store patient images as lightweight PNGs to reduce storage and bandwidth, developers can integrate this command‑line converter into the build pipeline.
 * 4. When a legacy PACS archive is being migrated and the new system only accepts standard image formats, the code provides a simple way to transform each DICOM into a PNG file.
 * 5. When a developer needs to generate thumbnail previews of DICOM studies for a dashboard, the converter can produce PNG thumbnails that can be rendered in HTML pages.
 */
