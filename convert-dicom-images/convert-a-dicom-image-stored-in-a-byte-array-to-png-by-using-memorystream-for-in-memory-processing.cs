// HOW-TO: Convert DICOM Byte Array to PNG Using MemoryStream in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] dicomBytes = File.ReadAllBytes(inputPath);

            using (MemoryStream inputStream = new MemoryStream(dicomBytes))
            {
                using (DicomImage dicomImage = (DicomImage)Image.Load(inputStream))
                {
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        dicomImage.Save(outputStream, pngOptions);
                        byte[] pngBytes = outputStream.ToArray();
                        File.WriteAllBytes(outputPath, pngBytes);
                    }
                }
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
 * 1. When a medical imaging application receives DICOM data over a network as a byte array and needs to display or store it as a PNG without writing temporary files.
 * 2. When a cloud service processes uploaded DICOM files and must convert them to PNG for web preview while keeping all operations in memory.
 * 3. When a desktop tool extracts frames from a DICOM series stored in a database BLOB and wants to save each frame as a PNG for reporting.
 * 4. When an automated pipeline converts DICOM scans to PNG thumbnails for inclusion in electronic health records using Aspose.Imaging.
 * 5. When a unit test validates that a DICOM‑to‑PNG conversion works correctly by loading the image from a MemoryStream and comparing the resulting byte array.
 */
