// HOW-TO: Batch Convert DjVu Files to Animated GIFs Using C# Aspose Imaging (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

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
            int processed = 0;

            foreach (string inputPath in files)
            {
                if (processed >= 10)
                    break;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".gif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    GifOptions gifOptions = new GifOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions()
                    };
                    djvu.Save(outputPath, gifOptions);
                }

                processed++;
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
 * 1. When you need to generate preview GIF animations from a collection of DjVu documents for a web gallery.
 * 2. When you want to automate the conversion of the first ten pages of scanned DjVu files into GIFs for email attachments.
 * 3. When a legacy system stores technical manuals as DjVu and you must provide them as lightweight GIFs for mobile devices.
 * 4. When you are building a batch processing pipeline that reads DjVu files from a folder and outputs GIFs for further image analysis.
 * 5. When you need to quickly create animated GIFs with default frame timing from DjVu slides for presentation slideshows.
 */
