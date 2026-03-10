using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class MergeJpgToPdfViaEps
{
    static void Main()
    {
        // Path to the source JPG image
        const string jpgPath = "input.jpg";

        // Temporary EPS file that will hold the raster preview of the JPG
        const string epsPath = "temp.eps";

        // Final PDF file that will contain the image
        const string pdfPath = "merged.pdf";

        // Load the JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Save the JPG as an EPS file (raster preview will be created automatically)
            jpgImage.Save(epsPath, new EpsOptions());

            // Load the generated EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
            {
                // Configure PDF saving options (optional compliance settings)
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS image as a PDF document
                epsImage.Save(pdfPath, pdfOptions);
            }
        }
    }
}