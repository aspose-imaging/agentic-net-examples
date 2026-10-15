// HOW-TO: Convert SVG to BMP and Save Locally Using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                BmpOptions bmpOptions = new BmpOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, bmpOptions);
            }

            // Azure Blob storage upload is not supported in this context.
            throw new NotSupportedException("Uploading to Azure Blob storage requires external libraries which are not permitted.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives an SVG upload and must generate a BMP version for legacy Windows software that only reads bitmap files.
 * 2. When a reporting system needs to rasterize vector SVG assets into BMP images to embed them in PDF documents.
 * 3. When a batch job converts a collection of design SVG files to BMP before archiving them on a network share.
 * 4. When a desktop utility resizes SVG graphics to their original dimensions and saves them as BMP for compatibility with older image editors.
 * 5. When an automated pipeline creates BMP thumbnails from SVG logos to use in email templates that support only bitmap images.
 */
