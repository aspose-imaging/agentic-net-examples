using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output\\result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare PDF saving options (default exports all pages)
                PdfOptions pdfOptions = new PdfOptions();

                // Save all pages to a single PDF file
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
 * 1. When a legal firm needs to convert scanned multi‑page DjVu case files into a single searchable PDF while preserving the original layout for court submissions.
 * 2. When an e‑learning platform automates the transformation of DjVu textbooks into PDF handouts that can be easily distributed to students.
 * 3. When a digital archiving system migrates historic DjVu documents to PDF to ensure long‑term accessibility and consistent page ordering.
 * 4. When a publishing company batch‑processes DjVu artwork portfolios into a single PDF catalog for client review without losing image quality.
 * 5. When a government agency consolidates multi‑page DjVu forms into a single PDF report for record‑keeping and compliance audits.
 */