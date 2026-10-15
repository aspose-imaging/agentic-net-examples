// HOW-TO: Convert EMF to JPEG with Custom ICC Color Profile in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/sample.jpg";
            string iccPath = "Input/custom.icc";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(iccPath))
            {
                Console.Error.WriteLine($"File not found: {iccPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Stream iccStream = File.OpenRead(iccPath))
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.RgbColorProfile = new StreamSource(iccStream);

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to preserve brand‑specific colors while converting vector EMF graphics to JPEG for web publishing.
 * 2. When a printing workflow requires embedding a custom ICC profile during EMF‑to‑JPEG conversion to match the target printer’s color space.
 * 3. When generating thumbnails of EMF diagrams for a catalog and must maintain accurate colors across different devices.
 * 4. When automating batch conversion of legacy EMF assets to JPEG in a C# application and need to apply a corporate color profile.
 * 5. When integrating Aspose.Imaging into a document management system to ensure color‑consistent JPEG output from uploaded EMF files.
 */
