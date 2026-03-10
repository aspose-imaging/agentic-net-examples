using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input DNG, input JPG and output PDF
        string dngPath = "input.dng";
        string jpgPath = "input.jpg";
        string outputPdfPath = "output.pdf";

        // Load DNG image to obtain its dimensions
        using (DngImage dngImage = (DngImage)Image.Load(dngPath))
        {
            int canvasWidth = dngImage.Width;
            int canvasHeight = dngImage.Height;

            // Load JPG image as a raster image
            using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
            {
                // Create a raster canvas with the same size as the DNG image
                JpegOptions canvasOptions = new JpegOptions();
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    // Copy JPG pixels onto the canvas at position (0,0)
                    var jpgPixels = jpgImage.LoadArgb32Pixels(jpgImage.Bounds);
                    canvas.SaveArgb32Pixels(new Rectangle(0, 0, jpgImage.Width, jpgImage.Height), jpgPixels);

                    // Save the canvas as a PDF document
                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPdfPath, pdfOptions);
                }
            }
        }
    }
}