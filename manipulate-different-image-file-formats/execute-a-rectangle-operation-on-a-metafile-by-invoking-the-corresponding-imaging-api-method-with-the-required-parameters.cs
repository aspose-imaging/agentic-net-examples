using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

public class Program
{
    public static void Main(string[] args)
    {
        // Define image dimensions in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert dimensions to millimeters (approximation: 1 pixel = 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create the EMF recorder graphics object
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Create a black pen with 1-pixel width
        Pen pen = new Pen(Color.Black, 1);

        // Draw a rectangle covering the entire canvas
        graphics.DrawRectangle(pen, 0, 0, deviceWidth, deviceHeight);

        // Finalize recording and save the EMF file
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save("output.emf");
        }
    }
}