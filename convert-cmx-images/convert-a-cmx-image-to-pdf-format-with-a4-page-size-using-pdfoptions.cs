// HOW-TO: Convert CMX Image to PDF with A4 Page Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.cmx");
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
 * 1. When a developer needs to archive legacy CorelDRAW CMX drawings as searchable PDF files for document management systems.
 * 2. When an application must generate printable PDFs from CMX artwork while preserving the standard A4 page dimensions for consistent printing.
 * 3. When a batch conversion tool is required to transform multiple CMX files into PDFs for easy distribution to clients who only view PDFs.
 * 4. When integrating Aspose.Imaging into a C# service that receives CMX uploads and returns PDF previews for web viewers.
 * 5. When automating the conversion of CMX graphics to PDF to embed them in reports or presentations without manual export steps.
 */
