// HOW-TO: Convert EPS File to PDF PNG JPEG TIFF with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args[0];
            string format = args[1].ToLower();
            string outputPath = Path.Combine("Output", $"output.{format}");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                switch (format)
                {
                    case "pdf":
                        epsImage.Save(outputPath, new PdfOptions());
                        break;
                    case "png":
                        epsImage.Save(outputPath, new PngOptions());
                        break;
                    case "jpg":
                    case "jpeg":
                        epsImage.Save(outputPath, new JpegOptions());
                        break;
                    case "tiff":
                        epsImage.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                        break;
                    case "bmp":
                        epsImage.Save(outputPath, new BmpOptions());
                        break;
                    case "gif":
                        epsImage.Save(outputPath, new GifOptions());
                        break;
                    case "webp":
                        epsImage.Save(outputPath, new WebPOptions());
                        break;
                    default:
                        Console.Error.WriteLine($"Unsupported format: {format}");
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
 * 1. When you need a command‑line tool to convert legacy EPS artwork into PDF for printing or archiving in a .NET application.
 * 2. When a web service must dynamically transform EPS logos into PNG or JPEG thumbnails for display on websites.
 * 3. When an automated build pipeline has to batch‑convert EPS diagrams to TIFF for inclusion in documentation PDFs.
 * 4. When a desktop utility must allow users to choose an output format such as BMP or GIF from an EPS source file.
 * 5. When integrating Aspose.Imaging into a C# console app to programmatically convert EPS files to WebP for optimized web delivery.
 */
