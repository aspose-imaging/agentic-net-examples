using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths to the source EMF, the raster image to embed, and the output EMF
        string dir = @"c:\temp\";
        string sourceEmfPath = System.IO.Path.Combine(dir, "base.emf");
        string rasterImagePath = System.IO.Path.Combine(dir, "sample.bmp");
        string outputEmfPath = System.IO.Path.Combine(dir, "result.emf");

        // Load the existing EMF image (lifecycle: load)
        using (EmfImage baseEmf = (EmfImage)Image.Load(sourceEmfPath))
        {
            // Obtain a recorder graphics object that contains all existing records
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(baseEmf);

            // Load the raster image that will be drawn onto the EMF canvas
            using (RasterImage raster = (RasterImage)Image.Load(rasterImagePath))
            {
                // Destination rectangle on the EMF canvas (position and size)
                Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(50, 50, raster.Width, raster.Height);
                // Source rectangle (full raster image)
                Aspose.Imaging.Rectangle srcRect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);

                // Draw the raster image onto the EMF graphics using original pixel units
                graphics.DrawImage(raster, destRect, srcRect, Aspose.Imaging.GraphicsUnit.Pixel);
            }

            // End recording to produce a new EMF image that includes the drawn raster (lifecycle: save)
            using (EmfImage resultEmf = graphics.EndRecording())
            {
                resultEmf.Save(outputEmfPath);
            }
        }
    }
}