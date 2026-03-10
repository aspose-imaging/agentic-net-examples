using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Define image dimensions
        int deviceWidth = 600;
        int deviceHeight = 400;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Create a frame rectangle for the EMF canvas
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Initialize the EMF graphics recorder (do NOT wrap in using)
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw a cubic Bezier curve with a red pen
        Pen redPen = new Pen(Color.Red, 2);
        graphics.DrawCubicBezier(
            redPen,
            new Point(0, 0),          // start point
            new Point(200, 133),      // first control point
            new Point(400, 166),      // second control point
            new Point(600, 400));     // end point

        // Finalize recording and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            string outputPath = "output.emf";
            emfImage.Save(outputPath);
            Console.WriteLine($"EMF image saved to {outputPath}");
        }
    }
}