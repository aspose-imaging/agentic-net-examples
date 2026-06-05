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
            // Define input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with author metadata
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo()
                };
                pdfOptions.PdfDocumentInfo.Author = "Example";

                // Export to PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert legacy DjVu scans of technical manuals into searchable PDF files while embedding author metadata for document management systems.
 * 2. When an application must batch‑process archived DjVu images from a file server and produce PDF reports that include the creator’s name for compliance auditing.
 * 3. When a web service receives user‑uploaded DjVu artwork and must deliver a PDF version with proper author attribution for digital publishing workflows.
 * 4. When a desktop utility has to validate the existence of a DjVu file, create the output folder, and export the image to PDF using Aspose.Imaging’s PdfOptions to set the Author field.
 * 5. When integrating C# code into a document‑conversion pipeline that requires preserving image quality while adding PDF metadata such as author for downstream indexing.
 */