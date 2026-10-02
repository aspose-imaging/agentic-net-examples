// HOW-TO: Extract a Rectangle from DjVu and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    Rectangle area = new Rectangle(20, 20, 250, 250);
                    pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(0, area);
                    djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a PDF preview of a specific area of a large DjVu scan, such as a signature block, without converting the entire document.
 * 2. When you want to extract a portion of a multi‑page DjVu file (e.g., the first page) and embed it as a PDF page for reporting or documentation purposes.
 * 3. When an application must provide users with a downloadable PDF of a selected region from a DjVu technical drawing, preserving exact dimensions.
 * 4. When automating batch processing to crop consistent rectangular sections from DjVu files and save them as separate PDF files for archival.
 * 5. When integrating Aspose.Imaging in a C# service that converts a defined rectangle of a DjVu image into a PDF for downstream OCR or text extraction pipelines.
 */
