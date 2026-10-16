// HOW-TO: Convert Selected Pages of Multiple DjVu Files to BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu files
            var inputFiles = new List<string>
            {
                @"C:\Input\sample1.djvu",
                @"C:\Input\sample2.djvu"
            };

            // Hardcoded output directory
            var outputDirectory = @"C:\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Define the page range to convert (inclusive)
            int startPage = 1; // 1-based index
            int endPage = 3;

            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DjVu image
                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    // Determine actual page count
                    int pageCount = djvuImage.PageCount;
                    int actualStart = Math.Max(startPage, 1);
                    int actualEnd = Math.Min(endPage, pageCount);

                    for (int pageIndex = actualStart; pageIndex <= actualEnd; pageIndex++)
                    {
                        // Prepare BMP options with page selection
                        var bmpOptions = new BmpOptions
                        {
                            MultiPageOptions = new DjvuMultiPageOptions(pageIndex - 1) // zero‑based index
                        };

                        // Build output file path
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_page{pageIndex}.bmp");

                        // Ensure directory for output path exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the selected page as BMP
                        djvuImage.Save(outputPath, bmpOptions);
                    }
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
 * 1. When a developer needs to extract the first three pages from several DjVu documents and save them as BMP images for further processing or archival.
 * 2. When an application must batch‑convert specific page ranges of scanned DjVu files into bitmap format for compatibility with legacy imaging tools.
 * 3. When a workflow requires generating BMP thumbnails of particular pages from multiple DjVu reports to display in a web portal.
 * 4. When a document management system has to extract and store selected DjVu pages as BMP files for OCR preprocessing.
 * 5. When a developer wants to automate the conversion of chosen DjVu pages to BMP in order to feed them into a machine‑learning model that only accepts bitmap inputs.
 */
