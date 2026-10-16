// HOW-TO: Verify JPG Created From CDR Conversion Exists and Is Not Empty in C# (Aspose.Imaging for .NET)
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

namespace CdrToJpgVerifier
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.cdr";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
                }

                if (!File.Exists(outputPath))
                {
                    Console.Error.WriteLine($"File not found: {outputPath}");
                    return;
                }

                FileInfo info = new FileInfo(outputPath);
                if (info.Length == 0)
                {
                    Console.Error.WriteLine($"File has zero size: {outputPath}");
                    return;
                }

                Console.WriteLine("JPG file created successfully and has non-zero size.");
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
 * 1. When you need to programmatically convert a CorelDRAW (CDR) file to JPEG and ensure the output file was actually written before proceeding with further processing.
 * 2. When an automated batch job must validate that each generated JPG from a CDR source is present and has a non‑zero file size to avoid downstream errors.
 * 3. When integrating Aspose.Imaging into a C# application you want to confirm the conversion succeeded by checking the file system for the new image and its byte length.
 * 4. When building a CI/CD pipeline that generates preview images from design assets and you must fail the build if any preview JPG is missing or empty.
 * 5. When creating a web service that receives CDR uploads, converts them to JPEG, and needs to return an error if the conversion result is not saved correctly or is corrupted.
 */
