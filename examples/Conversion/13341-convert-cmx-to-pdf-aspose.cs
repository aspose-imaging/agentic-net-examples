using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Path to the source CMX file
        string sourcePath = "sample.cmx";

        // Path to the destination PDF file
        string outputPath = "output.pdf";

        // Load the CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(sourcePath))
        {
            // Create PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the CMX image as PDF
            cmxImage.Save(outputPath, pdfOptions);
        }
    }
}