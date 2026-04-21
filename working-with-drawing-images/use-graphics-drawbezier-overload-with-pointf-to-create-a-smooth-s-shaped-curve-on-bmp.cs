using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\s_curve.bmp";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image of size 500x500
        BmpOptions bmpOptions = new BmpOptions();
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Fill background with white
            graphics.Clear(Color.White);

            // Define four points that form an S‑shaped Bezier curve
            PointF pt1 = new PointF(50, 400);   // start point
            PointF pt2 = new PointF(150, 50);   // first control point
            PointF pt3 = new PointF(350, 450);  // second control point
            PointF pt4 = new PointF(450, 100);  // end point

            // Create a blue pen with thickness 3
            Pen pen = new Pen(Color.Blue, 3);

            // Draw the Bezier curve using the PointF overload
            graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}