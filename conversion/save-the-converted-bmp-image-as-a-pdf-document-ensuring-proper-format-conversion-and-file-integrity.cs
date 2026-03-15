using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = @"C:\temp\sample.bmp";

        // Desired output PDF file path
        string pdfPath = @"C:\temp\sample.pdf";

        // Load the BMP image using Aspose.Imaging's lifecycle rule
        using (Image image = Image.Load(bmpPath))
        {
            // Create PDF export options (provided rule)
            PdfOptions pdfOptions = new PdfOptions();

            // Set the PDF page size to match the image dimensions (optional but ensures proper layout)
            pdfOptions.PageSize = new SizeF(image.Width, image.Height);

            // Save the image as a PDF document using the Save(string, ImageOptionsBase) rule
            image.Save(pdfPath, pdfOptions);
        }
    }
}