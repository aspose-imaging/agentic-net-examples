using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Folder where source TIFF and result WMF will be stored
        string dir = @"C:\Temp\";

        // WMF canvas size (in pixels) and resolution (dpi)
        int wmfWidth = 600;
        int wmfHeight = 400;
        int dpi = 96;

        // Define the drawing frame for the WMF recorder (measured in twips)
        Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, wmfWidth, wmfHeight);

        // Create a WMF recorder graphics object
        WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(frame, dpi);

        // Load the source TIFF image (RasterImage) using the standard Image.Load method
        using (RasterImage tiffImage = (RasterImage)Image.Load(dir + "sample.tif"))
        {
            // Destination rectangle inside the WMF where the TIFF will be drawn
            Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(100, 50, 200, 150);

            // Source rectangle – the whole TIFF image
            Aspose.Imaging.Rectangle srcRect = new Aspose.Imaging.Rectangle(0, 0, tiffImage.Width, tiffImage.Height);

            // Draw the TIFF onto the WMF, scaling it to fit the destination rectangle
            graphics.DrawImage(tiffImage, destRect, srcRect, Aspose.Imaging.GraphicsUnit.Pixel);
        }

        // Finalize recording and obtain the WMF image object
        using (WmfImage wmfImage = graphics.EndRecording())
        {
            // Save the WMF to disk using the standard Save method
            wmfImage.Save(dir + "output.wmf");
        }
    }
}