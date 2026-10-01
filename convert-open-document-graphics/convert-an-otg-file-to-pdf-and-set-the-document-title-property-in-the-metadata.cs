// HOW-TO: Convert OTG to PDF and Set Document Title in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
                    pdfOptions.PdfDocumentInfo.Title = "Document Title";
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
 * 1. When you need to turn an OTG vector graphic created in CorelDRAW into a searchable PDF while embedding a custom title for easier cataloging.
 * 2. When a document management system requires PDFs with proper metadata, and you must convert OTG files to PDF and set the Title property programmatically in C#.
 * 3. When generating automated reports that include engineering schematics stored as OTG, you can convert them to PDF and assign a meaningful title for end‑users.
 * 4. When batch‑processing a folder of OTG design files to create PDF archives, setting the document title ensures each PDF appears correctly in file explorers and PDF viewers.
 * 5. When integrating Aspose.Imaging into a web service that receives OTG uploads, you can convert the image to PDF and add a title metadata field before returning the file to the client.
 */
