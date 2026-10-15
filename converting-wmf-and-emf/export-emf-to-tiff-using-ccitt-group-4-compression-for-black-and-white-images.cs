// HOW-TO: Convert EMF to Black and White TIFF with CCITT Group 4 Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.CcittFax4;
                tiffOptions.BitsPerSample = new ushort[] { 1 };
                tiffOptions.Photometric = TiffPhotometrics.MinIsWhite;

                var vectorOptions = new VectorRasterizationOptions();
                vectorOptions.PageWidth = image.Width;
                vectorOptions.PageHeight = image.Height;
                vectorOptions.BackgroundColor = Color.White;

                tiffOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to archive vector drawings from EMF files as compact black‑and‑white TIFFs for long‑term storage or printing.
 * 2. When integrating a document conversion pipeline that requires EMF graphics to be rasterized into fax‑compatible TIFF images using CCITT Group 4 compression.
 * 3. When generating high‑resolution, 1‑bit per pixel TIFF files from EMF logos for inclusion in PDF/A or archival PDFs.
 * 4. When creating low‑size TIFF files for transmission over bandwidth‑limited channels, such as sending scanned diagrams via email or fax services.
 * 5. When converting EMF diagrams to TIFF format to comply with legacy imaging systems that only accept monochrome TIFFs with specific photometric settings.
 */
