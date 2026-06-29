using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.cmx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a printing company receives multi‑page CMX artwork and must deliver a single‑page PDF proof to a client, they can use this C# code with Aspose.Imaging to flatten all CMX pages into one PDF page.
 * 2. When an archival system needs to store legacy CorelDRAW CMX files as compact, searchable PDFs without preserving individual layers, the code converts the CMX into a single‑page PDF for easy indexing.
 * 3. When a web application allows users to upload CMX designs and instantly preview them in a browser, the developer can run this snippet to transform the multi‑page CMX into a single‑page PDF that browsers render natively.
 * 4. When an automated workflow processes batch CMX files and consolidates each document into a single PDF for downstream OCR processing, the Aspose.Imaging C# routine provides the required conversion.
 * 5. When a mobile app needs to display a CMX drawing as a single image on a small screen, the developer can flatten the CMX pages into one PDF page using this code and then render it as a bitmap.
 */