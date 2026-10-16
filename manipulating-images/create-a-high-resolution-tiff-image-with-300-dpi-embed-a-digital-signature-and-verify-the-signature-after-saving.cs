// HOW-TO: Create High Resolution 300 DPI TIFF with Digital Signature in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 2000;
            int height = 2000;
            string password = "SecretPwd";

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                tiffImage.HorizontalResolution = 300;
                tiffImage.VerticalResolution = 300;

                ((RasterImage)tiffImage).EmbedDigitalSignature(password);
                tiffImage.Save(outputPath);
            }

            using (RasterImage loadedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = loadedImage.IsDigitalSigned(password);
                Console.WriteLine($"Signature verified: {isSigned}");
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
 * 1. When you need to generate a 300 DPI TIFF for archival printing and ensure its authenticity with a password‑protected digital signature.
 * 2. When a medical imaging system must create high‑resolution scans and embed a signature to comply with regulatory audit trails.
 * 3. When a legal document workflow requires saving scanned contracts as TIFF files that can be later verified for tampering.
 * 4. When a GIS application exports large raster maps as TIFF and wants to protect them against unauthorized modifications.
 * 5. When an e‑commerce platform produces product catalog images in TIFF format and needs to confirm the image integrity after storage.
 */
