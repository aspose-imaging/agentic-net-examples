using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        // Path to the source BIGTIFF file
        string inputPath = "input.tif";

        // Desired output PDF file path
        string outputPath = "output.pdf";

        // Load the BIGTIFF image using Aspose.Imaging's Image.Load method.
        // The returned object is cast to BigTiffImage to access BIGTIFF‑specific members if needed.
        using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
        {
            // Create PDF save options. Default settings preserve the original raster fidelity.
            PdfOptions pdfOptions = new PdfOptions();

            // Save the BIGTIFF image as a PDF document.
            bigTiff.Save(outputPath, pdfOptions);
        }
    }
}