using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and save as PDF
            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When a web application needs to convert user‑uploaded JPEG photos to PDF and store the PDFs in a shared network folder that is mapped to a cloud storage service such as OneDrive or SharePoint for later retrieval by other team members.
 * 2. When an automated document‑processing pipeline runs nightly, transforms scanned images into searchable PDF files, and saves them to a mapped drive that points to an Azure Files share so that downstream services can access them without additional authentication steps.
 * 3. When a desktop utility creates PDF invoices from product images and writes them to a mapped drive representing an Amazon S3 bucket mounted via a file‑system gateway, enabling accountants to open the PDFs directly from their file explorer.
 * 4. When a Windows service monitors an “Input” directory, converts each new JPG to PDF, and deposits the PDFs into a mapped drive that syncs with Google Drive, ensuring remote collaborators can instantly view the converted documents.
 * 5. When a batch job processes marketing assets, converts high‑resolution JPEG banners to PDF for archival, and saves the PDFs to a network‑mapped drive linked to a corporate Dropbox folder so that the marketing team can access the files from any device.
 */