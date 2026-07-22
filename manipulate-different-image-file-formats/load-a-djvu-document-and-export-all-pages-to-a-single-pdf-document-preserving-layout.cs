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
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample.pdf";

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

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Save all pages to a single PDF preserving layout
                djvuImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert scanned archival DjVu documents into a single searchable PDF for easy distribution in a legal or historical research portal.
 * 2. When an application must batch‑process multi‑page DjVu files from a document management system and generate combined PDF reports while preserving the original layout.
 * 3. When a desktop utility is built to let end‑users select a DjVu e‑book and export all its pages into one PDF for reading on standard PDF viewers.
 * 4. When a cloud service ingests DjVu images uploaded by users and needs to store them as PDF files to integrate with existing PDF‑based workflows.
 * 5. When a migration script is required to transform legacy DjVu technical manuals into PDF format for inclusion in a company's knowledge base without losing page formatting.
 */