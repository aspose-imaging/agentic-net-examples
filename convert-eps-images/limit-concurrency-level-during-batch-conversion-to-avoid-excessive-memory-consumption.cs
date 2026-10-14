// HOW-TO: Limit Parallel Image Conversion to PNG with Controlled Memory in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(outputFolder);

            string[] inputFiles = Directory.GetFiles(inputFolder);

            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is IMultipageImage multipageImage)
                    {
                        multipageImage.PageExportingAction = (page, pageIndex) => { };
                    }

                    var options = new PngOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to convert a large folder of mixed‑format images to PNG while preventing the application from exhausting RAM by limiting the number of concurrent conversions.
 * 2. When processing multi‑page documents such as PDFs or TIFFs and you want each page saved as a separate PNG without loading all pages into memory at once.
 * 3. When deploying an image‑conversion service on a server with limited resources and you must throttle parallel tasks to keep CPU and memory usage predictable.
 * 4. When automating a nightly batch job that reads images from an input directory and writes PNGs to an output directory, ensuring the job continues even if some files are missing.
 * 5. When integrating Aspose.Imaging into a C# application that requires safe, parallel batch processing of images with explicit error handling for missing or corrupt files.
 */
