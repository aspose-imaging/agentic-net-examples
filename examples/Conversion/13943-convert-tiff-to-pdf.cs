using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToPdfConverter
{
    static void Main()
    {
        // Path to the source TIFF file
        string tiffPath = @"C:\Temp\source.tif";

        // Desired output PDF file path
        string pdfPath = @"C:\Temp\output.pdf";

        // Load the TIFF raster image using the Aspose.Imaging load rule
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Create PDF save options (no specific rule exists, so free‑form code is used)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document using the Aspose.Imaging save rule
            tiffImage.Save(pdfPath, pdfOptions);
        }
    }
}