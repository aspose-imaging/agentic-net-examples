// HOW-TO: Convert WebP to BMP and then to LZW TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(inputDir, "image.webp");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string bmpPath = Path.Combine(outputDir, "image.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            using (Image webpImage = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                webpImage.Save(bmpPath, bmpOptions);
            }

            if (!File.Exists(bmpPath))
            {
                Console.Error.WriteLine($"File not found: {bmpPath}");
                return;
            }

            string tiffPath = Path.Combine(outputDir, "image.tiff");
            Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));
            using (Image bmpImage = Image.Load(bmpPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                bmpImage.Save(tiffPath, tiffOptions);
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
 * 1. When you need to display a WebP image in a legacy Windows application that only supports BMP, you can convert it to BMP first.
 * 2. When archiving scanned documents, you may convert high‑resolution WebP graphics to BMP and then compress them into LZW‑encoded TIFF files for lossless storage.
 * 3. When a printing workflow requires TIFF with LZW compression but the source images are in WebP, this code transforms the files accordingly.
 * 4. When integrating with a third‑party system that accepts only BMP and TIFF formats, you can use the conversion chain to meet its input requirements.
 * 5. When performing batch image processing on a server, you can automate the conversion from WebP to BMP and subsequently to LZW TIFF to reduce file size while preserving quality.
 */
