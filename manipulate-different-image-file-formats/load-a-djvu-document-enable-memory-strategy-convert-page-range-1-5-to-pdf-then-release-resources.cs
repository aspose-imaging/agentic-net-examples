// HOW-TO: Convert DjVu Pages 1 To 5 To PDF With Memory Buffer In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\document.djvu";
            string outputPath = "Output\\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1024 * 1024 }))
            {
                IntRange range = new IntRange(1, 5);
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(range);
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.MultiPageOptions = multiPageOptions;

                djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to extract the first five pages of a large DjVu document and save them as a PDF while controlling memory usage in a C# application.
 * 2. When an archival system must batch‑convert specific page ranges from DjVu scans to searchable PDFs without loading the entire file into memory.
 * 3. When a desktop tool processes user‑uploaded DjVu files and offers a preview PDF of selected pages, using Aspose.Imaging’s buffer‑size hint to improve performance.
 * 4. When a server‑side service generates PDF excerpts from multi‑page DjVu manuals for on‑demand printing, ensuring efficient resource handling in .NET.
 * 5. When a document‑management workflow needs to programmatically convert a subset of DjVu pages to PDF and automatically clean up resources after saving.
 */
