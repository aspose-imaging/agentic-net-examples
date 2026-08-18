// HOW-TO: Convert DjVu To PDF With Custom Author Metadata In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".djvu", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo { Author = "Example" }
                    };
                    djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive scanned documents originally in DjVu format as PDF files that include the author's name for proper attribution.
 * 2. When a document management system requires PDFs with metadata, and you must convert multiple DjVu files in a folder automatically.
 * 3. When generating PDF reports from DjVu images while embedding author information for compliance or legal purposes.
 * 4. When building a batch conversion tool that processes all DjVu files in an input directory and saves PDFs with consistent author metadata.
 * 5. When integrating Aspose.Imaging into a C# application to transform DjVu ebooks into searchable PDFs with author details for library cataloging.
 */
