// HOW-TO: Resize EPS to 2000px Width and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\resized.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                int targetWidth = 2000;
                int targetHeight = (int)Math.Round((double)originalHeight * targetWidth / originalWidth);

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = targetWidth,
                        PageHeight = targetHeight
                    };

                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert a vector EPS logo to a high‑resolution TIFF for print‑ready output while keeping the original proportions.
 * 2. When an application must generate a 2000‑pixel‑wide preview of an EPS illustration for a web gallery and store it as a lossless TIFF.
 * 3. When a batch‑processing tool has to resize multiple EPS files to a standard width before archiving them in TIFF format for compliance.
 * 4. When a reporting system requires embedding EPS diagrams into a TIFF‑based PDF and must ensure consistent aspect ratio during conversion.
 * 5. When a digital asset pipeline needs to rasterize EPS artwork at a specific pixel width for downstream image analysis that only supports TIFF files.
 */
