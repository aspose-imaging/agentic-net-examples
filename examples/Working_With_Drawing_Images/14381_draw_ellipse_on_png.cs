using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ellipse.png";

        // Create a file stream for the PNG image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options and associate the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with the specified width and height
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Optional: clear the background with a light gray color
                graphics.Clear(Color.LightGray);

                // Define a pen (color and thickness) for the ellipse
                Pen pen = new Pen(Color.Red, 3);

                // Draw an ellipse bounded by the rectangle (x=50, y=50, width=300, height=200)
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 300, 200));

                // Save the image (writes to the stream)
                image.Save();
            }
        }
    }
}