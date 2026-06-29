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
            string inputDir = @"C:\Temp\WebPBatch";
            string outputDir = @"C:\Temp\PdfBatch";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Retrieve all WebP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.webp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the corresponding PDF output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Record memory usage before conversion
                long memBefore = Process.GetCurrentProcess().PrivateMemorySize64;
                long gcBefore = GC.GetTotalMemory(forceFullCollection: false);

                // Load the WebP image and save it as PDF
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PdfOptions());
                }

                // Force garbage collection to get a more accurate post‑conversion measurement
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // Record memory usage after conversion
                long memAfter = Process.GetCurrentProcess().PrivateMemorySize64;
                long gcAfter = GC.GetTotalMemory(forceFullCollection: false);

                // Output conversion result and memory delta
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                Console.WriteLine($"Process memory change: {memAfter - memBefore} bytes");
                Console.WriteLine($"GC memory change: {gcAfter - gcBefore} bytes");
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
 * 1. When a cloud‑based image‑processing service needs to convert thousands of user‑uploaded WebP graphics to PDF reports while ensuring the .NET application does not leak memory over long‑running batches.
 * 2. When an enterprise document‑management system automates archival of WebP‑based marketing assets into searchable PDF files and wants to monitor private memory and GC usage to maintain server stability.
 * 3. When a desktop utility that processes large folders of WebP screenshots into PDF portfolios is tested for memory consumption to guarantee smooth operation on low‑RAM workstations.
 * 4. When a CI/CD pipeline validates that a new version of the Aspose.Imaging for .NET library handles bulk WebP‑to‑PDF conversions without increasing the process’s private memory footprint.
 * 5. When a SaaS platform that offers on‑demand PDF generation from WebP images needs to profile memory usage to detect and fix potential leaks before scaling to millions of conversions per day.
 */