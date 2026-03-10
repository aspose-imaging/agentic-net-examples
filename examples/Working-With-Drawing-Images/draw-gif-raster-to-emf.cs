using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file and output EMF file paths
        string inputGifPath = "input.gif";
        string outputEmfPath = "output.emf";

        // Load the GIF as a raster image to obtain its dimensions
        using (RasterImage gifImage = (RasterImage)Image.Load(inputGifPath))
        {
            int width = gifImage.Width;
            int height = gifImage.Height;

            // Convert pixel dimensions to millimeters (approximation: 1 pixel = 0.01 mm)
            int widthMm = (int)(width / 100f);
            int heightMm = (int)(height / 100f);

            // Define the EMF canvas frame
            Rectangle frame = new Rectangle(0, 0, width, height);

            // Create the EMF recorder graphics object
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
                frame,
                new Size(width, height),
                new Size(widthMm, heightMm));

            // Draw the GIF onto the EMF canvas, scaling to fit the canvas size
            graphics.DrawImage(
                gifImage,
                new Rectangle(0, 0, width, height),
                new Rectangle(0, 0, width, height),
                GraphicsUnit.Pixel);

            // Finalize recording and save the EMF file
            using (EmfImage emfImage = graphics.EndRecording())
            {
                emfImage.Save(outputEmfPath);
            }
        }
    }
}