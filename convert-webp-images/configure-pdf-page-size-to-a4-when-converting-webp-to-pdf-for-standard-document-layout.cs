using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.webp";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.FileFormats.Webp.WebPImage webpImage = new Aspose.Imaging.FileFormats.Webp.WebPImage(inputPath))
            {
                var pdfOptions = new PdfOptions();
                pdfOptions.PageSize = new Aspose.Imaging.SizeF(595f, 842f); // A4 size in points
                webpImage.Save(outputPath, pdfOptions);
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
 * 1. When generating printable reports that include WebP graphics, a developer can use this code to convert each WebP image to an A4‑sized PDF page for consistent document layout.
 * 2. When building an automated batch job that archives web‑optimized images as PDF files for legal or compliance purposes, the snippet ensures the PDFs use the standard A4 dimensions.
 * 3. When creating a desktop application that lets users export their WebP photos to PDF for sharing with colleagues who only view PDFs, the code sets the page size to A4 so the output matches typical office paper.
 * 4. When integrating Aspose.Imaging into a C# web service that receives WebP uploads and returns PDF documents, the example demonstrates how to specify the A4 page size to avoid scaling issues on downstream printers.
 * 5. When preparing marketing collateral that combines WebP assets with text in a PDF brochure, developers can employ this code to maintain A4 page proportions and preserve image quality during the conversion.
 */