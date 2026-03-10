using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG and output PDF paths
        string jpgPath = "input.jpg";
        string pdfPath = "output.pdf";

        // Load the JPG image as a raster image
        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        {
            int width = jpgImage.Width;
            int height = jpgImage.Height;

            // Create a WMF canvas with the same dimensions as the JPG
            using (WmfImage wmfCanvas = new WmfImage(width, height))
            {
                // Set a white background for the WMF canvas
                wmfCanvas.BackgroundColor = Aspose.Imaging.Color.White;

                // Draw the JPG onto the WMF canvas
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(wmfCanvas);
                graphics.DrawImage(jpgImage, new Aspose.Imaging.Point(0, 0));

                // Save the WMF canvas directly as a PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    wmfCanvas.Save(pdfPath, pdfOptions);
                }
            }
        }
    }
}