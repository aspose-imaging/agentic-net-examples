// HOW-TO: Resize DICOM Image to 640x480 and Convert to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.dcm";
        string outputPath = "Output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Resize to 640x480
                dicom.Resize(640, 480);

                // Save as PNG
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When a medical imaging application needs to display DICOM scans on a web page, developers can resize the image to a standard 640×480 resolution and convert it to PNG for fast browser rendering.
 * 2. When integrating DICOM files into a reporting system that only accepts PNG, developers can use this code to transform high‑resolution scans into a universally supported format while reducing file dimensions.
 * 3. When creating thumbnails for a PACS viewer, developers can quickly generate 640×480 PNG thumbnails from original DICOM files to improve navigation performance.
 * 4. When exporting diagnostic images for patient portals, developers can convert DICOM images to PNG with a fixed size to ensure consistent layout across mobile and desktop devices.
 * 5. When preprocessing DICOM data for machine‑learning pipelines that require PNG inputs, developers can resize and convert the images in a single step using Aspose.Imaging for .NET.
 */
