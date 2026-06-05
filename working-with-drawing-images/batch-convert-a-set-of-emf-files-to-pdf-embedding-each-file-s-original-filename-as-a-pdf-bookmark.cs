using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputFolder = @"C:\InputEmf";
            string outputFolder = @"C:\OutputPdf";

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output PDF path (same file name, .pdf extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options
                    var pdfOptions = new PdfOptions();

                    // Set core PDF options – enable a bookmark level
                    pdfOptions.PdfCoreOptions = new PdfCoreOptions
                    {
                        BookmarksOutlineLevel = 1 // first‑level outline entry
                    };

                    // Use the original file name as the document title (appears as a bookmark)
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = fileNameWithoutExt
                    };

                    // Save as PDF
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
 * 1. When a company needs to archive a collection of vector‑based EMF diagrams as searchable PDF files with each diagram listed as a bookmark for quick navigation.
 * 2. When an engineering team wants to generate project documentation by converting multiple AutoCAD‑exported EMF schematics into individual PDFs, using the original filenames as first‑level outline entries.
 * 3. When a legal department must submit a batch of signed EMF forms as PDFs, preserving the form names as PDF bookmarks to satisfy court filing requirements.
 * 4. When a publishing workflow requires turning a folder of EMF illustrations into PDF assets while automatically creating bookmarks that match the illustration titles for e‑book generation.
 * 5. When a software vendor provides a tool that transforms user‑uploaded EMF assets into PDF reports, ensuring each report page is titled with the source file name for easier indexing in a content management system.
 */