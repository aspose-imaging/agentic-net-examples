using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpegToPdfConverter
{
    static void Main()
    {
        // Define the folder that contains the source JPEG and the destination PDF.
        string dataDir = @"C:\Temp\";

        // Load the JPEG image from file.
        using (Image jpegImage = Image.Load(dataDir + "sample.jpg"))
        {
            // Create PDF export options. Default options are sufficient for a basic conversion.
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document.
            jpegImage.Save(dataDir + "sample.pdf", pdfOptions);
        }
    }
}