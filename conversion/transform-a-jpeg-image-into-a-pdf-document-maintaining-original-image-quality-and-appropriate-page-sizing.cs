using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpegToPdfConverter
{
    static void Main()
    {
        // Path to the source JPEG image
        string jpegPath = @"C:\Images\source.jpg";

        // Desired output PDF file path
        string pdfPath = @"C:\Images\output.pdf";

        // Load the JPEG image using the provided load rule
        using (Image jpegImage = Image.Load(jpegPath))
        {
            // Retrieve the original image dimensions
            int imgWidth = jpegImage.Width;
            int imgHeight = jpegImage.Height;

            // Create PDF options and set the page size to match the image dimensions
            PdfOptions pdfOptions = new PdfOptions
            {
                // Ensure the PDF page exactly fits the image to preserve quality
                PageSize = new SizeF(imgWidth, imgHeight)
            };

            // Save the image as a PDF using the provided save rule
            jpegImage.Save(pdfPath, pdfOptions);
        }
    }
}