// Define the folder containing the source WebP image and the output PDF
string dir = @"c:\temp\";

// Load the WebP image from file using the WebPImage constructor
using (Aspose.Imaging.FileFormats.Webp.WebPImage webPImage = new Aspose.Imaging.FileFormats.Webp.WebPImage(dir + "test.webp"))
{
    // Save the loaded image directly to PDF format.
    // PdfOptions ensures the image is embedded in the PDF with its original fidelity.
    webPImage.Save(dir + "test.pdf", new Aspose.Imaging.ImageOptions.PdfOptions());
}