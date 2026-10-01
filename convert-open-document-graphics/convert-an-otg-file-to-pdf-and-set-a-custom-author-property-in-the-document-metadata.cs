// HOW-TO: Convert OTG to PDF and Set Author Metadata in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Custom Author";

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
 * 1. When you need to archive engineering drawings stored as OTG files into searchable PDF documents while embedding the creator’s name.
 * 2. When a reporting system must generate PDFs from OTG images and include a custom author field for compliance auditing.
 * 3. When a web application allows users to upload OTG graphics and automatically converts them to PDFs with personalized author metadata.
 * 4. When migrating legacy OTG assets to a PDF library and you want to preserve author information for document management.
 * 5. When creating batch scripts that process multiple OTG files into PDFs and set a consistent author property for branding purposes.
 */
