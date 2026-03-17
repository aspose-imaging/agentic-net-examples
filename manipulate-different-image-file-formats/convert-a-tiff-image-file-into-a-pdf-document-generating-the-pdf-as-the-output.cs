// Path to the source TIFF file
string tiffPath = @"C:\Temp\source.tif";

// Path where the resulting PDF will be saved
string pdfPath = @"C:\Temp\result.pdf";

// Load the TIFF image using Aspose.Imaging's load rule
using (Aspose.Imaging.Image tiffImage = Aspose.Imaging.Image.Load(tiffPath))
{
    // Create PDF save options (default options are sufficient for a simple conversion)
    Aspose.Imaging.ImageOptions.PdfOptions pdfOptions = new Aspose.Imaging.ImageOptions.PdfOptions();

    // Save the loaded image as a PDF using Aspose.Imaging's save rule
    tiffImage.Save(pdfPath, pdfOptions);
}