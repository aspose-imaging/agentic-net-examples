using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Save all pages to a single PDF document
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to convert scanned archival documents stored as DjVu files into a single searchable PDF for easy distribution to clients.
 * 2. When an application must batch‑process multi‑page DjVu ebooks and produce a consolidated PDF for e‑readers that only support PDF.
 * 3. When a legal‑tech solution has to preserve the original layout of multi‑page DjVu evidence files while exporting them to PDF for court filings.
 * 4. When a document‑management system requires on‑the‑fly conversion of user‑uploaded DjVu files into PDF to enable preview in web browsers.
 * 5. When a C# service automates the migration of legacy DjVu manuals into PDF format to integrate with existing PDF‑based workflows.
 */