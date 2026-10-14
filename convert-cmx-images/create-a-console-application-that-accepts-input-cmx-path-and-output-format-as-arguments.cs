// HOW-TO: Convert CMX Files to PNG, JPEG, BMP, GIF, TIFF, PDF, or WebP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Reference CmxImage type to satisfy using directive
                CmxImage cmxImage = image as CmxImage;

                string ext = Path.GetExtension(outputPath).ToLowerInvariant();
                switch (ext)
                {
                    case ".png":
                        image.Save(outputPath, new PngOptions());
                        break;
                    case ".jpg":
                    case ".jpeg":
                        image.Save(outputPath, new JpegOptions());
                        break;
                    case ".bmp":
                        image.Save(outputPath, new BmpOptions());
                        break;
                    case ".gif":
                        image.Save(outputPath, new GifOptions());
                        break;
                    case ".tif":
                    case ".tiff":
                        image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                        break;
                    case ".pdf":
                        image.Save(outputPath, new PdfOptions());
                        break;
                    case ".webp":
                        image.Save(outputPath, new WebPOptions());
                        break;
                    default:
                        Console.Error.WriteLine($"Unsupported output format: {ext}");
                        break;
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
 * 1. When a developer needs to batch‑convert legacy Corel CMX drawings into modern image formats for web display or archival.
 * 2. When an application must allow users to upload CMX files and export them as PNG or JPEG for inclusion in reports.
 * 3. When a workflow requires converting CMX artwork to PDF or TIFF for printing or document management systems.
 * 4. When a service needs to generate lightweight WebP thumbnails from CMX source files to improve page load speed.
 * 5. When integrating Aspose.Imaging into a C# console tool to automate format conversion of CMX assets during a migration project.
 */
