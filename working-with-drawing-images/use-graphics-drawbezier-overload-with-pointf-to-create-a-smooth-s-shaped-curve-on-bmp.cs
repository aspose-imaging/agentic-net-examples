using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded output path (BMP file)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up BMP options with the stream as the source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new StreamSource(stream)
            };

            // Define image dimensions
            int width = 400;
            int height = 500;

            // Create the BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define a black pen with a thickness of 2
                Pen pen = new Pen(Color.Black, 2);

                // Define the four points of the S‑shaped Bézier curve
                PointF pt1 = new PointF(50, 250);   // start point
                PointF pt2 = new PointF(150, 50);   // first control point
                PointF pt3 = new PointF(250, 450);  // second control point
                PointF pt4 = new PointF(350, 250);  // end point

                // Draw the Bézier curve using the PointF overload
                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                // Save changes to the stream (the file)
                image.Save();
            }
        }
    }
}