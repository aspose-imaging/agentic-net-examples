using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for the source JPG and the resulting PDF
        string jpgPath = @"C:\Images\source.jpg";
        string pdfPath = @"C:\Images\merged.pdf";

        // Load the JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Convert the JPG to PNG and keep it in memory
            using (MemoryStream pngStream = new MemoryStream())
            {
                // Create PNG save options (default settings)
                var pngOptions = new PngOptions();

                // Save the JPG image as PNG into the memory stream
                jpgImage.Save(pngStream, pngOptions);
                pngStream.Position = 0; // Reset stream position for reading

                // Load the PNG image from the memory stream
                using (Image pngImage = Image.Load(pngStream))
                {
                    // Prepare PDF save options (Aspose.Imaging provides PdfOptions)
                    var pdfOptions = new PdfOptions();

                    // Save the PNG image as a PDF page – this effectively merges the JPG (now PNG) into a PDF
                    pngImage.Save(pdfPath, pdfOptions);
                }
            }
        }
    }
}