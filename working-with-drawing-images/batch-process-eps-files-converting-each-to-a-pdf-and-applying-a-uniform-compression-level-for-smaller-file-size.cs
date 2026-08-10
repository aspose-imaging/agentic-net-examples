// HOW-TO: Batch Convert Multiple EPS Files to Compressed PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of EPS files to process
            string[] inputFiles = {
                @"C:\Images\Sample1.eps",
                @"C:\Images\Sample2.eps",
                @"C:\Images\Sample3.eps"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue; // Skip to next file
                }

                // Determine output PDF path (same folder, same name, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                string? outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? ".");

                // Configure PDF options with uniform compression
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        Compression = PdfImageCompressionOptions.Flate
                    }
                };

                // Load the EPS image and save as PDF using the configured options
                using (var epsImage = (EpsImage)Image.Load(inputPath))
                {
                    epsImage.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to generate smaller PDF reports from a collection of EPS graphics for faster email delivery.
 * 2. When an automated build pipeline must transform design assets (EPS) into PDF documents with uniform compression for archiving.
 * 3. When a web service receives multiple EPS uploads and must return compressed PDF versions for previewing in browsers.
 * 4. When a desktop application processes a batch of EPS logos and saves them as PDF files to meet print‑ready size constraints.
 * 5. When migrating legacy EPS artwork to PDF format while ensuring consistent file‑size reduction across all files.
 */
