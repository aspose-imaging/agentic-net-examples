string dataDir = @"c:\temp\";

// Load a WebP image from a file.
using (Aspose.Imaging.FileFormats.Webp.WebPImage webPImage = new Aspose.Imaging.FileFormats.Webp.WebPImage(dataDir + "test.webp"))
{
    // Save the loaded WebP image to PDF.
    // Only the active frame is saved because PDF is a single‑page format.
    webPImage.Save(dataDir + "test.pdf", new Aspose.Imaging.ImageOptions.PdfOptions());
}