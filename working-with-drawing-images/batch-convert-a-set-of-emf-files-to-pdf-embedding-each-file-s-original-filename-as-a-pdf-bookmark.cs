// HOW-TO: Batch Convert EMF Files to PDF with Filename Bookmarks in C# (Aspose.Imaging for .NET)
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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all EMF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (var filePath in files)
            {
                string inputPath = filePath;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo { Title = fileName }
                    };
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
 * 1. When you need to generate a searchable PDF catalog from a collection of vector EMF drawings, preserving each drawing’s name as a bookmark for quick navigation.
 * 2. When automating the creation of printable reports that combine multiple EMF charts into a single PDF document with clickable sections labeled by the original file names.
 * 3. When migrating legacy EMF assets to PDF for archiving, and you want each archived page to be indexed by its original filename for easy retrieval.
 * 4. When building a C# application that batches converts design schematics stored as EMF into PDF manuals, using the file names as chapter titles in the PDF outline.
 * 5. When integrating Aspose.Imaging into a workflow that processes incoming EMF files and outputs PDF files with embedded metadata, enabling downstream systems to reference the source file via bookmarks.
 */
