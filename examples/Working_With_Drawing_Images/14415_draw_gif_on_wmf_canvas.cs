using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;

class Program
{
    static void Main()
    {
        // Folder where source GIF and output WMF will be stored
        string dir = @"C:\temp\";

        // Load the raster image in GIF format
        using (RasterImage gifImage = (RasterImage)Image.Load(dir + "sample.gif"))
        {
            // Define WMF canvas size (in pixels) and screen resolution (dpi)
            int wmfWidth = 600;
            int wmfHeight = 400;
            int dpi = 96;

            // Create a rectangle that represents the WMF frame (measured in twips)
            Rectangle frame = new Rectangle(0, 0, wmfWidth, wmfHeight);

            // Initialize the WMF recorder graphics object
            var graphics = new WmfRecorderGraphics2D(frame, dpi);

            // Destination rectangle on the WMF canvas where the GIF will be drawn
            Rectangle destRect = new Rectangle(50, 50, 200, 150);

            // Source rectangle representing the whole GIF image
            Rectangle srcRect = new Rectangle(0, 0, gifImage.Width, gifImage.Height);

            // Draw the GIF onto the WMF canvas, scaling it to fit destRect
            graphics.DrawImage(gifImage, destRect, srcRect, GraphicsUnit.Pixel);

            // Finalize recording and obtain the WMF image
            using (WmfImage wmfImage = graphics.EndRecording())
            {
                // Save the resulting WMF file
                wmfImage.Save(dir + "output.wmf");
            }
        }
    }
}