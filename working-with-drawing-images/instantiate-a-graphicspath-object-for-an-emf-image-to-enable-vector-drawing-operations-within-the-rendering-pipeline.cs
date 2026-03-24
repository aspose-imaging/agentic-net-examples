using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define EMF image dimensions
        int deviceWidth = 600;
        int deviceHeight = 400;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Create the EMF recording graphics object
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);
        var graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Example drawing: a simple rectangle border
        graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, deviceWidth, deviceHeight);

        // Create a GraphicsPath to hold vector figures
        GraphicsPath path = new GraphicsPath();

        // Create a figure and add shapes to it
        Figure figure = new Figure { IsClosed = true };
        figure.AddShape(new ArcShape(new Rectangle(200, 200, 200, 200), 0, 360));
        figure.AddShape(new BezierShape(new PointF[]
        {
            new PointF(250, 250),
            new PointF(300, 200),
            new PointF(350, 300),
            new PointF(400, 250)
        }));
        // Add the figure to the path
        path.AddFigure(figure);

        // Draw the path using a pen
        graphics.DrawPath(new Pen(Color.Orange, 5), path);

        // Load a raster image and draw it onto the EMF (demonstrates input usage)
        using (RasterImage imageToDraw = (RasterImage)Image.Load(inputPath))
        {
            graphics.DrawImage(
                imageToDraw,
                new Rectangle(400, 200, 100, 50),
                new Rectangle(0, 0, deviceWidth, deviceHeight),
                GraphicsUnit.Pixel);
        }

        // Finish recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save the EMF image to the output path
            emfImage.Save(outputPath);
        }
    }
}