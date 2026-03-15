using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToPdfConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string bmpPath = "input.bmp";

        // Desired path for the resulting PDF file
        string pdfPath = "output.pdf";

        // Load the BMP image using Aspose.Imaging's built‑in load method
        using (Image bmpImage = Image.Load(bmpPath))
        {
            // Create PDF save options – this ensures the image is saved in PDF format
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document.
            // The Save method handles the conversion while preserving image fidelity.
            bmpImage.Save(pdfPath, pdfOptions);
        }
    }
}