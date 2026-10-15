// HOW-TO: Convert WebP to BMP and Then to LZW Compressed TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.webp");
            string bmpPath = Path.Combine("Output", "temp.bmp");
            string tiffPath = Path.Combine("Output", "output.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions
                {
                    Source = new FileCreateSource(bmpPath, false)
                };
                webp.Save(bmpPath, bmpOptions);
            }

            using (BmpImage bmpImage = (BmpImage)Image.Load(bmpPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.Source = new FileCreateSource(tiffPath, false);
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
 * 1. When you need to archive lossless WebP graphics in a legacy TIFF format that supports LZW compression for compatibility with older imaging systems.
 * 2. When a printing workflow requires converting high‑resolution WebP images to BMP first, then to TIFF to embed metadata that only TIFF supports.
 * 3. When a document management system stores images as TIFF with LZW compression, but source files are supplied as WebP, you can automate the conversion using this code.
 * 4. When you want to create a BMP intermediate file for image analysis tools that cannot read WebP, and later produce a compressed TIFF for storage.
 * 5. When migrating a web‑based image library to a desktop application that only reads TIFF, you can convert each WebP to BMP and then to LZW‑compressed TIFF in C#.
 */
