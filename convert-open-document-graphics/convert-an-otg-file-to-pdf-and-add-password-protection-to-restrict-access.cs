// HOW-TO: Convert OTG File To PDF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
 * 1. When you need to programmatically transform OTG vector drawings into PDF documents for easy sharing or printing in a .NET application.
 * 2. When an automated server‑side workflow must batch‑convert stored OTG assets into PDFs to integrate with a document management system.
 * 3. When a desktop tool requires loading an OTG image, applying Aspose.Imaging options, and saving it as a PDF while preserving layout fidelity.
 * 4. When you want to generate PDF reports from OTG design files without manual user interaction, using C# and Aspose.Imaging.
 * 5. When integrating a file‑conversion service that receives OTG uploads and returns PDF files for downstream processing or archival.
 */
