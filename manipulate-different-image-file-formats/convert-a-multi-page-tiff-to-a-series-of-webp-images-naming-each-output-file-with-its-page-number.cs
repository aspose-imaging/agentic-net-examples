// HOW-TO: Convert Multi‑Page TIFF to Separate WebP Files with Page Numbers in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (TiffFrame frame in tiffImage.Frames)
                {
                    tiffImage.ActiveFrame = frame;

                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.webp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (WebPOptions webpOptions = new WebPOptions())
                    {
                        ((RasterImage)tiffImage).Save(outputPath, webpOptions);
                    }

                    pageIndex++;
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
 * 1. When you need to extract each page of a scanned multi‑page TIFF and save them as lightweight WebP images for faster web loading.
 * 2. When you want to generate individual WebP thumbnails from a multi‑page document to display in a gallery or preview pane.
 * 3. When you must convert archival TIFF files into a modern format while preserving page order by naming each output with its page index.
 * 4. When you are building a server‑side service that receives multi‑page TIFF uploads and returns separate WebP files for downstream image processing pipelines.
 * 5. When you need to automate batch conversion of TIFF reports into WebP assets for inclusion in mobile applications with limited bandwidth.
 */
