// HOW-TO: Extract Each Page from a Multi‑Page CDR to Separate PDFs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        string inputPath = "input.cdr";
        string outputDirectory = "output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is not IMultipageImage multipageImage)
                {
                    Console.Error.WriteLine("The loaded file is not a multipage image.");
                    return;
                }

                int pageNumber = 0;
                foreach (var page in multipageImage.Pages)
                {
                    pageNumber++;
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pdfOptions = new PdfOptions();
                    page.Save(outputPath, pdfOptions);
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
 * 1. When you need to split a multi‑page CorelDRAW (CDR) document into individual PDF files for separate printing or distribution.
 * 2. When an automated workflow must convert each vector page of a CDR file into PDFs for downstream processing such as OCR or digital signing.
 * 3. When a web service receives uploaded CDR files and must store each page as a standalone PDF for easy preview in browsers.
 * 4. When a desktop application has to archive each page of a complex CDR design as separate PDF pages to meet regulatory document‑management requirements.
 * 5. When a batch job processes a folder of CDR files and extracts every page into PDFs to integrate with a document‑management system that only accepts PDF format.
 */
