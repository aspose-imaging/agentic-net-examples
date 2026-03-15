using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path
        string inputPath = "input.png";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Preserve original image metadata
                pdfOptions.KeepMetadata = true;

                // Embed document-level metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo()
                {
                    Title = "Converted PDF",
                    Author = "Aspose.Imaging",
                    Subject = "PNG to PDF conversion",
                    Keywords = "PNG, PDF, conversion, Aspose.Imaging"
                };

                // Use the original image resolution in the PDF
                pdfOptions.UseOriginalImageResolution = true;

                // Save the image as a PDF document
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}