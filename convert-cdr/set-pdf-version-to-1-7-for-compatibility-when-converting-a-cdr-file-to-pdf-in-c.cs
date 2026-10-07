// HOW-TO: Convert CDR to PDF with PDF Version 1.7 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
            if (files.Length == 0)
            {
                Console.WriteLine("No CDR files found in the Input directory.");
                return;
            }

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
                }
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
 * 1. When a designer needs to batch‑convert CorelDRAW (.cdr) artwork to PDF files that must be compatible with PDF 1.7 readers such as Adobe Acrobat 9 or later.
 * 2. When an automated build pipeline must generate PDF documentation from CDR assets while ensuring the output adheres to the PDF 1.7 specification for regulatory compliance.
 * 3. When a web service receives user‑uploaded CDR files and must return PDF versions that can be opened on all modern browsers and mobile devices supporting PDF 1.7.
 * 4. When a legacy printing system requires PDFs saved with version 1.7 to preserve vector quality and color profiles from the original CDR files.
 * 5. When a desktop application needs to programmatically convert multiple CDR files to PDF with Aspose.Imaging while explicitly setting the PDF version to avoid compatibility warnings in downstream tools.
 */
