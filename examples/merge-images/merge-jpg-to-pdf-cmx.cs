using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input CMX file that defines the canvas size
        string cmxPath = "canvas.cmx";

        // JPG images to merge onto the canvas
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output PDF file
        string outputPdfPath = "merged.pdf";

        // Load CMX to obtain canvas dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Create an unbound JPEG canvas with the same size as the CMX image
            JpegOptions jpegOptions = new JpegOptions(); // No source – unbound canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;

                // Merge each JPG horizontally onto the canvas
                foreach (string jpgPath in jpgPaths)
                {
                    using (RasterImage raster = (RasterImage)Image.Load(jpgPath))
                    {
                        // Define the destination rectangle on the canvas
                        Rectangle destRect = new Rectangle(offsetX, 0, raster.Width, raster.Height);

                        // Copy pixel data from the JPG to the canvas
                        canvas.SaveArgb32Pixels(destRect, raster.LoadArgb32Pixels(raster.Bounds));

                        offsetX += raster.Width;
                    }
                }

                // Save the merged canvas as a PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}