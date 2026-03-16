using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        // Prepare output directory and file path
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "vector.emf");

        // Define device dimensions (pixels) and size in millimeters
        int deviceWidth = 600;
        int deviceHeight = 400;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Initialize EMF recorder graphics (do NOT wrap in using)
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Instantiate a GraphicsPath
        GraphicsPath path = new GraphicsPath();

        // Create a Figure and add a rectangle shape to it
        Figure figure = new Figure();
        figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 150f)));

        // Add the Figure to the GraphicsPath
        path.AddFigure(figure);

        // Draw the path onto the EMF canvas using a blue pen
        graphics.DrawPath(new Pen(Color.Blue, 2), path);

        // Finalize recording and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputPath);
        }
    }
}