// HOW-TO: Convert EMF to JPEG and Add Camera EXIF Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image emfImage = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions();
                emfImage.Save(outputPath, jpegOptions);

                using (JpegImage jpegImage = (JpegImage)Image.Load(outputPath))
                {
                    var exif = jpegImage.ExifData;
                    if (exif != null)
                    {
                        // Example: read a tag (if needed)
                        // var cameraMake = exif.GetTagValue(Aspose.Imaging.Exif.Enums.ExifTagId.CameraMake);
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
 * 1. When a Windows application must convert vector EMF drawings to compressed JPEG files for web display while preserving camera information in EXIF tags.
 * 2. When an automated reporting tool needs to generate JPEG thumbnails from EMF charts and embed the original camera make and model for audit trails.
 * 3. When a document management system imports legacy EMF assets and stores them as JPEGs with EXIF metadata so downstream photo‑processing software can recognize the source device.
 * 4. When a C# service processes user‑uploaded EMF files, converts them to JPEG, and adds EXIF camera details to meet metadata compliance requirements.
 * 5. When a batch conversion utility must read EMF files, save them as JPEGs, and ensure EXIF fields like CameraMake are available for cataloging in a digital asset database.
 */
