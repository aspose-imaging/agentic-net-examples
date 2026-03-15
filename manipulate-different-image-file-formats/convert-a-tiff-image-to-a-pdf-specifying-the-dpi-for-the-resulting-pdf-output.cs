using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToPdfConverter
{
    static void Main()
    {
        // Input TIFF file path
        string tiffPath = @"C:\Temp\input.tif";

        // Output PDF file path
        string pdfPath = @"C:\Temp\output.pdf";

        // Desired DPI for the PDF output
        const double dpiX = 300.0;
        const double dpiY = 300.0;

        // Load the TIFF image using the standard Image.Load method (lifecycle rule)
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Set the resolution (DPI) for the image – this will affect the PDF rendering
            tiffImage.SetResolution(dpiX, dpiY);

            // Prepare PDF save options (no custom presentation logic required)
            var pdfOptions = new PdfOptions();

            // Save the image as PDF using the standard Image.Save method (lifecycle rule)
            tiffImage.Save(pdfPath, pdfOptions);
        }
    }
}