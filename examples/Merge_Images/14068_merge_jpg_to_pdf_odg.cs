using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class JpgToPdfViaOdg
{
    static void Main()
    {
        // Path to the source JPG image
        string inputJpgPath = @"C:\Images\sample.jpg";

        // Desired output PDF file path
        string outputPdfPath = @"C:\Images\sample.pdf";

        // Load the JPG image using the unified Image.Load method
        using (Image jpgImage = Image.Load(inputJpgPath))
        {
            // Configure ODG rasterization options – these options are used when
            // converting vector formats (ODG/OTG) to raster images inside the PDF.
            // Here we set a white background and match the PDF page size to the JPG size.
            OdgRasterizationOptions odgRasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = jpgImage.Size
            };

            // Set up PDF save options and assign the ODG rasterization options.
            PdfOptions pdfSaveOptions = new PdfOptions
            {
                VectorRasterizationOptions = odgRasterOptions
            };

            // Save the JPG as a PDF. The rasterization options ensure the JPG is
            // rendered correctly within the PDF document.
            jpgImage.Save(outputPdfPath, pdfSaveOptions);
        }
    }
}