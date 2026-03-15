using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf; // Namespace for PDF options (if needed)

class BmpToPdf
{
    static void Main()
    {
        // Path to the source BMP image that contains an alpha channel
        string inputPath = "input.bmp";

        // Desired path for the resulting PDF document
        string outputPath = "output.pdf";

        // Load the BMP image using Aspose.Imaging's generic Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF saving options.
            // PdfOptions uses VectorRasterizationOptions to define how the raster image
            // is placed on the PDF page. Setting the background to Transparent
            // preserves the original alpha channel.
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new PdfVectorRasterizationOptions
                {
                    // Use the original image dimensions for the PDF page size
                    PageWidth = image.Width,
                    PageHeight = image.Height,

                    // Preserve transparency by using a transparent background
                    BackgroundColor = Color.Transparent
                }
            };

            // Save the loaded image as a PDF document while keeping transparency
            image.Save(outputPath, pdfOptions);
        }
    }
}