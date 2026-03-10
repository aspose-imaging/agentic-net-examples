using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output EMF file path
        string outputPath = "output.emf";

        // Image dimensions in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Image dimensions in millimeters (approximation)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create EMF recorder graphics
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Define polygon vertices
        PointF[] polygonPoints = new PointF[]
        {
            new PointF(100, 100),
            new PointF(200, 50),
            new PointF(300, 150),
            new PointF(250, 250),
            new PointF(150, 200)
        };

        // Create a closed figure and add a polygon shape
        Figure figure = new Figure { IsClosed = true };
        GraphicsPath path = new GraphicsPath();
        path.AddFigure(figure);
        figure.AddShapes(new Shape[]
        {
            new PolygonShape(polygonPoints)
        });

        // Fill the polygon with a solid brush and outline with a pen
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush brush = new SolidBrush(Color.LightBlue);
        graphics.FillPath(pen, brush, path);

        // Finalize and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputPath);
        }
    }
}