// HOW-TO: Resize PNG to 1024x768 and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to the required dimensions
                image.Resize(1024, 768);

                // Set up PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the resized image directly as a PDF
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
 * 1. When you need to generate a PDF report from a high‑resolution PNG thumbnail that must fit a standard slide size.
 * 2. When an e‑commerce platform requires product images resized to 1024×768 before embedding them in PDF catalogs.
 * 3. When a document automation system must convert user‑uploaded PNG screenshots into PDF pages with consistent dimensions.
 * 4. When a batch job prepares marketing assets by scaling PNG banners and saving them as PDF files for printing.
 * 5. When a web service creates printable PDFs from PNG logos, ensuring the logo fits within a 1024×768 layout.
 */
