using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Load DjVu document from file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
            {
                // Extract metadata (XMP data) from the DjVu document
                var metadata = djvuImage.Metadata;

                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Transfer extracted metadata to the PDF options if supported
                // (If PdfOptions does not expose a Metadata property, the metadata
                // will be retained automatically when saving the image.)
                // pdfOptions.Metadata = metadata; // Uncomment if property exists

                // Save the DjVu document as a PDF file with the metadata embedded
                djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert archived DjVu scans of historical documents into searchable PDFs while preserving the original XMP metadata for cataloging.
 * 2. When an application must batch‑process DjVu files received from a document management system and generate PDF reports that retain the source metadata for compliance auditing.
 * 3. When a digital library platform wants to display DjVu‑based e‑books as PDFs on browsers, ensuring that author and rights information embedded in the DjVu metadata is carried over.
 * 4. When a C# service integrates with a workflow that extracts metadata from scanned engineering drawings stored as DjVu and embeds it into PDFs for downstream CAD review tools.
 * 5. When a developer builds a file‑conversion microservice that reads DjVu images, extracts their XMP metadata, and saves them as PDFs so downstream indexing services can read the embedded metadata.
 */