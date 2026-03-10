using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Color;
using Aspose.Imaging.Size;
using Aspose.Imaging.Rectangle;
using Aspose.Imaging.PointF;
using Aspose.Imaging.Figure;
using Aspose.Imaging.GraphicsPath;
using Aspose.Imaging.Pen;

class Program
{
    static void Main()
    {
        // Define output directory
        string dir = @"C:\Temp\";

        // Image size in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert size to millimeters (1 pixel = 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create an EMF recorder graphics object
        using (EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Aspose.Imaging.Size(deviceWidth, deviceHeight),
            new Aspose.Imaging.Size(deviceWidthMm, deviceHeightMm)))
        {
            // Create a figure and add some shapes to it
            Figure figure = new Figure();
            figure.IsClosed = true; // Close the figure for proper filling (optional)

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(100f, 100f, 200f, 150f)));

            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(350f, 120f, 180f, 120f)));

            // Create a graphics path and add the figure
            GraphicsPath path = new GraphicsPath();
            path.AddFigure(figure);

            // Draw the path using an orange pen of width 5
            graphics.DrawPath(new Pen(Color.Orange, 5), path);

            // Finish recording and obtain the EMF image
            using (EmfImage emfImage = graphics.EndRecording())
            {
                // Save the EMF image to file
                emfImage.Save(dir + "GraphicsPathExample.emf");
            }
        }
    }
}