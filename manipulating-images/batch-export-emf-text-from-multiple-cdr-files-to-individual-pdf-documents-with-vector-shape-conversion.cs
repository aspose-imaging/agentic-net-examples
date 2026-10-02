// HOW-TO: Batch Convert Multiple CDR Files to PDF with Vector Shapes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CdrToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputCdrFiles";
                string outputDirectory = @"C:\OutputPdfFiles";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all CDR files in the input directory
                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

                foreach (string inputPath in cdrFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        PdfOptions pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
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
 * 1. When you need to automatically convert a folder of CorelDRAW (CDR) drawings into separate PDF files while keeping text as scalable vector shapes.
 * 2. When a print shop wants to generate print‑ready PDFs from multiple CDR designs without rasterizing the artwork.
 * 3. When a document management system must ingest CDR assets and store them as searchable PDF documents in bulk.
 * 4. When a CI/CD pipeline has to transform newly added CDR resources into PDFs for downstream reporting or archiving.
 * 5. When a Windows service processes incoming CDR files and creates PDF versions that preserve exact layout and vector quality for downstream editing.
 */
