// HOW-TO: Cancel Batch Median Filter Processing with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputFolder = "InputImages";
            string outputFolder = "OutputImages";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Cancellation token source
            var cts = new System.Threading.CancellationTokenSource();

            // Start a background thread to listen for a key press to cancel
            var cancelThread = new System.Threading.Thread(() =>
            {
                Console.WriteLine("Press any key to abort processing...");
                Console.ReadKey(true);
                cts.Cancel();
            });
            cancelThread.IsBackground = true;
            cancelThread.Start();

            // Get all files in the input folder
            string[] files = Directory.GetFiles(inputFolder);
            foreach (string inputPath in files)
            {
                if (cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Processing aborted by user.");
                    break;
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster)
                    {
                        // Apply median filter with size 3
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                        // Save as PNG
                        raster.Save(outputPath, new PngOptions());
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                    }
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
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
 * 1. When you need to apply a noise‑reducing median filter to a large set of images and allow the user to stop the operation midway.
 * 2. When processing scanned documents in bulk and you want to let a technician abort the job if a faulty file is encountered.
 * 3. When building a desktop utility that converts images from one folder to another while applying a filter, and you need responsive cancellation via a key press.
 * 4. When integrating Aspose.Imaging into a server‑side service that processes image batches and must respect cancellation tokens from a client request.
 * 5. When creating an automated photo‑enhancement pipeline that must handle unexpected interruptions without leaving partially processed files.
 */
