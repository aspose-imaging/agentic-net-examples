using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Cdr.CdrImagePage;

class MergeJpgToPngViaCdr
{
    static void Main()
    {
        // Convert a JPG image directly to PNG using Aspose.Imaging load and save.
        string jpgPath = "input.jpg";
        string pngFromJpgPath = "output_from_jpg.png";

        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Save the loaded JPG as PNG.
            jpgImage.Save(pngFromJpgPath, new PngOptions());
        }

        // Load a CDR file, extract its first page and save that page as PNG.
        string cdrPath = "input.cdr";
        string pngFromCdrPath = "output_from_cdr_page.png";

        using (CdrImage cdrImage = (CdrImage)Image.Load(cdrPath))
        {
            // Access the first page of the CDR document.
            CdrImagePage firstPage = (CdrImagePage)cdrImage.Pages[0];

            // Save the page as a PNG image.
            firstPage.Save(pngFromCdrPath, new PngOptions());
        }
    }
}