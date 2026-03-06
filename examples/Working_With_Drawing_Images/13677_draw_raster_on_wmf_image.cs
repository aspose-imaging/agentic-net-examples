using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Folder containing the source raster image and where the WMF will be saved
        string dir = @"c:\temp\";

        // WMF canvas size in pixels (also used as twips for simplicity)
        int imageWidth = 600;
        int imageHeight = 400;
        int dpi = 96; // screen resolution

        // Define the frame rectangle for the WMF recorder
        Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, imageWidth, imageHeight);

        // Create a WMF recorder graphics object
        WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(frame, dpi);

        // Load the raster image that will be drawn onto the WMF
        using (RasterImage raster = (RasterImage)Image.Load(dir + "sample.bmp"))
        {
            // Destination rectangle inside the WMF where the raster image will be placed
            Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(100, 80, 200, 150);

            // Source rectangle – the whole raster image
            Aspose.Imaging.Rectangle srcRect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);

            // Draw the raster image onto the WMF, scaling it to fit destRect
            graphics.DrawImage(raster, destRect, srcRect, GraphicsUnit.Pixel);
        }

        // Finish recording and obtain the resulting WMF image
        using (WmfImage wmfImage = graphics.EndRecording())
        {
            // Save the WMF file
            wmfImage.Save(dir + "output.wmf");
        }
    }
}