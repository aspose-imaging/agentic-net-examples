// HOW-TO: Convert DICOM Image to PNG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace DicomToPngConverter
{
    class Program
    {
        static void Main()
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

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a healthcare application needs to display radiology scans on a web page, developers can convert DICOM files to PNG for browser‑friendly rendering.
 * 2. When integrating a PACS system with a reporting tool, the code enables automatic transformation of DICOM images into PNG thumbnails for quick preview.
 * 3. When building a data‑migration script that moves medical images to a cloud storage bucket, the single‑call conversion simplifies saving DICOM as PNG without intermediate processing.
 * 4. When creating a desktop utility that lets clinicians export patient scans as standard images for presentations, the example shows how to load a .dcm file and save it as .png in C#.
 * 5. When developing a diagnostic AI pipeline that requires input images in PNG format, this code provides a fast way to convert incoming DICOM files before feeding them to the model.
 */
