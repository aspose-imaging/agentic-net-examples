using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Define input PNG and output PDF file paths.
        string dataDir = @"c:\temp\";
        string pngPath = Path.Combine(dataDir, "sample.png");
        string pdfPath = Path.Combine(dataDir, "sample.pdf");

        // Load the PNG image using the PngImage constructor (load rule).
        using (PngImage pngImage = new PngImage(pngPath))
        {
            // Prepare PDF export options.
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve the original image resolution for maximum fidelity.
                UseOriginalImageResolution = true
            };

            // Save the loaded PNG image as a PDF document (save rule).
            pngImage.Save(pdfPath, pdfOptions);
        }
    }
}