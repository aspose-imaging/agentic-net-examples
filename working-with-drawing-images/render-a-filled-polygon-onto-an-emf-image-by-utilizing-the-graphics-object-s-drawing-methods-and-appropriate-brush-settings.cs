using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\filledPolygon.emf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define image dimensions (pixels)
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert dimensions to millimeters (approximation: 1 pixel = 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create the EMF graphics recorder
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Create a closed figure for the polygon
        Figure polygonFigure = new Figure { IsClosed = true };
        GraphicsPath polygonPath = new GraphicsPath();
        polygonPath.AddFigure(polygonFigure);

        // Define polygon vertices
        PointF[] vertices = new PointF[]
        {
            new PointF(150, 100),
            new PointF(450, 100),
            new PointF(300, 300)
        };

        // Add the polygon shape to the figure
        polygonFigure.AddShapes(new Shape[]
        {
            new PolygonShape(vertices)
        });

        // Fill the polygon with a solid blue brush and outline with a black pen
        Pen outlinePen = new Pen(Color.Black, 2);
        SolidBrush fillBrush = new SolidBrush(Color.Blue);
        graphics.FillPath(outlinePen, fillBrush, polygonPath);

        // Finalize recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save the EMF image to the specified path
            emfImage.Save(outputPath);
        }
    }
}