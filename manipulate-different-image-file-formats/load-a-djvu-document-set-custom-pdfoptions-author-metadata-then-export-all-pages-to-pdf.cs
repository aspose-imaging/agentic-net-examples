// HOW-TO: Convert DjVu Document to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\document.djvu";
                string outputPath = "Output\\document.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo { Author = "Custom Author" };
                    djvuImage.Save(outputPath, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive scanned books stored as DjVu files and wants the resulting PDFs to include the author's name for proper cataloging.
 * 2. When integrating a document‑management system that receives DjVu uploads and must output searchable PDFs with consistent metadata.
 * 3. When building a batch conversion tool that transforms multiple DjVu pages into a single PDF while embedding custom author information for compliance reports.
 * 4. When creating a digital library where each PDF must carry author metadata to improve search engine indexing and user discovery.
 * 5. When a publishing workflow requires converting DjVu illustrations to PDF and setting the author field programmatically to match the original creator.
 */
