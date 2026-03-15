using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file path
        string inputWebPPath = @"C:\Images\sample.webp";

        // Output PDF file path
        string outputPdfPath = @"C:\Images\sample.pdf";

        // Load the WebP image (supports both single-frame and animated WebP)
        using (Image webpImage = Image.Load(inputWebPPath))
        {
            // Prepare PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Optional: set the PDF page size to match the WebP image dimensions
            // This ensures the image fits the page without scaling.
            pdfOptions.PageSize = new Size(webpImage.Width, webpImage.Height);

            // Save the WebP image (or its active frame) as a PDF document.
            // For animated WebP, only the active frame is saved.
            webpImage.Save(outputPdfPath, pdfOptions);
        }
    }
}