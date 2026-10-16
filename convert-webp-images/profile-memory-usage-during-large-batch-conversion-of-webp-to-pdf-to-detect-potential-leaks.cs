// HOW-TO: Profile Memory Usage While Converting WebP Images to PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputWebP";
            string outputFolder = @"C:\OutputPDF";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all WebP files in the input folder
            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Record memory usage before conversion
                long memoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;

                // Load WebP image and save as PDF
                using (WebPImage image = (WebPImage)Image.Load(inputPath))
                {
                    PdfOptions options = new PdfOptions();
                    image.Save(outputPath, options);
                }

                // Record memory usage after conversion
                long memoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;

                // Output memory usage information
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                Console.WriteLine($"Memory before: {memoryBefore / 1024 / 1024} MB, after: {memoryAfter / 1024 / 1024} MB, delta: {(memoryAfter - memoryBefore) / 1024 / 1024} MB");
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
 * 1. When you need to monitor RAM consumption during a bulk WebP‑to‑PDF conversion to ensure the application doesn’t run out of memory.
 * 2. When you want to detect memory leaks in a long‑running service that processes thousands of WebP images into PDF reports.
 * 3. When you are optimizing a server‑side image pipeline and need to compare memory before and after each conversion step.
 * 4. When you are building a command‑line tool that converts user‑uploaded WebP files to PDF and must log memory usage for troubleshooting.
 * 5. When you are validating that the Aspose.Imaging WebPImage class releases resources correctly after saving PDFs in a batch job.
 */
