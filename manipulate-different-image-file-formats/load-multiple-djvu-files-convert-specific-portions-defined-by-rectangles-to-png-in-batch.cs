// HOW-TO: Batch Convert DjVu Pages to PNG Regions Using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputDjvu";
            string outputDirectory = "OutputPng";

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

            var rectangles = new[]
            {
                new Rectangle(0, 0, 500, 500),
                new Rectangle(100, 100, 300, 300)
            };

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (DjvuImage djvu = (DjvuImage)Image.Load(filePath))
                {
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle area = rectangles[i];
                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + $"_region{i + 1}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions pngOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            MultiPageOptions = new DjvuMultiPageOptions(0, area)
                        };

                        djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to extract specific page sections from a collection of DjVu documents and save them as separate PNG files for web preview.
 * 2. When an archival system must generate thumbnail images of defined areas within scanned DjVu files for quick visual indexing.
 * 3. When a publishing workflow requires batch conversion of selected regions of DjVu illustrations into high‑resolution PNG assets for inclusion in e‑books.
 * 4. When a document‑analysis tool has to process multiple DjVu files and isolate particular rectangles for OCR or pattern‑recognition preprocessing.
 * 5. When a digital signage application must automatically crop and convert recurring logo or banner sections from DjVu source files into PNG sprites for display.
 */
