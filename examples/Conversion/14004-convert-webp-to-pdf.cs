// Path to the folder containing the source WebP image and the destination PDF.
string dir = @"C:\temp\";

// Load the WebP image from a file.
using (Aspose.Imaging.FileFormats.Webp.WebPImage webPImage = new Aspose.Imaging.FileFormats.Webp.WebPImage(dir + "source.webp"))
{
    // Save the loaded image as a PDF document.
    // PdfOptions specifies that the output format should be PDF.
    webPImage.Save(dir + "result.pdf", new Aspose.Imaging.ImageOptions.PdfOptions());
}