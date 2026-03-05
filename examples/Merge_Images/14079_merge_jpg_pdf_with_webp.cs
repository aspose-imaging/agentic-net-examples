using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string jpgPath = @"C:\temp\input.jpg";
        // Temporary WebP file path
        string webpPath = @"C:\temp\temp.webp";
        // Output PDF file path
        string pdfPath = @"C:\temp\output.pdf";

        // Load the JPG image as a raster image
        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        {
            // Convert the raster JPG to a WebP image
            using (WebPImage webPImage = new WebPImage(jpgImage))
            {
                // Save the WebP image to a temporary file
                webPImage.Save(webpPath, new WebPOptions());
            }
        }

        // Load the generated WebP image
        using (Image webP = Image.Load(webpPath))
        {
            // Save the WebP image as a PDF document
            webP.Save(pdfPath, new PdfOptions());
        }

        // Optionally delete the temporary WebP file
        if (File.Exists(webpPath))
        {
            File.Delete(webpPath);
        }
    }
}