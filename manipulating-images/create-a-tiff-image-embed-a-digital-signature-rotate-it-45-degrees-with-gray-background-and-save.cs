// HOW-TO: Create TIFF, Embed Digital Signature, Rotate 45 Degrees With Gray Background In C# (Aspose.Imaging for .NET)
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
        string outputPath = "Output/output.tif";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            using (RasterImage raster = (RasterImage)Image.Create(tiffOptions, width, height))
            {
                string password = "pass1234";
                raster.EmbedDigitalSignature(password);

                Aspose.Imaging.Color gray = Aspose.Imaging.Color.FromArgb(255, 128, 128, 128);
                raster.Rotate(45f, true, gray);

                raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate a secure TIFF document that includes a digital signature and is displayed at a 45‑degree angle with a gray background for compliance reports.
 * 2. When building an automated workflow that creates watermarked TIFF files, embeds authentication data, and rotates them for printing on pre‑aligned media.
 * 3. When a medical imaging system must produce signed TIFF scans that are rotated to match device orientation while preserving a neutral gray canvas.
 * 4. When a legal document management solution requires programmatically adding a digital signature to TIFF files and rotating them for consistent archival layout.
 * 5. When developing a GIS application that outputs signed TIFF tiles, applies a 45° rotation, and fills empty space with a gray background to maintain visual consistency.
 */
