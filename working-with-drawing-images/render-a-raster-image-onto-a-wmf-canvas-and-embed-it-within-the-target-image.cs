using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for source raster image and output WMF file
        string dataDir = @"c:\temp\";
        string rasterPath = Path.Combine(dataDir, "sample.bmp");
        string outputWmf = Path.Combine(dataDir, "output.wmf");

        // Define WMF canvas size (in pixels) and DPI
        int canvasWidth = 600;
        int canvasHeight = 400;
        int dpi = 96;

        // Create a rectangle that represents the WMF frame
        Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, canvasWidth, canvasHeight);

        // Initialize the WMF recorder graphics object
        WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(frame, dpi);

        // Load the raster image that will be drawn onto the WMF canvas
        using (RasterImage raster = (RasterImage)Image.Load(rasterPath))
        {
            // Destination rectangle on the WMF canvas where the raster will be placed
            Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(100, 50, 200, 150);

            // Source rectangle – the whole raster image
            Aspose.Imaging.Rectangle srcRect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);

            // Draw the raster image onto the WMF canvas, scaling it to fit destRect
            graphics.DrawImage(raster, destRect, srcRect, GraphicsUnit.Pixel);
        }

        // Finalize recording and obtain the WMF image object
        using (WmfImage wmfImage = graphics.EndRecording())
        {
            // Save the WMF image to disk
            wmfImage.Save(outputWmf);
        }
    }
}