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
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define canvas size (in pixels) and size in millimeters
        int deviceWidth = 800;
        int deviceHeight = 600;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Create EMF recorder graphics
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw a border rectangle
        graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, deviceWidth, deviceHeight);

        // Create a GraphicsPath with a closed rectangle shape
        Figure figure = new Figure { IsClosed = true };
        figure.AddShape(new RectangleShape(new RectangleF(100, 100, 300, 200)));

        GraphicsPath path = new GraphicsPath();
        path.AddFigure(figure);

        // Fill the path with yellow and outline with green
        graphics.FillPath(new Pen(Color.Green, 2), new SolidBrush(Color.Yellow), path);

        // Draw the same path with an orange pen
        graphics.DrawPath(new Pen(Color.Orange, 5), path);

        // Load a raster image and draw it onto the EMF canvas
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            graphics.DrawImage(
                raster,
                new Rectangle(450, 350, 200, 150),               // destination rectangle on EMF canvas
                new Rectangle(0, 0, raster.Width, raster.Height), // source rectangle from raster image
                GraphicsUnit.Pixel);
        }

        // Add a text string
        graphics.DrawString(
            "Aspose.Imaging EMF Demo",
            new Font("Arial", 36, FontStyle.Regular),
            Color.DarkRed,
            150,
            500);

        // Finalize recording and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputPath);
        }
    }
}