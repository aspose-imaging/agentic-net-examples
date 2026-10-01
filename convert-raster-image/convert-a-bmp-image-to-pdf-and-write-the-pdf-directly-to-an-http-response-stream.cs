// HOW-TO: Convert BMP Image to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();

                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        image.Save(fs, pdfOptions);
                    }
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
 * 1. When you need to generate a PDF report from legacy BMP scans in a C# desktop application.
 * 2. When a web service must deliver a BMP‑based diagram as a downloadable PDF to clients.
 * 3. When automating batch processing to archive BMP assets as searchable PDF files on a server.
 * 4. When integrating Aspose.Imaging into a document management system to convert uploaded BMP images to PDF for consistent viewing.
 * 5. When creating a C# utility that transforms user‑provided BMP pictures into PDF format for email attachment or printing.
 */
