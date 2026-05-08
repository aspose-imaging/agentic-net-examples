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
            string inputDir = @"C:\Temp\WebPInput";
            string outputDir = @"C:\Temp\PdfOutput";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding PDF output path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Record memory usage before conversion
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long memoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;

                // Load the WebP image and save it as PDF
                using (WebPImage webpImage = new WebPImage(inputPath))
                {
                    webpImage.Save(outputPath, new PdfOptions());
                }

                // Record memory usage after conversion
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long memoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;

                // Output conversion and memory information
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                Console.WriteLine($"Memory before: {memoryBefore / 1024} KB, after: {memoryAfter / 1024} KB, delta: {(memoryAfter - memoryBefore) / 1024} KB");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}