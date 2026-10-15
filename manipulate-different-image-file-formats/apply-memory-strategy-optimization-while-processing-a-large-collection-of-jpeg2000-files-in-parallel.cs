// HOW-TO: Convert JPEG2000 Files to JPEG in Parallel with Memory Optimization in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.jp2");

            files.AsParallel().ForAll(inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions { BufferSizeHint = 100 };

                using (Jpeg2000Image image = (Jpeg2000Image)Image.Load(inputPath, loadOptions))
                {
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert a large set of JP2 satellite images to standard JPEGs while keeping RAM usage low.
 * 2. When you want to speed up image conversion by processing multiple JPEG2000 files simultaneously on a multi‑core server.
 * 3. When you must ensure each JP2 file is loaded with a custom buffer size to avoid out‑of‑memory errors during bulk processing.
 * 4. When you are building an automated pipeline that reads JP2 files from a folder, converts them to JPEG, and stores the results in another directory.
 * 5. When you need a simple C# solution that creates missing input or output folders, handles missing files gracefully, and logs errors during parallel image conversion.
 */
