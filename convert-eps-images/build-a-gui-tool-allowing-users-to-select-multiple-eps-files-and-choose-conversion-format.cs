// HOW-TO: Batch Convert EPS Files to PNG, JPG, or PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            string format = "png";

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string extension = format switch
                {
                    "png" => "png",
                    "jpg" => "jpg",
                    "jpeg" => "jpg",
                    "pdf" => "pdf",
                    _ => null
                };

                if (extension == null)
                {
                    Console.Error.WriteLine($"Unsupported format: {format}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}.{extension}");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    switch (extension)
                    {
                        case "png":
                            image.Save(outputPath, new PngOptions());
                            break;
                        case "jpg":
                            image.Save(outputPath, new JpegOptions());
                            break;
                        case "pdf":
                            image.Save(outputPath, new PdfOptions());
                            break;
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
 * 1. When a developer needs to let users drop a folder of EPS artwork and export each file as PNG for web preview.
 * 2. When an application must generate high‑resolution JPEG thumbnails from a collection of EPS logos for email newsletters.
 * 3. When a reporting tool has to transform EPS diagrams into PDF pages for inclusion in printable documents.
 * 4. When a batch processing script must automatically convert incoming EPS assets to a common raster format before uploading to a CMS.
 * 5. When a Windows utility requires a simple UI to select multiple EPS files and choose the desired output format without manual command‑line steps.
 */
