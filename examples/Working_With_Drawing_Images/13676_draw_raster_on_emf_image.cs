using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Folder where input and output files are located
        string dir = @"C:\temp\";

        // Define EMF canvas size in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert size to millimeters (1 mm ≈ 0.1 pixel at 96 DPI)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Create a rectangle that represents the EMF frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Initialize the EMF recorder graphics object
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Load the raster image that will be drawn onto the EMF
        using (RasterImage raster = (RasterImage)Image.Load(dir + "sample.bmp"))
        {
            // Destination rectangle on the EMF canvas where the image will be placed
            Rectangle destRect = new Rectangle(100, 50, 200, 150);

            // Source rectangle (entire raster image)
            Rectangle srcRect = new Rectangle(0, 0, raster.Width, raster.Height);

            // Draw the raster image, scaling it to fit the destination rectangle
            graphics.DrawImage(raster, destRect, srcRect, GraphicsUnit.Pixel);
        }

        // Finish recording and obtain the resulting EMF image
        using (EmfImage emf = graphics.EndRecording())
        {
            // Save the EMF file to disk
            emf.Save(dir + "output.emf");
        }
    }
}