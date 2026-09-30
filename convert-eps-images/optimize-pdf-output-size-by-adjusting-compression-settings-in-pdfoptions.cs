// HOW-TO: Convert PNG to Optimized PDF with Document Title in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.png";
            string outputPath = "Output/output.pdf";

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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = "Optimized PDF"
                    };
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
 * 1. When you need to generate a PDF from a PNG image for web download while keeping the file size small.
 * 2. When you want to embed a custom title metadata into a PDF created from an image in a C# application.
 * 3. When you are building an automated report generator that converts chart screenshots (PNG) into searchable PDF documents.
 * 4. When you must ensure the output PDF is stored in a specific folder structure and created only if the source image exists.
 * 5. When you are handling image-to-PDF conversion in a try‑catch block to gracefully log errors in a .NET service.
 */
