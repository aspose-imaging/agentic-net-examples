using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input raster image and output BMP file
        string inputRasterPath = "sample.bmp";
        string outputBmpPath = "output.bmp";

        // Define canvas size for the vector image
        int canvasWidth = 800;
        int canvasHeight = 600;
        Rectangle canvasFrame = new Rectangle(0, 0, canvasWidth, canvasHeight);

        // Create a vector graphics recorder for EMF
        EmfRecorderGraphics2D vectorGraphics = new EmfRecorderGraphics2D(canvasFrame, canvasWidth, canvasHeight);

        // Load the raster image to be drawn
        using (RasterImage raster = (RasterImage)Image.Load(inputRasterPath))
        {
            // Draw the raster image onto the vector canvas, scaling it to fit the canvas
            vectorGraphics.DrawImage(
                raster,
                new Rectangle(100, 100, raster.Width, raster.Height), // destination rectangle on canvas
                new Rectangle(0, 0, canvasWidth, canvasHeight),      // source rectangle (full raster)
                GraphicsUnit.Pixel);
        }

        // Finalize the vector recording and obtain an EMF image
        using (EmfImage emfImage = vectorGraphics.EndRecording())
        {
            // Prepare BMP save options with a file source
            Source bmpSource = new FileCreateSource(outputBmpPath, false);
            BmpOptions bmpOptions = new BmpOptions { Source = bmpSource };

            // Save the EMF image as a BMP file
            emfImage.Save(outputBmpPath, bmpOptions);
        }
    }
}