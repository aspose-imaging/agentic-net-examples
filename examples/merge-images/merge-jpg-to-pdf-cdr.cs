using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string cdrPath = "input.cdr";
        string[] jpgPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPdfPath = "merged_output.pdf";

        // Load CDR file to obtain canvas dimensions
        using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
        {
            int canvasWidth = cdr.Width;
            int canvasHeight = cdr.Height;

            // Create a temporary JPEG canvas with the same dimensions as the CDR page
            using (MemoryStream tempStream = new MemoryStream())
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new StreamSource(tempStream, true),
                    Quality = 100
                };

                using (RasterImage canvas = (RasterImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
                {
                    // Merge each JPG onto the canvas horizontally
                    int offsetX = 0;
                    foreach (string jpgPath in jpgPaths)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                        {
                            // Define the area where the current image will be placed
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            // Copy pixel data from the JPG to the canvas
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width; // Move the X offset for the next image
                        }
                    }

                    // Save the merged canvas as a PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPdfPath, pdfOptions);
                }
            }
        }
    }
}