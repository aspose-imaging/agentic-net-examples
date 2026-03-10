using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class MergeJpgToPdfUsingEmz
{
    static void Main()
    {
        // Paths for source JPG, intermediate EMZ and final PDF
        string jpgPath = @"C:\Images\source.jpg";
        string emzPath = @"C:\Images\intermediate.emz";
        string pdfPath = @"C:\Images\result.pdf";

        // Step 1: Load the JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Configure rasterization options to match the JPG size
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = jpgImage.Size
            };

            // Save as compressed EMZ (EMF compressed) using EmfOptions
            jpgImage.Save(emzPath, new EmfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Compress = true               // enable compression for EMZ
            });
        }

        // Step 2: Load the generated EMZ file
        using (Image emzImage = Image.Load(emzPath))
        {
            // Create PDF save options (default settings)
            var pdfOptions = new PdfOptions();

            // Save the EMZ image as a PDF document
            emzImage.Save(pdfPath, pdfOptions);
        }
    }
}