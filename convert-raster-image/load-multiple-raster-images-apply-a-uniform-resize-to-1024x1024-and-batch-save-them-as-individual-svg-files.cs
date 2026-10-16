// HOW-TO: Batch Resize Raster Images to 1024x1024 and Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    image.Resize(1024, 1024);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = 1024,
                            PageHeight = 1024
                        };
                        image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate uniformly sized vector thumbnails from a collection of photos for a web gallery.
 * 2. When you must convert a batch of scanned PNG or JPEG documents into SVG files for scalable printing without losing quality.
 * 3. When an e‑commerce platform requires all product images to be resized to a standard 1024×1024 canvas and stored as SVG for responsive design.
 * 4. When a mobile app preprocesses user‑uploaded images by resizing them and converting to SVG to reduce bandwidth and enable infinite zoom.
 * 5. When a digital asset management system automates the transformation of legacy raster assets into vector format for archival and search indexing.
 */
