using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class TiffToPdfConverter
{
    static void Main()
    {
        // Path to the source TIFF file
        string tiffPath = "input.tif";

        // Desired output PDF file path
        string pdfPath = "output.pdf";

        // Load the TIFF image (raster image) from file
        using (Image image = Image.Load(tiffPath))
        {
            // Cast to TiffImage to access TIFF‑specific members if needed
            TiffImage tiffImage = image as TiffImage;

            // Prepare PDF save options – default options preserve the original raster data
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded TIFF image as a PDF document while keeping original fidelity
            tiffImage.Save(pdfPath, pdfOptions);
        }
    }
}