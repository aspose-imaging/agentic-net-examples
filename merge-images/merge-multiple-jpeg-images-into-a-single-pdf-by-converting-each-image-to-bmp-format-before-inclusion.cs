using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input JPEG files and output PDF path
        string[] jpegPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };
        string outputPdfPath = @"C:\Images\merged.pdf";

        // List to hold BMP images (as Image objects)
        List<Image> bmpImages = new List<Image>();

        foreach (string jpegPath in jpegPaths)
        {
            // Load JPEG as raster image
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegPath))
            {
                // Prepare BMP options with an in‑memory stream source
                BmpOptions bmpOptions = new BmpOptions();
                MemoryStream bmpStream = new MemoryStream();
                bmpOptions.Source = new StreamSource(bmpStream, false);

                // Create BMP image with same dimensions as JPEG
                RasterImage bmpImage = (RasterImage)Image.Create(bmpOptions, jpegImage.Width, jpegImage.Height);

                // Copy pixel data from JPEG to BMP
                bmpImage.SaveArgb32Pixels(bmpImage.Bounds, jpegImage.LoadArgb32Pixels(jpegImage.Bounds));

                // Add BMP image to collection (will be disposed later)
                bmpImages.Add(bmpImage);
            }
        }

        // Create a multipage image from the BMP pages
        using (Image pdfImage = Image.Create(bmpImages.ToArray()))
        {
            // Save the multipage image as PDF
            pdfImage.Save(outputPdfPath, new PdfOptions());
        }

        // Dispose all BMP images and their underlying streams
        foreach (Image img in bmpImages)
        {
            img.Dispose();
        }
    }
}