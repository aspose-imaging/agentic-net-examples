using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Path where the PNG will be saved
        string outputPath = @"C:\temp\output.png";

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a blank PNG image of 500x500 pixels
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a light background color
                graphics.Clear(Color.Wheat);

                // Draw a red rectangle
                graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(50, 50, 200, 150));

                // Draw a blue ellipse inside the rectangle
                graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(50, 50, 200, 150));

                // Draw a green diagonal line
                graphics.DrawLine(new Pen(Color.Green, 4), new Point(50, 50), new Point(250, 200));

                // Draw a text string near the bottom
                SolidBrush textBrush = new SolidBrush(Color.Purple);
                Font font = new Font("Arial", 20);
                graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(60, 400));

                // Save the image (writes to the stream)
                image.Save();
            }
        }
    }
}