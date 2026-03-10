using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Path where the resulting PNG image will be saved
        string outputPath = "bezier_output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options and associate the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new 400x400 PNG image
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize the graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Fill the background with white color
                graphics.Clear(Color.White);

                // Define a blue pen with a thickness of 3 pixels
                Pen pen = new Pen(Color.Blue, 3);

                // Define the four points that make up the Bezier curve
                Point startPoint      = new Point(50, 350);   // Starting point
                Point controlPoint1   = new Point(150, 50);   // First control point
                Point controlPoint2   = new Point(250, 350);  // Second control point
                Point endPoint        = new Point(350, 50);   // Ending point

                // Draw the Bezier curve using the defined pen and points
                graphics.DrawBezier(pen, startPoint, controlPoint1, controlPoint2, endPoint);

                // Persist all changes to the image (writes to the stream)
                image.Save();
            }
        }
    }
}