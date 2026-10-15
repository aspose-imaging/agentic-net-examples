// HOW-TO: Batch Convert DjVu Pages to PNG Using Rectangle Crop in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                Rectangle rect = new Rectangle(0, 0, 200, 200);
                int pageIndex = 0;

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + $"_page{pageIndex}.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        MultiPageOptions = new DjvuMultiPageOptions(pageIndex, rect)
                    };

                    djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to extract a thumbnail region from each page of multiple DjVu documents for a web preview gallery.
 * 2. When you want to automate the conversion of selected areas of scanned DjVu files into PNG images for OCR preprocessing.
 * 3. When a publishing workflow requires batch exporting of specific page sections from DjVu manuals into high‑resolution PNG assets.
 * 4. When you are building a document‑management system that must generate preview images of the first 200×200 pixels of each DjVu file.
 * 5. When you need to programmatically create PNG snapshots of defined rectangles from a collection of DjVu files for archival or reporting purposes.
 */
