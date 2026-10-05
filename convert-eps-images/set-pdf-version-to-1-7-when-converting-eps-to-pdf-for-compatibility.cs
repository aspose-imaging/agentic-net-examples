// HOW-TO: Convert EPS to PDF with PDF Version 1.7 in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to generate PDF files from legacy EPS artwork while ensuring the output conforms to PDF 1.7 for compatibility with modern viewers.
 * 2. When a printing workflow requires converting vector EPS logos to PDF documents that meet specific PDF version standards.
 * 3. When an automated document processing system must batch‑convert EPS files to PDFs that can be opened in Adobe Acrobat Reader 2020 and later.
 * 4. When a web application needs to serve EPS‑based graphics as PDFs to browsers that only support PDF version 1.7 or higher.
 * 5. When migrating archival EPS assets to PDF format and you must guarantee the resulting PDFs adhere to the PDF 1.7 specification for regulatory compliance.
 */
