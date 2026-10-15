// HOW-TO: Batch Convert JPG PNG BMP Images to SVG in C# (Aspose.Imaging for .NET)
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

namespace ImageBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = @"C:\Images\Input";
                string outputFolder = @"C:\Images\Output";

                Directory.CreateDirectory(outputFolder);

                string[] extensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".tiff", ".tif", ".gif" };
                var files = Directory.GetFiles(inputFolder);
                foreach (var file in files)
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();
                    if (Array.IndexOf(extensions, ext) < 0)
                        continue;

                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(file))
                    {
                        var options = new SvgOptions();
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {file} -> {outputPath}");
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
 * 1. When you need to generate scalable SVG versions of a large set of raster photos for responsive web design.
 * 2. When an automated build process must preserve original filenames while converting JPEG, PNG, BMP, GIF, or TIFF files to vector format.
 * 3. When a desktop application has to export user‑uploaded images to SVG for further editing in vector graphics tools.
 * 4. When migrating a legacy image library to a format that scales without loss for high‑resolution printing.
 * 5. When creating an asset pipeline that converts multiple image types to SVG to reduce file size and improve rendering performance.
 */
