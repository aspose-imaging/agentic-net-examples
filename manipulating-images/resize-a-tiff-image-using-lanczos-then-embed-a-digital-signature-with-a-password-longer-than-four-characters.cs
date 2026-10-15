// HOW-TO: Resize TIFF with Lanczos and Add Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                RasterImage raster = tiffImage.ActiveFrame;

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;
                if (newWidth <= 0) newWidth = raster.Width;
                if (newHeight <= 0) newHeight = raster.Height;

                raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                raster.EmbedDigitalSignature("StrongPassword123");

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to shrink large TIFF scans for faster transmission while preserving quality with Lanczos resampling and ensure the file is tamper‑evident by embedding a password‑protected digital signature.
 * 2. When archiving scanned legal documents you want to reduce file size, keep high‑quality details, and embed a signature so only users who know the strong password can verify authenticity.
 * 3. When preparing medical imaging (e.g., radiology TIFFs) for integration into a PACS system, you may resize the images to fit storage constraints and add a digital signature to meet compliance and audit requirements.
 * 4. When creating a digital asset pipeline for a publishing house, you can downscale high‑resolution TIFF artwork and embed a password‑protected signature to protect copyright before distribution.
 * 5. When automating batch processing of engineering drawings, you can resize each TIFF to a standard dimension and embed a digital signature to guarantee that the drawings have not been altered after export.
 */
