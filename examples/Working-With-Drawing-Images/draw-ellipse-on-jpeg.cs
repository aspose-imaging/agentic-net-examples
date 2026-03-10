using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class DrawEllipseOnJpeg
{
    static void Main()
    {
        // Path to the output JPEG file
        string outputPath = @"C:\temp\ellipse.jpg";

        // Create a FileStream for the output file
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure JPEG options and set the stream as the source
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Source = new StreamSource(stream);

            // Create a new JPEG image with desired dimensions (e.g., 400x300)
            using (Image image = Image.Create(jpegOptions, 400, 300))
            {
                // Initialize Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear the background with a solid color (e.g., LightGray)
                graphics.Clear(Color.LightGray);

                // Define a pen for the ellipse (color: Blue, width: 3)
                Pen ellipsePen = new Pen(Color.Blue, 3);

                // Define the bounding rectangle for the ellipse
                // Here we draw an ellipse inside a rectangle at (50,50) with width 300 and height 200
                Rectangle ellipseBounds = new Rectangle(50, 50, 300, 200);

                // Draw the ellipse
                graphics.DrawEllipse(ellipsePen, ellipseBounds);

                // Save all changes to the JPEG image (the stream is already linked via options)
                image.Save();
            }
        }
    }
}