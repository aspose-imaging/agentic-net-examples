using System;
using Aspose.Imaging.FileFormats.Png;

class PngToPdfConverter
{
    static void Main()
    {
        // Path to the source PNG image
        string pngPath = @"C:\Temp\source.png";

        // Desired output PDF file path
        string pdfPath = @"C:\Temp\result.pdf";

        // Load the PNG image using the PngImage constructor (load rule)
        using (PngImage pngImage = new PngImage(pngPath))
        {
            // Save the image as PDF. The Save method determines the format from the file extension.
            pngImage.Save(pdfPath);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}