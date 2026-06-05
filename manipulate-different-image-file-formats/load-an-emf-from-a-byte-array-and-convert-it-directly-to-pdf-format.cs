using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.emf";
        string outputPath = "C:\\temp\\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF from a byte array
            byte[] emfBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(emfBytes))
            using (Image image = Image.Load(ms))
            {
                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Set PDF page size to match the EMF image size
                    PageSize = image.Size
                };

                // Save directly to PDF
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
 * 1. When a desktop application needs to convert user‑uploaded EMF vector graphics into PDF reports for printing or archiving.
 * 2. When an automated document‑generation service must read EMF files stored in a database as byte arrays and output PDF files for email attachments.
 * 3. When a batch‑processing script has to convert a folder of legacy Windows Metafile images to PDF without opening each file manually.
 * 4. When a web API receives EMF data via a POST request, loads it from a memory stream, and returns a PDF version to the client.
 * 5. When a migration tool extracts EMF assets from old software, resizes them to match page dimensions, and saves them directly as PDF for inclusion in new documentation.
 */