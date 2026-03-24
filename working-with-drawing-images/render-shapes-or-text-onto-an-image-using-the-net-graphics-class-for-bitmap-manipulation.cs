using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"C:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with desired dimensions
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Draw a line
                graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2),
                                  new Aspose.Imaging.Point(50, 50),
                                  new Aspose.Imaging.Point(450, 50));

                // Draw a rectangle
                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 3),
                                       new Aspose.Imaging.Rectangle(100, 100, 300, 200));

                // Draw an ellipse
                graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                                     new Aspose.Imaging.Rectangle(150, 150, 200, 100));

                // Prepare a solid brush for text
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Purple;
                    brush.Opacity = 100;

                    // Draw a text string
                    graphics.DrawString("Hello Aspose.Imaging",
                                        new Aspose.Imaging.Font("Arial", 24),
                                        brush,
                                        new Aspose.Imaging.PointF(120, 320));
                }

                // Save changes to the bound stream
                image.Save();
            }
        }
    }
}