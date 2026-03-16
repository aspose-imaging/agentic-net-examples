using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class BezierCurveDemo
{
    static void Main()
    {
        // Output file path
        string outputPath = "bezier_curve.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options and associate the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 400x400 pixel image
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a white background
                graphics.Clear(Color.White);

                // Set smoothing mode to anti-alias for high‑fidelity curve rendering
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Define a blue pen with a 2‑pixel width
                Pen bezierPen = new Pen(Color.Blue, 2);

                // Draw a cubic Bézier curve with pixel‑accurate coordinates
                // Start point (50,300), control points (150,50) and (250,550), end point (350,300)
                graphics.DrawBezier(
                    bezierPen,
                    new Point(50, 300),
                    new Point(150, 50),
                    new Point(250, 550),
                    new Point(350, 300));

                // Persist the drawing to the output file
                image.Save();
            }
        }
    }
}