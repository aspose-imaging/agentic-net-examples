// HOW-TO: Retry DICOM to PNG Conversion Up to Three Times in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading;
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
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                int maxAttempts = 3;
                int attempt = 0;
                while (true)
                {
                    try
                    {
                        using (Image image = Image.Load(inputPath))
                        {
                            var pngOptions = new PngOptions();
                            image.Save(outputPath, pngOptions);
                        }
                        break;
                    }
                    catch (Exception ex) when (IsTransient(ex))
                    {
                        attempt++;
                        if (attempt >= maxAttempts)
                        {
                            throw;
                        }
                        Thread.Sleep(500);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static bool IsTransient(Exception ex)
        {
            return ex is IOException || ex is System.Net.WebException;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital's PACS system stores DICOM files on a network share that may temporarily be unavailable, a developer can use this code to reliably convert them to PNG for web viewing.
 * 2. When building a medical imaging web portal that needs to display patient scans as PNG thumbnails, the retry logic ensures occasional IO errors don't interrupt the conversion pipeline.
 * 3. When automating a nightly batch job that processes large numbers of DICOM files, the code protects against transient file‑system or network glitches by attempting the conversion up to three times.
 * 4. When integrating Aspose.Imaging into a diagnostic application that receives DICOM images over HTTP, the retry mechanism handles brief network failures before saving the images as PNG.
 * 5. When creating a desktop tool for radiologists that converts DICOM studies to PNG for annotation, the retry loop helps maintain a smooth user experience despite occasional disk read errors.
 */
