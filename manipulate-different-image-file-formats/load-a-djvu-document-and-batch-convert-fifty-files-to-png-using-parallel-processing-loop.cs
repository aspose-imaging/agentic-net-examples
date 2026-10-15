// HOW-TO: Convert First 50 Pages of DjVu to PNG in Parallel C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

namespace DjvuBatchConvert
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.djvu";
            string outputDirectory = "output";

            try
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Load the DjVu document
                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    int totalPages = djvuImage.PageCount;
                    int pagesToConvert = Math.Min(50, totalPages);

                    // Parallel conversion of pages to PNG
                    Parallel.For(0, pagesToConvert, pageIndex =>
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex + 1}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set up PNG options with specific page selection
                        var pngOptions = new PngOptions();
                        var multiPageOptions = new DjvuMultiPageOptions(pageIndex);
                        pngOptions.MultiPageOptions = multiPageOptions;

                        // Save the selected page as PNG
                        djvuImage.Save(outputPath, pngOptions);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract individual pages from a multi‑page DjVu document and generate PNG thumbnails for a web gallery.
 * 2. When a server‑side document processing pipeline must quickly render up to fifty DjVu pages as PNG images using all CPU cores.
 * 3. When building a desktop application that previews DjVu files by converting selected pages to PNG without loading the whole file into memory.
 * 4. When an automated batch job prepares PNG assets from DjVu manuals for inclusion in a mobile app’s offline help system.
 * 5. When you want to speed up conversion of large DjVu scans by processing pages concurrently and saving each page as a separate PNG file.
 */
