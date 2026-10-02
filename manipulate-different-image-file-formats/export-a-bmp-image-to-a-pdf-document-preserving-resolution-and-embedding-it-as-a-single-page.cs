// HOW-TO: Convert BMP Image To Single-Page PDF With Original Resolution In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PdfOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to embed a high‑resolution BMP diagram into a PDF report without losing detail.
 * 2. When an application must generate printable PDFs from legacy BMP assets for archiving.
 * 3. When a web service converts user‑uploaded BMP files to PDF for easy viewing on any device.
 * 4. When automating batch processing to turn a folder of BMP scans into single‑page PDF documents.
 * 5. When integrating Aspose.Imaging in a C# workflow to preserve image resolution while creating PDF invoices.
 */
