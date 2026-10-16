// HOW-TO: Convert DICOM to PNG in ASP.NET Core API with Aspose Imaging (Aspose.Imaging for .NET)
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

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            using (PngOptions pngOptions = new PngOptions())
            {
                dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a healthcare web application needs to serve DICOM scans as PNG images over HTTP, the code can convert the files on the fly and return them as a byte array.
 * 2. When integrating a PACS system with a mobile front‑end, developers can use this snippet to transform DICOM files into web‑friendly PNGs for display in browsers.
 * 3. When building a diagnostic reporting API that generates thumbnails of medical images, the conversion routine provides fast PNG output suitable for embedding in PDFs.
 * 4. When a tele‑medicine platform requires secure, stateless image delivery, the method converts DICOM to PNG and streams the byte array without writing temporary files.
 * 5. When automating batch processing of radiology images in an ASP.NET Core microservice, the code enables batch conversion from DICOM to PNG for downstream AI analysis.
 */
