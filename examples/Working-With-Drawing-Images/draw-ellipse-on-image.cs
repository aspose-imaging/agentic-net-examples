using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Create a file stream for the output PNG image
        using (FileStream stream = new FileStream("ellipse.png", FileMode.Create))
        {
            // Set up PNG options and associate the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 image using the PNG options
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize the Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a light gray background
                graphics.Clear(Color.LightGray);

                // Define a pen (red color, 3-pixel width) for the ellipse outline
                Pen pen = new Pen(Color.Red, 3);

                // Draw an ellipse bounded by the rectangle (x=100, y=100, width=300, height=200)
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

                // Save the image (writes to the stream)
                image.Save();
            }
        }
    }
}