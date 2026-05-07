using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string outputPath = @"C:\temp\s_curve.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image of size 400x500
            using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(outStream);

                using (Image image = Image.Create(bmpOptions, 400, 500))
                {
                    // Initialize graphics surface
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Define pen for the curve
                    Pen pen = new Pen(Color.Blue, 2);

                    // Define four points that form an S‑shaped Bézier curve
                    PointF pt1 = new PointF(50, 250);   // start point
                    PointF pt2 = new PointF(150, 50);   // first control point
                    PointF pt3 = new PointF(250, 450);  // second control point
                    PointF pt4 = new PointF(350, 250);  // end point

                    // Draw the Bézier curve using the PointF overload
                    graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                    // Save the image
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}