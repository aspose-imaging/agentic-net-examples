// HOW-TO: Batch Convert DjVu Files to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define relative input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all DjVu files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DjVu image
                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    // Configure PDF options with custom author metadata
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo
                        {
                            Author = "Custom Author"
                        }
                    };

                    // Save the DjVu as PDF
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
 * 1. When a company needs to archive scanned DjVu documents as searchable PDFs and wants to tag each file with the author's name.
 * 2. When an application processes a folder of DjVu ebooks and converts them to PDF for distribution while preserving author information.
 * 3. When a legal firm batch‑converts client‑provided DjVu evidence files to PDF and adds custom author metadata for case management.
 * 4. When a developer builds a migration tool that transforms legacy DjVu image archives into PDF format with consistent author tags.
 * 5. When an automated workflow converts multiple DjVu graphics into PDFs for printing, ensuring the PDF metadata includes the designated author.
 */
