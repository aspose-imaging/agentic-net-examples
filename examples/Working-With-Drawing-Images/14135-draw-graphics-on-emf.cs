using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Output directory
        string dir = Path.Combine(Environment.CurrentDirectory, "output");
        Directory.CreateDirectory(dir);

        // Image size in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert size to millimeters (1 pixel = 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Frame rectangle
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create EMF recorder graphics (do NOT wrap in using)
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw border rectangle
        graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, deviceWidth, deviceHeight);

        // Fill inner rectangle
        graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(10, 10, 580, 380));

        // Draw diagonal lines
        graphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, 0, deviceWidth, deviceHeight);
        graphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, deviceHeight, deviceWidth, 0);

        // Draw an arc
        graphics.DrawArc(new Pen(Color.Blue, 2), new Rectangle(0, 0, 200, 200), 90, 270);

        // Fill a pie segment
        graphics.FillPie(new SolidBrush(Color.LightSkyBlue), new Rectangle(0, 0, 150, 150), 90, 270);

        // Draw a cubic bezier curve
        graphics.DrawCubicBezier(new Pen(Color.Red, 2),
            new Point(0, 0),
            new Point(200, 133),
            new Point(400, 166),
            new Point(600, 400));

        // Draw a text string
        graphics.DrawString("Hello EMF!", new Font("Arial", 48, FontStyle.Regular), Color.DarkRed, 200, 300);

        // Finalize and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            string outputPath = Path.Combine(dir, "sample.emf");
            emfImage.Save(outputPath);
        }
    }
}