using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file path
        string inputPath = "input.webp";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Set custom page size (A4 in points)
            pdfOptions.PageSize = new Aspose.Imaging.Size(595, 842);

            // Preserve original image metadata in the PDF
            pdfOptions.KeepMetadata = true;

            // Set PDF document metadata
            pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
            {
                Author = "Your Name",
                Title = "WebP to PDF conversion"
            };

            // Save the image as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}