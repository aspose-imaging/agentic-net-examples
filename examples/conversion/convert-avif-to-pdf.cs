using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class AvifToPdfConverter
{
    static void Main()
    {
        // Path to the source AVIF image
        string avifPath = "input.avif";

        // Desired output PDF file path
        string pdfPath = "output.pdf";

        // Load the AVIF image using Aspose.Imaging's load method
        using (Image avifImage = Image.Load(avifPath))
        {
            // Create PDF save options (default settings)
            var pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            avifImage.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed: " + pdfPath);
    }
}