// HOW-TO: Resize DICOM Image to BMP with Scaling Factor in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        string inputPath = "input.dcm";
        string outputPath = "output\\resized.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;

                // Example scaling factor: reduce size by 50%
                double scale = 0.5;
                int newWidth = (int)(width * scale);
                int newHeight = (int)(height * scale);

                image.Resize(newWidth, newHeight);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                image.Save(outputPath);
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
 * 1. When a medical imaging application needs to convert high‑resolution DICOM scans to smaller BMP files for faster display on a web portal.
 * 2. When a radiology workflow requires extracting the dimensions of a DICOM image to calculate a custom scaling factor before archiving.
 * 3. When a C# service must batch‑process DICOM files, resize them by a percentage, and store the results as BMP for compatibility with legacy Windows software.
 * 4. When a developer wants to create thumbnail previews of DICOM studies by reducing the image size and saving them in a widely supported bitmap format.
 * 5. When integrating Aspose.Imaging into a diagnostic tool that needs to read DICOM metadata, resize the image, and output a BMP for further image‑analysis algorithms.
 */
