// HOW-TO: Profile Memory Usage While Converting WebP Images to PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputFolder = @"C:\InputWebP";
            string outputFolder = @"C:\OutputPDF";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all WebP files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.webp", SearchOption.AllDirectories);

            foreach (string inputPath in inputFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same file name with .pdf extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Memory usage before processing
                long beforeManaged = GC.GetTotalMemory(forceFullCollection: true);
                long beforePrivate = Process.GetCurrentProcess().PrivateMemorySize64;

                // Load WebP image
                using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
                {
                    // Save as PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    webpImage.Save(outputPath, pdfOptions);
                }

                // Memory usage after processing
                long afterManaged = GC.GetTotalMemory(forceFullCollection: true);
                long afterPrivate = Process.GetCurrentProcess().PrivateMemorySize64;

                // Report memory usage
                Console.WriteLine($"Processed: {inputPath}");
                Console.WriteLine($"Managed memory change: {afterManaged - beforeManaged} bytes");
                Console.WriteLine($"Private memory change: {afterPrivate - beforePrivate} bytes");
                Console.WriteLine();
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
 * 1. When processing thousands of WebP photos from a web crawler and need to ensure the conversion to PDF doesn't cause memory leaks.
 * 2. When building a server‑side service that receives user‑uploaded WebP files and returns PDF reports, and you want to monitor managed and private memory consumption.
 * 3. When migrating a legacy image archive from WebP to searchable PDF documents and need to verify that batch processing stays within memory limits.
 * 4. When creating an automated nightly job that converts product screenshots (WebP) to PDF catalogs and you must detect potential memory growth over time.
 * 5. When developing a desktop utility that lets users select a folder of WebP images and export them as PDFs while tracking memory usage to improve performance.
 */
