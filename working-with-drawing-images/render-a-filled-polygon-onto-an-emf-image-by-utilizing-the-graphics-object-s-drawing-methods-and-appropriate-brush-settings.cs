using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output EMF file path
        string outputPath = Path.Combine(Path.GetTempPath(), "filledPolygon.emf");

        // Canvas size in pixels
        int width = 600;
        int height = 400;

        // Canvas size in millimeters (1 pixel = 0.01 mm)
        int widthMm = (int)(width / 100f);
        int heightMm = (int)(height / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, width, height);

        // Create EMF recorder graphics
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(width, height),
            new Size(widthMm, heightMm));

        // Create a closed figure for the polygon
        Figure figure = new Figure { IsClosed = true };
        GraphicsPath path = new GraphicsPath();
        path.AddFigure(figure);

        // Define polygon vertices
        figure.AddShapes(new Shape[]
        {
            new PolygonShape(new PointF[]
            {
                new PointF(100, 100),
                new PointF(300, 80),
                new PointF(350, 200),
                new PointF(200, 250),
                new PointF(120, 180)
            })
        });

        // Fill the polygon with a solid brush and outline with a pen
        using (SolidBrush brush = new SolidBrush(Color.CornflowerBlue))
        {
            Pen pen = new Pen(Color.Black, 1);
            graphics.FillPath(pen, brush, path);
        }

        // Finalize and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputPath);
        }
    }
}