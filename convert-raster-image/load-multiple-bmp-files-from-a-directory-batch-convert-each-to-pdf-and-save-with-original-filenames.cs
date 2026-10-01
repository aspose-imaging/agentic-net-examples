// HOW-TO: Batch Convert Multiple BMP Images to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

namespace BatchBmpToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "InputBmpFiles";
                string outputDirectory = "OutputPdfFiles";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string inputPath in bmpFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Build output PDF path with same filename (different extension)
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load BMP and save as PDF
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath);
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
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically turn a folder of legacy BMP screenshots into searchable PDF files for archival.
 * 2. When an application must generate PDF catalogs from a batch of product BMP images without manual intervention.
 * 3. When a Windows service has to convert scanned BMP documents to PDF for easier email attachment and printing.
 * 4. When a CI/CD pipeline requires converting generated BMP test output into PDF reports for stakeholder review.
 * 5. When a developer wants to migrate a legacy BMP asset library to PDF format while preserving original filenames for consistency.
 */
