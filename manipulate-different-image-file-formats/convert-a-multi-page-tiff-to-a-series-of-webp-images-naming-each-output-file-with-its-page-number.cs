// HOW-TO: Convert Multi Page TIFF to Separate WebP Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The input file is not a TIFF image.");
                    return;
                }

                int pageIndex = 0;
                foreach (TiffFrame frame in tiffImage.Frames)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.webp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var options = new WebPOptions();
                    frame.Save(outputPath, options);
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
 * 1. When you need to extract each page of a scanned multi‑page TIFF document and save them as lightweight WebP images for faster web delivery.
 * 2. When a printing workflow requires converting archival TIFF pages into WebP thumbnails that are named with their page numbers for easy indexing.
 * 3. When an e‑commerce platform wants to display product manuals originally stored as TIFF stacks by serving each page as an optimized WebP image.
 * 4. When a mobile app must reduce storage usage by turning a multi‑page TIFF into individually compressed WebP files while preserving the original page order.
 * 5. When a batch processing script has to automate the conversion of TIFF slide decks into WebP images for inclusion in a digital catalog.
 */
