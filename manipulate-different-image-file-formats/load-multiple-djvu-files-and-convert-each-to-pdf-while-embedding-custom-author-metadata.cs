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
            // Define input and output directories relative to the current directory
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all DjVu files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in inputFiles)
            {
                // Validate each input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu image from file stream and convert to PDF with author metadata
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo
                        {
                            Author = "Custom Author"
                        },
                        // Export all pages
                        MultiPageOptions = new DjvuMultiPageOptions()
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
 * 1. When a developer needs to batch‑convert a collection of scanned DjVu documents into PDF files while embedding the author’s name as metadata for compliance reporting.
 * 2. When an application must automate the migration of legacy DjVu e‑books to PDF format and add custom author information to preserve copyright details.
 * 3. When a document management system requires a C# routine that reads multiple DjVu files from a folder, converts each to PDF, and stores the PDFs with author metadata for indexing.
 * 4. When a legal firm wants to programmatically transform archived DjVu case files into PDFs and tag each file with the responsible attorney’s name using Aspose.Imaging.
 * 5. When a cloud‑based service processes user‑uploaded DjVu images in bulk, converts them to PDF, and includes custom author metadata to support personalized document generation.
 */