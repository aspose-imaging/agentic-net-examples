using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define the JPG image files to be merged.
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Create a multipage image from the JPG files.
        using (Image multipageImage = Image.Create(jpgPaths))
        {
            // Set PDF export options.
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a single PDF document.
            multipageImage.Save("merged_output.pdf", pdfOptions);
        }
    }
}