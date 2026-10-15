// HOW-TO: Retry Loading Image on Transient I/O Errors in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Retry mechanism for transient I/O errors during image loading
            const int maxRetries = 3;
            const int delayMilliseconds = 1000;
            Image image = null;

            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    image = (Image)Image.Load(inputPath);
                    break; // Success
                }
                catch (IOException)
                {
                    if (attempt == maxRetries - 1)
                    {
                        throw; // Re‑throw after final attempt
                    }
                    Thread.Sleep(delayMilliseconds);
                }
            }

            if (image == null)
            {
                Console.Error.WriteLine("Failed to load image after retries.");
                return;
            }

            // Placeholder for image filtering operations
            // e.g., apply a filter or transformation here

            // Save the processed image
            image.Save(outputPath);
            image.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must load a PNG file from a network share that may temporarily be unavailable, this retry logic ensures the image is eventually loaded before applying filters.
 * 2. When processing large batches of images in an automated pipeline, the code prevents occasional disk read failures from aborting the entire job by retrying the load operation.
 * 3. When integrating Aspose.Imaging into a web service that receives user‑uploaded images, the retry mechanism handles brief I/O glitches caused by high concurrency or cloud storage latency.
 * 4. When performing image transformations such as sharpening or color correction, developers can use this pattern to guarantee the source image is successfully loaded even if the file system temporarily locks the file.
 * 5. When deploying a Windows service that monitors a folder and processes new PNG files, the retry loop protects against transient file‑access errors before saving the filtered result.
 */
