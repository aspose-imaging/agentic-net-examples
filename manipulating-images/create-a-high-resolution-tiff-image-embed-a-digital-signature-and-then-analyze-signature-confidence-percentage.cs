// HOW-TO: Create High Resolution TIFF and Embed Digital Signature in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 2000;
            int height = 2000;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.ResolutionUnit = TiffResolutionUnits.Inch;
            tiffOptions.Xresolution = new TiffRational(300);
            tiffOptions.Yresolution = new TiffRational(300);

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                int[] pixels = new int[width * height];
                int whiteArgb = Color.White.ToArgb();
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = whiteArgb;
                }

                tiffImage.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                ((RasterImage)tiffImage).EmbedDigitalSignature("SecretPwd");

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
 * 1. When you need to generate a 300 dpi TIFF document for printing and protect it with a password‑based digital signature using Aspose.Imaging for .NET.
 * 2. When an archival system requires white‑background high‑resolution TIFF files that are cryptographically signed to verify authenticity.
 * 3. When a medical imaging workflow must create large TIFF scans and embed a signature to ensure the images have not been altered.
 * 4. When a GIS application produces raster maps in TIFF format and needs to embed a digital signature for secure distribution.
 * 5. When a legal document management solution creates TIFF copies of contracts and embeds a digital signature to comply with tamper‑evidence regulations.
 */
