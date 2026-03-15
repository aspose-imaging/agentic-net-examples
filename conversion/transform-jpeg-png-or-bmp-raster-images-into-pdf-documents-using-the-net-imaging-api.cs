using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageToPdfConverter
{
    static void Main()
    {
        // List of raster image files to be converted (JPEG, PNG, BMP)
        string[] imageFiles = { "sample.jpg", "sample.png", "sample.bmp" };

        foreach (string imagePath in imageFiles)
        {
            // Load the raster image using Aspose.Imaging's lifecycle method
            using (Image rasterImage = Image.Load(imagePath))
            {
                // Prepare PDF save options (default options are sufficient for basic conversion)
                PdfOptions pdfOptions = new PdfOptions();

                // Define the output PDF file name (same base name, .pdf extension)
                string pdfPath = Path.ChangeExtension(imagePath, ".pdf");

                // Save the loaded image as a PDF document using the save lifecycle method
                rasterImage.Save(pdfPath, pdfOptions);
            }
        }
    }
}