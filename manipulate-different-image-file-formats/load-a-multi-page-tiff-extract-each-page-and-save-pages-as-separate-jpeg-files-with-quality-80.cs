// HOW-TO: Extract TIFF Pages to JPEG Files with Quality 80 in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };

                    frame.Save(outputPath, jpegOptions);
                    pageIndex++;
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
 * 1. When you need to convert scanned multi‑page documents (TIFF) into separate high‑quality JPEG images for web preview.
 * 2. When a medical imaging system stores patient scans as multi‑page TIFFs and you must export each slice as an 80‑quality JPEG for integration with other software.
 * 3. When an archival workflow requires extracting each page of a TIFF manuscript and saving them as JPEGs to reduce file size while preserving visual fidelity.
 * 4. When a printing service receives multi‑page TIFF proofs and needs to generate individual JPEG files for proofing on devices that only support JPEG.
 * 5. When a batch processing script must automate the conversion of TIFF pages to JPEGs with a specific compression quality using C# and Aspose.Imaging.
 */
