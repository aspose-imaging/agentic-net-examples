using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Path to the folder containing the PNG image.
        string dataDir = @"C:\Temp\";

        // Load the PNG image using the generic Image.Load method.
        // This works for any supported raster format, including PNG.
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Create PDF save options.  PdfOptions is part of Aspose.Imaging.ImageOptions.
            // No specific settings are required for a basic conversion.
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document.
            // The Save method overload with (string, ImageOptionsBase) is used.
            image.Save(dataDir + "sample.pdf", pdfOptions);
        }
    }
}