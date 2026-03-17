using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Image dimensions in pixels
        int width = 600;
        int height = 400;

        // Convert dimensions to millimeters (1 pixel ≈ 0.01 mm)
        int widthMm = (int)(width / 100f);
        int heightMm = (int)(height / 100f);

        // Define the frame rectangle for the metafile
        Rectangle frame = new Rectangle(0, 0, width, height);

        // Create an EMF recorder graphics object
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(width, height),
            new Size(widthMm, heightMm));

        // Define a solid brush for filling
        Brush fillBrush = new SolidBrush(Color.LightGray);

        // Define the rectangle to fill (x, y, width, height)
        Rectangle fillRect = new Rectangle(50, 50, 500, 300);

        // Fill the rectangle on the metafile
        graphics.FillRectangle(fillBrush, fillRect);

        // End recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save the resulting EMF file
            emfImage.Save("filled_rectangle.emf");
        }
    }
}