using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Path to the source PNG image
        string pngPath = @"C:\Temp\input.png";

        // Desired path for the generated PDF document
        string pdfPath = @"C:\Temp\output.pdf";

        // Load the PNG image using the constructor that accepts a file path
        using (PngImage pngImage = new PngImage(pngPath))
        {
            // Create PDF save options (default settings are sufficient for a simple conversion)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF file using the overload that accepts options
            pngImage.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}