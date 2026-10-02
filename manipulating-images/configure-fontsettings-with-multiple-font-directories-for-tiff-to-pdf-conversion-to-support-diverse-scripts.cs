// HOW-TO: Convert Multi-Page TIFF to PDF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to archive scanned multi‑page documents by converting TIFF files into searchable PDF files for easier distribution.
 * 2. When an application must generate printable PDFs from high‑resolution TIFF images received from medical imaging equipment.
 * 3. When a web service processes user‑uploaded TIFF files and returns PDF versions for viewing in browsers without native TIFF support.
 * 4. When a batch job converts large volumes of TIFF files to PDFs to reduce storage size and improve document management workflows.
 * 5. When a reporting tool embeds TIFF charts into PDF reports, requiring programmatic conversion of the image format within a C# application.
 */
