using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source JPG image
        string jpgPath = @"C:\Images\source.jpg";

        // Desired output PDF file path
        string pdfPath = @"C:\Images\merged.pdf";

        // Load the JPG image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(jpgPath))
        {
            // Configure OTG rasterization options – required when converting to PDF via vector rasterization
            OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
            {
                // Preserve the original image dimensions
                PageSize = image.Size
            };

            // Set up PDF save options and attach the OTG rasterization settings
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgRaster
            };

            // Save the loaded JPG as a PDF document
            image.Save(pdfPath, pdfOptions);
        }
    }
}