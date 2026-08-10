// HOW-TO: Profile Memory Usage During Batch WebP to PDF Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Temp\WebPBatch\Input";
            string outputDirectory = @"C:\Temp\WebPBatch\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all WebP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.webp", SearchOption.AllDirectories);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same file name with .pdf extension)
                string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(relativePath, ".pdf"));

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Memory usage before conversion
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                long memoryBefore = GC.GetTotalMemory(true);

                // Load WebP image and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }

                // Memory usage after conversion
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                long memoryAfter = GC.GetTotalMemory(true);

                // Report memory delta
                long memoryDelta = memoryAfter - memoryBefore;
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                Console.WriteLine($"Memory before: {memoryBefore / 1024} KB, after: {memoryAfter / 1024} KB, delta: {memoryDelta / 1024} KB");
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
 * 1. When you need to convert thousands of WebP images to PDF files in a .NET application while ensuring the process does not cause memory leaks.
 * 2. When you want to monitor and log memory consumption before and after each image conversion to optimize resource usage in a server‑side batch job.
 * 3. When you are building an automated document generation pipeline that must preserve image quality by using Aspose.Imaging to render WebP images into PDF documents.
 * 4. When you need to validate that garbage collection correctly frees image objects during large‑scale conversions on limited‑memory environments.
 * 5. When you are troubleshooting unexpected out‑of‑memory exceptions in a background service that processes WebP files into PDFs.
 */
