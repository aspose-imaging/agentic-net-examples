using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Draw an arc: black pen, rectangle (100,100,300,200), start angle 0, sweep 180 degrees
                graphics.DrawArc(new Pen(Color.Black, 2), new Rectangle(100, 100, 300, 200), 0, 180);

                // Save the image (stream is already bound, so just call Save)
                image.Save();
            }
        }
    }
}