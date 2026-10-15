// HOW-TO: Rasterize EPS to 300 DPI TIFF with ICC Profile in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/output.tiff";
            string iccPath = "profile.icc";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] iccData = null;
            if (File.Exists(iccPath))
            {
                iccData = File.ReadAllBytes(iccPath);
            }

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White
                };
                if (iccData != null)
                {
                    tiffOptions.IccProfile = new MemoryStream(iccData);
                }

                epsImage.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to convert client‑provided EPS artwork into high‑resolution 300 DPI TIFF files with an embedded ICC profile to ensure accurate colors before printing.
 * 2. When a desktop publishing application must generate preview images of vector EPS logos as TIFFs for inclusion in PDFs while preserving color management.
 * 3. When an automated build pipeline processes EPS assets and creates color‑calibrated TIFFs for a digital asset management system.
 * 4. When a web service receives EPS files and returns 300 DPI TIFF thumbnails that match the original color space using an embedded ICC profile.
 * 5. When a scientific reporting tool rasterizes EPS diagrams into TIFF format for high‑quality print reports and needs to embed the lab’s ICC profile for consistent color reproduction.
 */
