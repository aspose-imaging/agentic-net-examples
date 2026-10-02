// HOW-TO: Convert DjVu Document to Multi‑Page PDF with Memory Optimization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

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

            LoadOptions loadOptions = new LoadOptions { BufferSizeHint = 10 * 1024 * 1024 };
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath, loadOptions))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to batch‑convert scanned DjVu archives into searchable PDF files while keeping memory usage low in a C# application.
 * 2. When a document‑management system must ingest large DjVu files and store them as PDF for downstream processing without exhausting server RAM.
 * 3. When an e‑learning platform wants to display DjVu lecture notes as PDFs on browsers, using Aspose.Imaging to handle the conversion efficiently.
 * 4. When a desktop utility processes user‑uploaded DjVu images and saves them as multi‑page PDFs, applying a buffer size hint to improve performance.
 * 5. When a cloud service automates the transformation of DjVu technical manuals into PDF format and needs to control memory consumption during the conversion.
 */
