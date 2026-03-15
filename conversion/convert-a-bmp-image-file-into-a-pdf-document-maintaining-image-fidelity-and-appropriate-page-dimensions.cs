using System;
using Aspose.Imaging.FileFormats.Bmp;          // BmpImage class
using Aspose.Imaging;                         // Base Image class (for disposal)

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = "input.bmp";

        // Desired output PDF file path
        string pdfPath = "output.pdf";

        // Load the BMP image using the BmpImage constructor (lifecycle rule)
        using (BmpImage bmpImage = new BmpImage(bmpPath))
        {
            // The image is loaded with its original dimensions and resolution,
            // ensuring fidelity when it is placed on a PDF page.

            // Save the image as PDF. The Save(string) overload determines the
            // output format from the file extension, so providing a ".pdf"
            // extension creates a PDF document with a page sized to the image.
            bmpImage.Save(pdfPath);
        }

        Console.WriteLine("Conversion completed: BMP -> PDF");
    }
}