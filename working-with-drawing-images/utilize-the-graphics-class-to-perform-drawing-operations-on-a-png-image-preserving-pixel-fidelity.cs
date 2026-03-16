using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output file path
        string outputPath = "output.png";

        // Create a file stream for the output PNG image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Initialize PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a blank PNG image with the specified dimensions
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a wheat background color
                graphics.Clear(Color.Wheat);

                // Draw a black diagonal line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, 0), new Point(500, 500));

                // Draw a red rectangle outline
                graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(100, 100, 300, 200));

                // Fill an ellipse with a solid blue brush
                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(blueBrush, new Rectangle(150, 150, 200, 100));
                }

                // Fill a rectangle with a semi‑transparent purple brush
                using (SolidBrush purpleBrush = new SolidBrush(Color.Purple))
                {
                    purpleBrush.Opacity = 100; // 100% opacity
                    graphics.FillRectangle(purpleBrush, new Rectangle(200, 250, 100, 100));
                }

                // Draw a string using a font and a solid black brush
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    Font font = new Font("Arial", 24);
                    graphics.DrawString("Aspose.Imaging Graphics Demo", font, textBrush, new PointF(50, 420));
                }

                // Save all changes to the bound stream
                image.Save();
            }
        }
    }
}