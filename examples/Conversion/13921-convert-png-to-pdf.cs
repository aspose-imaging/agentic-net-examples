using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Define input PNG file and output PDF file paths
        string dir = @"c:\temp\";
        string pngPath = Path.Combine(dir, "input.png");
        string pdfPath = Path.Combine(dir, "output.pdf");

        // Load the PNG image using the Image.Load method
        using (Image image = Image.Load(pngPath))
        {
            // Create PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            image.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine("PNG image has been successfully converted to PDF.");
    }
}