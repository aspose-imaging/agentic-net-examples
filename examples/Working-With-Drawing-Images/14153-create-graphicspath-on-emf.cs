using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Directory to store the output file
        string dir = @"c:\temp\";

        // Define EMF image size in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert size to millimeters (1 pixel ≈ 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create an EMF recorder graphics object
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // -------------------------------------------------
        // Create a GraphicsPath instance
        // -------------------------------------------------
        GraphicsPath path = new GraphicsPath();

        // Create a figure, mark it as closed and add a rectangle shape
        Figure figure = new Figure { IsClosed = true };
        figure.AddShape(new RectangleShape(new RectangleF(100, 100, 200, 150)));

        // Add the figure to the path
        path.AddFigure(figure);

        // Draw the path on the EMF canvas using an orange pen (5‑pixel width)
        graphics.DrawPath(new Pen(Color.Orange, 5), path);

        // -------------------------------------------------
        // Finalize the recording and save the EMF image
        // -------------------------------------------------
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(dir + "GraphicsPathExample.emf");
        }
    }
}