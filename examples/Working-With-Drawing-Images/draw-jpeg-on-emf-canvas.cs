using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define the working directory
        string dir = @"C:\temp\";

        // Load the JPEG raster image
        using (JpegImage jpegImage = new JpegImage(dir + "sample.jpg"))
        {
            // Define EMF canvas size (pixels)
            int canvasWidth = 600;
            int canvasHeight = 400;

            // Convert canvas size to millimeters (1 mm ≈ 0.1 pixel at 96 DPI)
            int canvasWidthMm = (int)(canvasWidth / 100f);
            int canvasHeightMm = (int)(canvasHeight / 100f);

            // Create the EMF recording graphics object
            Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
                frame,
                new Size(canvasWidth, canvasHeight),
                new Size(canvasWidthMm, canvasHeightMm));

            // Define destination rectangle on the EMF canvas where the JPEG will be drawn
            Rectangle destRect = new Rectangle(50, 50, 200, 150);

            // Define source rectangle covering the whole JPEG image
            Rectangle srcRect = new Rectangle(0, 0, jpegImage.Width, jpegImage.Height);

            // Draw the JPEG image onto the EMF canvas, scaling it to fit the destination rectangle
            graphics.DrawImage(jpegImage, destRect, srcRect, GraphicsUnit.Pixel);

            // Finalize recording and obtain the EMF image
            using (EmfImage emfImage = graphics.EndRecording())
            {
                // Save the resulting EMF file
                emfImage.Save(dir + "output.emf");
            }
        }
    }
}