// HOW-TO: Convert EMF to JPEG with Custom Quality in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output\\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image
            using (var emfImage = Image.Load(inputPath) as EmfImage)
            {
                if (emfImage == null)
                {
                    Console.Error.WriteLine("Failed to load EMF image.");
                    return;
                }

                // Configure JPEG options to control output quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // Adjust quality as needed (0-100)
                };

                // Save EMF as JPEG with the specified options
                emfImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate high‑resolution JPEG thumbnails from vector EMF graphics for web preview.
 * 2. When exporting reports that contain EMF charts to JPEG files to embed in email attachments.
 * 3. When converting legacy EMF logos to JPEG format while controlling compression to meet size constraints.
 * 4. When processing batch EMF drawings on a server and saving them as JPEGs with a specific quality setting.
 * 5. When integrating Aspose.Imaging into a C# application to transform vector drawings into raster images for printing workflows.
 */
