using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Pdf;

class MergeJpgToPdfViaEmf
{
    static void Main()
    {
        // Paths for source JPG, intermediate EMF and final PDF
        string jpgPath = @"C:\Images\source.jpg";
        string emfPath = @"C:\Images\intermediate.emf";
        string pdfPath = @"C:\Images\result.pdf";

        // Load the JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Define rasterization options for EMF conversion – page size matches the JPG dimensions
            var emfRasterOptions = new EmfRasterizationOptions
            {
                PageSize = jpgImage.Size
            };

            // Save the JPG as an EMF file (rasterized into vector format)
            jpgImage.Save(emfPath, new EmfOptions { VectorRasterizationOptions = emfRasterOptions });
        }

        // Load the generated EMF image
        using (Image emfImage = Image.Load(emfPath))
        {
            // Configure PDF saving options (automatic image compression)
            var pdfOptions = new PdfOptions
            {
                ImageCompression = PdfImageCompressionOptions.Auto
            };

            // Save the EMF as a PDF document
            emfImage.Save(pdfPath, pdfOptions);
        }
    }
}