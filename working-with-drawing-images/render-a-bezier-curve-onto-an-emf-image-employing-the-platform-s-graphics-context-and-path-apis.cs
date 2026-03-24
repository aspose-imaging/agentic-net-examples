using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\BezierCurve.emf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image dimensions in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Convert dimensions to millimeters (1 pixel ≈ 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create the EMF graphics recorder
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw a cubic Bezier curve with a red 2‑pixel pen
        graphics.DrawCubicBezier(
            new Pen(Color.Red, 2),
            new Point(50, 350),   // start point
            new Point(150, 50),   // first control point
            new Point(450, 50),   // second control point
            new Point(550, 350)   // end point
        );

        // Finalize recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save the EMF image to the hardcoded path
            emfImage.Save(outputPath);
        }
    }
}