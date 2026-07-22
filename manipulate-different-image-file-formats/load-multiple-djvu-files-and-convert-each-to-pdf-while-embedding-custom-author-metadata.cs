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
            // Define input and output directories relative to the current directory
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all DjVu files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DjVu image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options with custom author metadata
                    var pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo
                        {
                            Author = "Custom Author"
                        }
                    };

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to batch‑convert a collection of scanned DjVu documents into PDF files while embedding a custom author name for compliance reporting.
 * 2. When an archival system requires automated migration of legacy DjVu e‑books to PDF format with author metadata to preserve attribution.
 * 3. When a document‑management workflow must process multiple DjVu images from a folder and generate PDFs that include a specific author tag for indexing in a content repository.
 * 4. When a C# application has to read DjVu files, convert each to PDF using Aspose.Imaging, and set the PdfDocumentInfo.Author property for digital rights tracking.
 * 5. When a batch‑processing script is needed to transform DjVu graphics into PDFs while automatically creating the output directory structure and consistently applying author metadata.
 */